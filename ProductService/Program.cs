using System.Reflection;
using ProductService.Extensions;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;
IConfiguration configuration = builder.Configuration;
var environment = builder.Environment;

services.AddControllers();
services.ConfigureDependencyInjection(configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS security
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://securitycors.com")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole(); 
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//HTTPS enforcement security
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

