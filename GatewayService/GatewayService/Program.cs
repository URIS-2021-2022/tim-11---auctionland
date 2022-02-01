using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot();
builder.Configuration.AddJsonFile("ocelot.json");
var app = builder.Build();
app.UseOcelot();
app.MapGet("/", () => "Hello World!");

app.Run();
