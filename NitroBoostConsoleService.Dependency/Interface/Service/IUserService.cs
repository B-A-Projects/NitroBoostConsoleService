using NitroBoostConsoleService.Dependency.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Dependency.Interface.Service
{
    public interface IUserService
    {
        UserDTO? GetUser(int userId);
        UserDTO? AddUser(UserDTO user);
    }
}
