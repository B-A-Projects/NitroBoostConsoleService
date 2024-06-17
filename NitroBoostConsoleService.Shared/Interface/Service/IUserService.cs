using NitroBoostConsoleService.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Shared.Interface.Service
{
    public interface IUserService
    {
        Task<UserDto?> GetUserById(long userId);
        Task<UserDto?> GetUserByEmail(string email);
        Task<UserDto?> AddUser(string email);
        Task<UserDto?> UpdateNickname(string email, string nickname);
        Task DeleteUser(string email);
    }
}
