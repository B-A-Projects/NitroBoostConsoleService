// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using NitroBoostConsoleService.Data;
using NitroBoostConsoleService.Messaging;
using NitroBoostConsoleService.Shared.Configuration;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostMessagingClient;

var connectionString = args[0] ?? "Host=localhost;User=Postgres;Password=admin;";
var host = args[1] ?? "localhost";
var queue = args[2] ?? "default";
var authenticationConfiguration = new AuthenticationConfiguration()
{
    ClientId = args[3],
    ClientSecret = args[4],
    Audience = args[5],
    GrantType = args[6]
};
var helper = new TokenHelper(args[7], args[8]);

TokenDto.Configuration = authenticationConfiguration;
TokenDto.RefreshUrl = $"{authenticationConfiguration.Audience.Replace("api/v2", "oauth/token")}";
TokenDto.GetToken();


var context = new NitroboostConsoleContext(
    new DbContextOptionsBuilder<NitroboostConsoleContext>().UseNpgsql(connectionString).Options);
var processor = new MessageProcessor(context, authenticationConfiguration, helper);
var consumer = new BaseReceiver(processor, host, queue);

consumer.StartReceiving();
Console.ReadLine();
consumer.StopReceiving();
