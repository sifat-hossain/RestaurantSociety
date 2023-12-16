using MediatR;
using Restaurant.Society.Application.Notification.Actions.Email.Command.TestMail;
using Restaurant.Society.Application.Notification.Interfaces;
using Restaurant.Society.Infrastructure.Services.Notification.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddMediatR(typeof(EmailSenderHandler).GetTypeInfo().Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
