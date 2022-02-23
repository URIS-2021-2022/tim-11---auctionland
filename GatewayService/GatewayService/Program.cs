using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes("some random key that is now long enough");

builder.Services.AddOcelot();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Configuration.AddJsonFile("ocelot.json");
var app = builder.Build();
IWebHostEnvironment env = app.Environment;
builder.Configuration.AddOcelot("Routes", env);
app.UseAuthentication();
app.UseOcelot();
app.Run();
