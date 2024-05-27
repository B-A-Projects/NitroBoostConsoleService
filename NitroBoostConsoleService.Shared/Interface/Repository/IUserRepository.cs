using NitroBoostConsoleService.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Shared.Interface.Repository
{
    public interface IUserRepository
    {
        UserDto?GetUser(int userId);
        UserDto? AddUser(UserDto user);
        IEnumerable<UserDto> FindUsers(Expression<Func<UserDto, bool>> predicate);
    }
}
