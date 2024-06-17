using System.Text;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using NitroBoostConsoleService.Core;
using NitroBoostConsoleService.Data;
using NitroBoostConsoleService.Data.Repositories;
using NitroBoostConsoleService.Shared.Interface.Repository;
using NitroBoostConsoleService.Shared.Interface.Service;
using NitroBoostConsoleService.Shared.Logging;
using NitroBoostMessagingClient;
using NitroBoostMessagingClient.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add services
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBaseSender, BaseSender>(options => new BaseSender(args[3]));

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    IConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{args[1]}.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
    var openIdConfig = configurationManager.GetConfigurationAsync(CancellationToken.None).GetAwaiter().GetResult();
    
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKeys = openIdConfig.SigningKeys,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = args[1],
        ValidAudience = args[2],
        ClockSkew = new TimeSpan(0, 0, 5)
    };
    options.Events = new JwtBearerEvents()
    {
        OnAuthenticationFailed = f =>
        {
            Logger.Log(
                $"AUTHENTICATION FAILED\r\nPath: {f.Request.Path}\r\nReason: {f.Exception.Message}\r\nToken: {f.Request.Headers.Authorization}",
                Severity.Warning);
            return Task.CompletedTask;
        }
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (args.Length > 0)
{
    builder.Services.AddEntityFrameworkNpgsql().AddDbContext<NitroboostConsoleContext>(options =>
        options.UseNpgsql(args[0]));
}

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