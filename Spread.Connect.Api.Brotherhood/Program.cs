using MediatR;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Extensions.Http;
using Spread.Connect.Application.Brotherhood;
using Spread.Connect.Application.Brotherhood.Actions.RegisterPayments;
using Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreatePaymentHistory;
using Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreateRegisterPayment;
using Spread.Connect.Application.Brotherhood.Services;
using Spread.Connect.Identity.Extensions;
using Spread.Connect.Infrastructure.Persistance.Brotherhood;
using INotification = Spread.Connect.Application.Brotherhood.Services.INotification;



var builder = WebApplication.CreateBuilder(args);
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
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: myAllowedOrigin, policy =>
//    {
//        policy.WithOrigins("https://spread-brotherhood-frontend-staging.netlify.app/landing")
//       .AllowAnyHeader()
//       .AllowAnyMethod()

//    });
//});


builder.Services.AddDbContext<BrotherhoodDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("BrotherhoodDbContext"));
    if (builder.Environment.IsDevelopment())
    {
        o.EnableDetailedErrors();
        o.EnableSensitiveDataLogging();
    }
});
builder.Services.AddHttpClient();

builder.Services.AddTransient<IBrotherhoodDbContext, BrotherhoodDbContext>();

builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddTransient<IRequestHandler<RegisterPaymentCommand, RegisterPaymentModel>, RegisterPaymentHandler>();
builder.Services.AddTransient<IRequestHandler<PaymentHistoryCommand, PaymentHistoryModel>, PaymentHistoryHandler>();

builder.Services.AddIdentityContext(options =>
{
    string key = builder.Configuration["AuthSettings:SigningKey"];
    options.SecurityKey = key;
});
builder.Services.AddHttpClient<INotification, NotificationService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["NotificationBaseUrl"]);
}).AddPolicyHandler(GetRetryPolicy());

// Register PaymentHistoryHandler and its dependencies
builder.Services.AddTransient<IRequestHandler<PaymentHistoryCommand, PaymentHistoryModel>, PaymentHistoryHandler>();
//builder.Services.AddMediatR(typeof(RegisterPaymentHandler).GetTypeInfo().Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.UseCors(myAllowedOrigin);
app.Run();
static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(1, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}