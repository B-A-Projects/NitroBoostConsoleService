using NitroBoostConsoleService.Dependency.DTO;
using NitroBoostConsoleService.Dependency.Interface.Repository;
using NitroBoostConsoleService.Dependency.Interface.Service;
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

        public UserDTO? AddUser(UserDTO User)
        {
            throw new NotImplementedException();
        }

        public UserDTO? GetUser(int UserId) => _UserRepository.GetUser(UserId);
    }
}
