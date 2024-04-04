using NitroBoostConsoleService.Dependency.DTO;
using NitroBoostConsoleService.Dependency.Interface.Repository;
using NitroBoostConsoleService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }
        public IEnumerable<UserDTO> FindUsers(Expression<Func<UserDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        UserDTO? IUserRepository.AddUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        UserDTO? IUserRepository.GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
