using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using Spread.Connect.Api.Admin;
using Spread.Connect.Application.Admin;
using Spread.Connect.Application.Admin.Actions.BrotherhoodUsers.Commands;
using Spread.Connect.Application.Admin.Services;
using Spread.Connect.Domain.Framework.Interfaces;
using Spread.Connect.Domain.Framework.Services;
using Spread.Connect.Domain.Framework.Settings;
using Spread.Connect.Identity.Extensions;
using Spread.Connect.Infrastructure.Persistance.Admin;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var myAllowedOrigin = "_myAllowSpecificOrigins";
builder.Services.AddCors(opttions =>
{
    opttions.AddPolicy(name: myAllowedOrigin, policy =>
    {
        policy.AllowAnyOrigin()
        //policy.WithOrigins("http://localhost:3000", "http://localhost:3000/login")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = false,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
            ValidAudience = builder.Configuration["AuthSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:SigningKey"]))
        };
    });


builder.Services.AddControllers(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Spread Admin API",
        Description = "Spread Admin API",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                                    Enter 'Bearer' [space] and then your token in the text input below.
                                    Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<AdminDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("UserDbContext"));
    if (builder.Environment.IsDevelopment())
    {
        o.EnableDetailedErrors();
        o.EnableSensitiveDataLogging();
    }

});

builder.Services.AddHttpClient();
builder.Services.AddScoped<IAdminDbContext, AdminDbContext>();
//builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddTransient<IS3Service, S3Service>();

builder.Services.AddIdentityContext(options =>
{
    string key = builder.Configuration["AuthSettings:SigningKey"];
    options.SecurityKey = key;
});

builder.Services.AddMediatR(typeof(CreateSpreadUserHandler).GetTypeInfo().Assembly);

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));
//builder.Configure<AwsS3Settings>(Configuration.GetSection("AwsS3Settings"));


//builder.Services.AddHttpClient<INotificationService, NotificationService>(client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["AdminBaseUrl"]);
//});

builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AuthBaseUrl"]);
}).AddPolicyHandler(GetRetryPolicy());

builder.Services.AddHttpClient<INotificationService, NotificationService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["NotificationBaseUrl"]);
}).AddPolicyHandler(GetRetryPolicy());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(myAllowedOrigin);
app.Run();

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(1, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}
