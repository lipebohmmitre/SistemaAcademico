using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var mysqlConnectionString = builder.Configuration.GetConnectionString("ConexaoMysql");
builder.Services.AddDbContext<SistemaAcademicoDbContext>(options =>
    options.UseMySql(mysqlConnectionString, ServerVersion.AutoDetect(mysqlConnectionString)));




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
