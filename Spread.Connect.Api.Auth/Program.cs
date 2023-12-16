using MediatR;
using Microsoft.EntityFrameworkCore;
using Spread.Connect.Api.Auth;
using Spread.Connect.Application.Auth;
using Spread.Connect.Application.Auth.Actions.Users.Commands.LoginUser;
using Spread.Connect.Domain;
using Spread.Connect.Domain.Framework.Interfaces;
using Spread.Connect.Domain.Framework.Services;
using Spread.Connect.Domain.Framework.Settings;
using Spread.Connect.Identity.Extensions;
using Spread.Connect.Infrastructure.Persistance.Admin;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
//{
//    builder.WithOrigins("http").AllowAnyMethod().AllowAnyHeader();
//}));
var myAllowedOrigin = "_myAllowSpecificOrigins";
builder.Services.AddCors(opttions =>
{
    opttions.AddPolicy(name: myAllowedOrigin, policy =>
    {
        policy.AllowAnyOrigin()
        //policy.WithOrigins("http://localhost:3000", "http://localhost:3000/login", "*")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(LoginUserHandler).GetTypeInfo().Assembly);
//Add appsettings json configuration sources to builder

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Services.AddControllers(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AdminDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("UserDbContext"));
    if (builder.Environment.IsDevelopment())
    {
        o.EnableDetailedErrors();
        o.EnableSensitiveDataLogging();
    }
});
builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddSingleton<IDateTime, PlatformDateTime>();
builder.Services.AddScoped<IAuthDbContext, AdminDbContext>();

builder.Services.AddIdentityContext(options =>
{
    string key = builder.Configuration["AuthSettings:SigningKey"];
    options.SecurityKey = key;
});


builder.Services.AddMediatR(typeof(LoginUserHandler).GetTypeInfo().Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseCors(myAllowedOrigin);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();