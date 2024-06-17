using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NitroBoostConsoleService.Shared.Dto;

namespace NitroBoostConsoleService.Data.Entities;

public class Device
{
    [Key] 
    [Column("id")] 
    public long Id { get; set; } = 0;
    
    [ForeignKey($"owner_{nameof(User)}")]
    [Column("user_id")]
    public long? UserId { get; set; }

    [Required] 
    [Column("device_id")] 
    public long DeviceId { get; set; } = 0;
    
    [Required]
    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Required] 
    [Column("mac_address")] 
    public string MacAddress { get; set; } = string.Empty;
    
    [Column("device_name")]
    public string? DeviceName { get; set; } = string.Empty;
    
    [Required]
    [Column("created_date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public ICollection<Game> Games { get; set; }

    public Device() {}
    
    public Device(DeviceDto dto)
    {
        Id = dto.Id ?? 0;
        UserId = dto.UserId;
        DeviceId = dto.DeviceId ?? 0;
        Password = dto.Password ?? string.Empty;
        MacAddress = dto.MacAddress ?? string.Empty;
        DeviceName = dto.DeviceName ?? string.Empty;
        CreatedDate = dto.CreatedDate ?? DateTime.Now;
    }

    public DeviceDto ToDeviceDto()
    {
        return new DeviceDto()
        {
            Id = Id,
            CreatedDate = CreatedDate,
            DeviceId = DeviceId,
            DeviceName = DeviceName,
            MacAddress = MacAddress,
            UserId = UserId,
            Password = Password
        };
    }

    public DeviceDto ToSafeDeviceDto()
    {
        return new DeviceDto()
        {
            Id = Id,
            CreatedDate = CreatedDate,
            DeviceName = DeviceName,
            UserId = UserId
        };
    }
}