using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineFoodDelivery.Auth;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Repository;
using OnlineFoodDelivery.Service;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserLoginContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserLoginContext") ?? throw new InvalidOperationException("Connection string 'UserLoginContext' not found.")));

// Add  user services to the container.

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.(middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();//do these 
app.UseAuthentication();
app.UseAuthorization();
//we can create our own middlewares to handle exceptions
//cross origin resource sharing to map other urls
app.MapControllers();//to handle end points
app.Run();//termination
