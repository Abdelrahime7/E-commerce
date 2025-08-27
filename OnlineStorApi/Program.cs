using Application;
using Application.Moduels.Common.MiddleWare;
using DotNetEnv;
using Infrastructure;
using Infrastructure.ADbContext;
using Microsoft.EntityFrameworkCore;
using OnlineStorApi.Confige;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(O => O.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
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

app.MapControllers();

app.Run();