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
        UserDto? GetUser(int userId);
        UserDto? AddUser(UserDto user);
    }
}
