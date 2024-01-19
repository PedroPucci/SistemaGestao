using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaGestãoColaboradoresUnidades.Repository;
using SistemaGestãoColaboradoresUnidades.Repository.Repository;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Service;
using SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddScoped<IRepositoryUoW, RepositoryUoW>();
builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

IMapper mapper = new Mappers().Configuration().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<IRepositoryUoW, RepositoryUoW>();
builder.Services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sistema de Gestão de Colaboradores e Unidades",
        Description = "[RTE] - Avaliação técnica / Pedro Ighor Holanda Pucci",
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "development",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});
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