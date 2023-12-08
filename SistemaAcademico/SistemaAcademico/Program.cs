using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.DTOs.MappingProfile;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository;
using SistemaAcademico.Repository.InterfacesRepository;
using SistemaAcademico.Services;
using SistemaAcademico.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options
    => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);



builder.Services.AddScoped<ICategoria, CategoriaService>();
builder.Services.AddScoped<ISubCategoria, SubCategoriaService>();
builder.Services.AddScoped<ICurso, CursoService>();
builder.Services.AddScoped<IDisciplina, DisciplinaService>();
builder.Services.AddScoped<ICursoDisciplina, CursoDisciplinaService>();



var mysqlConnectionString = builder.Configuration.GetConnectionString("ConexaoMysql");
builder.Services.AddDbContext<SistemaAcademicoDbContext>(options =>
    options.UseMySql(mysqlConnectionString, ServerVersion.AutoDetect(mysqlConnectionString)));


// Adição do Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SistemaAcademicoDbContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
