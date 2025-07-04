using Resilience_InActionWithPolly.Resilience;
using Resilience_InActionWithPolly.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("ExternalApi", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
}).AddPolicyHandler(PollyPolicies.GetRetryPolicy())
  .AddPolicyHandler(PollyPolicies.GetCircuitBreakerPolicy())
  .AddPolicyHandler(PollyPolicies.GetTimeoutPolicy())
  .AddPolicyHandler(PollyPolicies.GetFallbackPolicy())
  .AddPolicyHandler(PollyPolicies.GetBulkheadPolicy());

builder.Services.AddScoped<ExternalApiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
