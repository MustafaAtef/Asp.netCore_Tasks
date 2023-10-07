using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace Middleware_task.CustomMiddlewares {
    public class LoginMiddleware {
        private RequestDelegate _next;
        public LoginMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            if (context.Request.Method == "POST") {
                string query =await (new StreamReader(context.Request.Body)).ReadToEndAsync();
                Dictionary<string, StringValues> queryString = QueryHelpers.ParseQuery(query);
                StringBuilder errors = new StringBuilder();
                if (!queryString.ContainsKey("email")) errors.AppendLine("Invalid input for 'email'");
                if (!queryString.ContainsKey("password")) errors.AppendLine("Invalid input for 'password'");
                if (errors.Length != 0) {
                    await context.Response.WriteAsync(errors.ToString());
                }
                else {
                    string email = queryString["email"][0];
                    string password = queryString["password"][0];

                    if (email == "admin@example.com" && password == "admin1234") {
                        await context.Response.WriteAsync("Successful login");
                    } else {
                        await context.Response.WriteAsync("Invalid login");
                    }
                }
            } else {
                await context.Response.WriteAsync("<h1>NOT SUPPORTED RIGHT NOW</h1>");
            }
        }
    }
}
