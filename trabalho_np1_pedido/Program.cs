using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using trabalho_np1_pedido.Application.Mapping;
using trabalho_np1_pedido.Common.Middleware;
using trabalho_np1_pedido.Data.Context;
using trabalho_np1_pedido.IoC;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddInfraDb(builder.Configuration);
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingDtoToEntity).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingEntityToDto).Assembly);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// Este bloco aplica as migrations pendentes assim que subir a aplicação
/// Necessário para que o docker compose up já prepare o banco
/// Com esse bloco, não é necessário rodar o comando "dotnet ef database update"
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseMiddleware(typeof(ExceptionsMiddeware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
