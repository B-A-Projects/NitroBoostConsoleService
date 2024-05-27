using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NitroBoostConsoleService.Shared.Dto;

namespace NitroBoostConsoleService.Data.Entities;

public class Friend()
{
    [Key] 
    [Column("id")] 
    public long Id { get; set; } = 0;

    [Required]
    [ForeignKey($"sender_{nameof(Game)}")]
    [Column("sender_id")]
    public long SenderId { get; set; } = 0;

    [Required]
    [ForeignKey($"recipient_{nameof(Game)}")]
    [Column("recipient_id")]
    public long RecipientId { get; set; } = 0;
    
    // 0 => Sent, 1 => Accepted, 2 => Completed
    [Required] 
    [Column("status")] 
    public int Status { get; set; } = 0;

    [Required] 
    [Column("created_date")] 
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public Friend(FriendDto dto) : this()
    {
        
    }

    public FriendDto ToDto() => new FriendDto()
    {
        FriendId = Id,
        CreatedDate = CreatedDate,
        SenderId = SenderId,
        RecipientId = RecipientId,
        Status = Status
    };
}