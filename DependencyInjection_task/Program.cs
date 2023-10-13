using DependencyInjection_task.ServiceContracts;
using DependencyInjection_task.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IWeatherService, WeatherService>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
