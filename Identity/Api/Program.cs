using System.Data;

using Api.Extensions;
using Api.Filters;
using Api.Middlewares;
using Application.Commands.CreateUser;

using Application.Services.AuthService;
using Application.Services.AuthService.Validators;
using Application.Services.CodeService;
using Application.Services.EmailService;
using Application.Services.JWTService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog.Web;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "Api.xml");
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddTransient<IStartupFilter,DomainExceptionStartupFilter>();
builder.Services.AddValidatorsFromAssemblyContaining<RegistrationValidator>();
builder.Services.AddScoped<IDbConnection, NpgsqlConnection>();
builder.Services.AddFluentRunner(builder.Configuration);
builder.Services.AddMediatR(ctf => ctf.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<ICodeService, CodeService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.RemoveAll<ILoggerProvider>();
builder.Host.UseNLog();
var app = builder.Build();
app.UseFluentMigrator();
app.UseMiddleware<DBMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.MapControllers();

app.Run();