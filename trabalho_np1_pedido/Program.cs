using trabalho_np1_pedido.Application.Mapping;
using trabalho_np1_pedido.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraDb(builder.Configuration);
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingDtoToEntity).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingEntityToDto).Assembly);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
