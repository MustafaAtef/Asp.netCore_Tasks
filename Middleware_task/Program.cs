using Middleware_task.CustomMiddlewares;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseCustomLogin();

app.Run();
