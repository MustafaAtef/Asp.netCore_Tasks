using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseRouting();

app.MapGet("/countries", async context => {
    Dictionary<int, string> countries = new Dictionary<int, string>() {
        { 1, "United States" },
        { 2, "Canada" },
        { 3, "United Kingdom" },
        { 4, "India" },
        { 5, "Japan" }
    };

    StringBuilder result = new StringBuilder();
    foreach((int key,string value) in countries) {
        result.AppendLine($"{key}, {value}");
    }
    await context.Response.WriteAsync(result.ToString());
});

app.MapGet("/countries/{id}", async context => {
    Dictionary<int, string> countries = new Dictionary<int, string>() {
        { 1, "United States" },
        { 2, "Canada" },
        { 3, "United Kingdom" },
        { 4, "India" },
        { 5, "Japan" }
    };
    if (int.TryParse(Convert.ToString(context.Request.RouteValues["id"]), out int id)) {
        if (countries.ContainsKey(id)) {
            await context.Response.WriteAsync($"{id}, {countries[id]}");
        } else {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid ID");
        }
    } else await context.Response.WriteAsync("ID MUST BE INTEGER");
});
app.UseEndpoints(_=>{  });

app.Run(async context => {
    await context.Response.WriteAsync("NOT HANDLED ROUTE");
});

app.Run();
