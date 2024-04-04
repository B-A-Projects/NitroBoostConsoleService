using NitroBoostConsoleService.Dependency.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Dependency.Interface.Repository
{
    public interface IUserRepository
    {
        UserDTO?GetUser(int userId);
        UserDTO? AddUser(UserDTO user);
        IEnumerable<UserDTO> FindUsers(Expression<Func<UserDTO, bool>> predicate);
    }
}
