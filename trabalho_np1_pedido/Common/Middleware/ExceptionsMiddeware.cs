using System.Net;
using System.Text.Json;
using trabalho_np1_pedido.Domain.Errors;

namespace trabalho_np1_pedido.Common.Middleware
{
    public class ExceptionsMiddeware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsMiddeware> _logger;

        public ExceptionsMiddeware(RequestDelegate requestDelegate, ILogger<ExceptionsMiddeware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";

                var statusCode = ex switch
                {
                    BadRequestException => (int)HttpStatusCode.BadRequest,
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    DomainExceptions => (int)HttpStatusCode.BadRequest,

                    _ => StatusCodes.Status500InternalServerError
                };

                context.Response.StatusCode = statusCode;

                var response = new ErrorResponse
                {
                    StatusCode = statusCode,
                    Message = ex.Message
                };

                JsonSerializerOptions jsonSerializerOptions = new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var options = jsonSerializerOptions;

                await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
            }
        }
    }

    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }
        public IEnumerable<ErrorDetailResponse>? Details { get; set; }
    }

    public class ErrorDetailResponse
    {
        public required string Field { get; set; }
        public string? Message { get; set; }
    }
}
