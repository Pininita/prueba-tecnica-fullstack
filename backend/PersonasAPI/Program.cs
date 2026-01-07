using FluentValidation;
using MediatR;
using PersonasAPI.Repositories;
using PersonasAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS para permitir acceso desde React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Registrar MediatR (v11-compatible registration)
builder.Services.AddMediatR(typeof(Program).Assembly);

// Registrar Repository (Singleton para mantener datos en memoria)
builder.Services.AddSingleton<IPersonaRepository, PersonaRepository>();

// Registrar FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreatePersonaValidator>();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.Run();