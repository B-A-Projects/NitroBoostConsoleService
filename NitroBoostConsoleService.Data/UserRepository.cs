using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Interface.Repository;
using NitroBoostConsoleService.Data.Entities;
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
        public UserRepository(NitroboostConsoleContext context) : base(context) { }
        public IEnumerable<UserDto> FindUsers(Expression<Func<UserDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        UserDto? IUserRepository.AddUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        UserDto? IUserRepository.GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
