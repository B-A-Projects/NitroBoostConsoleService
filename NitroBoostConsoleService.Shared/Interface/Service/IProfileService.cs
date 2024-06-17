using NitroBoostConsoleService.Shared.Dto;

namespace NitroBoostConsoleService.Shared.Interface.Service;

public interface IProfileService
{
    Task DeleteUserInformation(string email);
}