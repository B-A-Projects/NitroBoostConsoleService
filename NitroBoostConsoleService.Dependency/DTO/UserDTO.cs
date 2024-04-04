using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Dependency.DTO
{
    public struct UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Validated { get; set; }
    }
}
