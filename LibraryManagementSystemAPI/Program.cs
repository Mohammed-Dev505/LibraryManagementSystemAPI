using LibraryManagementSystemAPI.Data.Models;
using LibraryManagementSystemAPI.Middleware;
using LibraryManagementSystemAPI.Services.Implementaions;
using LibraryManagementSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Trining_RESTApi.Data;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.Mapping;
using Trining_RESTApi.Services.Implementaions;
using Trining_RESTApi.Services.Interfaces;
using FluentValidation.AspNetCore;
using FluentValidation;
using LibraryManagementSystemAPI.Validators;
using LibraryManagementSystemAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add FluentValidation
builder.Services.AddValidationServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));


// Add DbContxt
builder.Services.AddDatabase(builder.Configuration);

// Add Identity
builder.Services.AddIdentityService();

// Add Mapping
builder.Services.AddAutoMapper(typeof(UserProfile));

// Add Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// Add Services
builder.Services.AddApplicationService();
var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = { "Admin", "User" };
    foreach(var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalException();

app.UseHttpsRedirection();

app.UseSecurity();

app.MapControllers();

app.Run();
