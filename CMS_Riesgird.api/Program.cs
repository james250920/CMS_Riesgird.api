using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Core.Infrastructure.Middleware;
using CMS_Riesgird.Core.Infrastructure.Repositories;
using CMS_Riesgird.Core.Infrastructure.Shared;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obtener configuración
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// DbContext PostgreSQL
builder.Services.AddDbContext<RiesgirdDbContext>(options =>
    options.UseNpgsql(connectionString));

// Controllers
builder.Services.AddControllers();

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shared Infrastructure (JWT Settings, Authentication, IJWTService)
builder.Services.AddSharedInfrastructure(configuration);

// ---------------- DEPENDENCY INJECTION ----------------

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();

// ------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
