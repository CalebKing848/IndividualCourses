using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SecurityApp.API.Authorization;
using System.Data.SqlClient;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuthorizationHandler, ManagerAuthorizationHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
});

//Configure Claims-based Authorization 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdminOnly", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Admin");
        policy.RequireClaim("YearsOfExperience", "10");
        policy.RequireClaim("JoinedCompany", "2020");
    });

    options.AddPolicy("HiringManager", policy =>
    {
        policy.AddRequirements(new SameManagerRequirement());
    });
});

//Add CORS
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//User Cors
app.UseCors(options => options.WithOrigins("https://example.com")
.AllowAnyHeader()
.AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
