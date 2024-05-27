using System.Text;
using Microsoft.EntityFrameworkCore;
using NitroBoostConsoleService.Core;
using NitroBoostConsoleService.Data;
using NitroBoostConsoleService.Data.Repositories;
using NitroBoostConsoleService.Shared.Interface.Repository;
using NitroBoostConsoleService.Shared.Interface.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (args.Length > 0)
{
    builder.Services.AddEntityFrameworkNpgsql().AddDbContext<NitroboostConsoleContext>(options =>
        options.UseNpgsql(args[0]));
}

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = args[2],
            ValidAudience = args[3],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(args[1]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
