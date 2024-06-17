using System.Text.Json;
using NitroBoostConsoleService.Core;
using NitroBoostConsoleService.Data;
using NitroBoostConsoleService.Data.Repositories;
using NitroBoostConsoleService.Messaging.Messages;
using NitroBoostConsoleService.Shared.Configuration;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Exceptions;
using NitroBoostConsoleService.Shared.Interface.Service;
using NitroBoostConsoleService.Shared.Logging;
using NitroBoostMessagingClient.Dtos;
using NitroBoostMessagingClient.Enums;
using NitroBoostMessagingClient.Interfaces;

namespace NitroBoostConsoleService.Messaging;

public class MessageProcessor : IMessageProcessor
{
    private NitroboostConsoleContext _context;
    private AuthenticationConfiguration _configuration;
    private TokenHelper _helper;
    
    public MessageProcessor(NitroboostConsoleContext context, AuthenticationConfiguration configuration, TokenHelper helper)
    {
        _context = context;
        _configuration = configuration;
        _helper = helper;
    }

public async Task ProcessMessage(MessageDto message)
    {
        try
        {
            if (!_helper.ValidateSender(message.Token, message.Sender))
                throw new NotAllowedException(
                    $"UNAUTHORIZED ACCESS\r\nReason: Current user is not allowed to access information of user with email address {message.Sender}.\r\nToken: {message.Token}");

            var messageBody = JsonSerializer.Deserialize<ConsoleMessage>(message.Body);
            switch (messageBody.Type)
            {
                case RequestType.User:
                    await ProcessUserRequest(message.Action, message.Sender, messageBody);
                    break;
                case RequestType.Profile:
                    await ProcessProfileRequest(message.Action, messageBody);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        catch (NotFoundException e)
        {
            Logger.Log(e.ToString(), Severity.Info);
        }
        catch (InvalidDataException e)
        {
            Logger.Log(e.ToString(), Severity.Warning);
        }
        catch (NotAllowedException e)
        {
            Logger.Log(e.ToString(), Severity.Warning);
        }
        catch (Exception e)
        {
            Logger.Log(e.ToString(), Severity.Error);
            throw;
        }
    }

    private async Task ProcessUserRequest(ActionType action, string sender, ConsoleMessage message)
    {
        switch (action)
        {
            case ActionType.Add:
                await GetUserService().AddUser(sender);
                break;
            case ActionType.Update:
                await GetUserService().UpdateNickname(sender, message.Body);
                break;
            case ActionType.Delete:
                await GetUserService().DeleteUser(sender);
                break;
            default:
                throw new NotImplementedException();
        }
    }
    
    private async Task ProcessProfileRequest(ActionType action, ConsoleMessage message)
    {
        switch (action)
        {
            case ActionType.Delete:
                await GetProfileService().DeleteUserInformation(message.Body);
                break;
                default:
                throw new NotImplementedException();
        }
    }

    private IProfileService GetProfileService() => 
        new ProfileService(GetUserService(), _configuration, TokenDto.GetToken());

    private IUserService GetUserService() =>
        new UserService(new UserRepository(_context), new DeviceRepository(_context));
}

public class ConsoleMessage
{
    public RequestType Type { get; set; }
    public string Body { get; set; }
}

public enum RequestType
{
    User = 0,
    Profile = 1
}