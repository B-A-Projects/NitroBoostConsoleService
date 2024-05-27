namespace NitroBoostConsoleService.Shared.Dto;

public class GameDto
{
    public int? GameProfileId { get; set; }
    public int? DeviceId { get; set; }
    public string GameCode { get; set; }
    public string? Gsbrcd { get; set; }
    public int PlayerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string Nickname { get; set; }
    public string UniqueNickname { get; set; }
    public string? Zipcode { get; set; }
    public string? Aim { get; set; }
    
    public string? Signature { get; set; }
    public float? Longnitude { get; set; }
    public float? Lattitude { get; set; }
    public string? Location { get; set; }

    
    public ICollection<FriendDto>? Friends { get; set; }
}