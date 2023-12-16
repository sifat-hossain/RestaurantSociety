using MediatR;
using Polly;
using Polly.Extensions.Http;

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



builder.Services.AddHttpClient();


builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddIdentityContext(options =>
{
    string key = builder.Configuration["AuthSettings:SigningKey"];
    options.SecurityKey = key;
});

// Register PaymentHistoryHandler and its dependencies
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