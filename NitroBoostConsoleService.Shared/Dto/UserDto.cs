using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Shared.Dto
{
    public struct UserDto
    {
        public long? Id { get; set; }
        public long? FavouriteGameId { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public ICollection<DeviceDto>? Devices { get; set; }
        
        public UserDto() {}

        public UserDto(string email)
        {
            Email = email;
            Nickname = "Default";
            CreatedDate = DateTime.Now;
        }
    }
}
