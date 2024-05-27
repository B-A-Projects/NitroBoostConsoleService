using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Shared.Dto
{
    public struct UserDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public long DeviceId { get; set; }
        public string Password { get; set; }
        public string MacAddress { get; set; }
        public string? DeviceName { get; set; }
        public DateTime? CreatedDate { get; set; }
        
        public ICollection<DeviceDto>? Devices { get; set; }
    }
}
