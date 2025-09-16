using Application;
using Application.Moduels.Common.MiddleWare;
using DotNetEnv;
using Infrastructure;
using Infrastructure.ADbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineStorApi.Confige;
using Shared.Config;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtOptions>>().Value);
// Auth 
builder.Services.JwtConfige(jwtOptions);



builder.LoggConfig();
builder.StripConfige();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionHandling();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();