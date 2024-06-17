namespace NitroBoostConsoleService.Shared.Dto;

public class FriendDto
{
    public long? FriendId { get; set; }
    public long? SenderId { get; set; }
    public long? RecipientId { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; }
}