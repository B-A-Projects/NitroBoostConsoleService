using System.Text.RegularExpressions;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Exceptions;
using NitroBoostConsoleService.Shared.Interface.Repository;
using NitroBoostConsoleService.Shared.Interface.Service;

namespace NitroBoostConsoleService.Core;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private IDeviceRepository _deviceRepository;

    public UserService(IUserRepository userRepository, IDeviceRepository deviceRepository)
    {
        _userRepository = userRepository;
        _deviceRepository = deviceRepository;
    }

    public async Task<UserDto?> GetUserById(long userId)
    {
        if (userId < 1)
            throw new NotFoundException($"User record with user ID {userId} was not found.");
        return await _userRepository.GetUserById(userId);
    }
    
    public async Task<UserDto?> GetUserByEmail(string email)
    {
        if (email.Length < 6 && !email.Contains('@'))
            throw new InvalidDataException($"Provided email ${email} is invalid.");
        return await _userRepository.GetUserByEmail(email) ?? throw new NotFoundException(
            $"User record with email address {email} was not found.");
    }

    public async Task<UserDto?> AddUser(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user != null)
            throw new System.Data.DuplicateNameException(
                $"Attempted to register user using taken email address ${email}.");
        return await _userRepository.AddUser(new UserDto(email), email);
    }

    public async Task<UserDto?> UpdateNickname(string email, string nickname)
    {
        var filteredNickname = ValidateUsername(nickname);
        return await _userRepository.UpdateNickname(email, filteredNickname);
    }

    public async Task DeleteUser(string email)
    {
        UserDto? user = await _userRepository.GetUserByEmail(email);
        if (user == null)
            return;

        await _deviceRepository.UnlinkDevices(user.Value.Id.Value);
        await _userRepository.DeleteUser(email);
    }

    private string ValidateUsername(string username)
    {
        var trimmedUsername = Regex.Replace(username, @"[^A-z0-9\-]", "");
        if (trimmedUsername.Length <= 0)
            throw new InvalidDataException(
                $"Username value of {username} results in empty string after removing forbidden characters.");
        
        if (trimmedUsername.Length > 50)
            trimmedUsername = trimmedUsername.Remove(50);
        return trimmedUsername;
    }
}
