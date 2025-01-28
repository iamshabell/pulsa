using Core.Interfaces;
using Infrastructure.Services;
using Infrastructure.Serialization;
using Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
var encryptionKey = builder.Configuration["EncryptionKey"];
if (string.IsNullOrEmpty(encryptionKey))
{
    throw new InvalidOperationException("Encryption key is not set in user secrets.");
}

builder.Services.AddSingleton<IEncryptionService>(new EncryptionService(encryptionKey));
builder.Services.AddSingleton<XmlSerializer>();
builder.Services.AddScoped<ProcessAccountRequest>();

var app = builder.Build();

// Configure the HTTP request pipeline
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();