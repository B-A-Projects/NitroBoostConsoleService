namespace NitroBoostConsoleService.Shared.Dto;

public class DeviceDto
{
    public long? Id { get; set; }
    public long? UserId { get; set; }
    public long? DeviceId { get; set; }
    public string? Password { get; set; }
    public string? MacAddress { get; set; }
    public string? DeviceName { get; set; }
    public DateTime? CreatedDate { get; set; }
    
    public ICollection<GameDto>? Games { get; set; }
}