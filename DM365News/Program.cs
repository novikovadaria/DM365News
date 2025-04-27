using DM365News.Extensions;
using DM365News.Interfaces;
using DM365News.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Используем метод расширения для регистрации сервисов
builder.Services.ConfigureServices();

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
