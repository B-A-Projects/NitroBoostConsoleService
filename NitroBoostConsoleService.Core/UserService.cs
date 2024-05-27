using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Interface.Repository;
using NitroBoostConsoleService.Shared.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Core
{
    public class UserService : IUserService
    {
        private IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository) => _UserRepository = UserRepository;

        public UserDto? AddUser(UserDto User)
        {
            throw new NotImplementedException();
        }

        public UserDto? GetUser(int UserId) => _UserRepository.GetUser(UserId);
    }
}
