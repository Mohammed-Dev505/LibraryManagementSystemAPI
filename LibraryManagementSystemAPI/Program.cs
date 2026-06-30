
using Infrastructure.Data;
using LibraryManagementSystemAPI.Application.Extensions;
using LibraryManagementSystemAPI.Application.Models;
using LibraryManagementSystemAPI.Domain.Entities;
using LibraryManagementSystemAPI.Extensions;
using LibraryManagementSystemAPI.Infrastructure.Extensions;
using LibraryManagementSystemAPI.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExtenion();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));


// Õﬁ‰ Œœ„«  ÿ»ﬁ… «· Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);

// Õﬁ‰ Œœ„«  ÿ»ﬁ… «·  Application
builder.Services.AddApplicationService();
builder.Services.AddValidationServices();

// Õﬁ‰ «·Œœ„«  «·Œ«’… »  API Ê«·Ê”Ìÿ
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddTransient<ExceptionMiddleware>();
var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    await ContextSeed.SeedRolesAsync(roleManager);
    await ContextSeed.CreateAdmin(userManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
