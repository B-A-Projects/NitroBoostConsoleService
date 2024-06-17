using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NitroBoostConsoleService.Shared.Dto;

namespace NitroBoostConsoleService.Data.Entities;

public class Game
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [ForeignKey($"owner_{nameof(Device)}")]
    [Column("device_id")]
    public long DeviceId { get; set; }
    
    [Required]
    [Column("gamecode")]
    public string GameCode { get; set; }
    
    [Required]
    [Column("gsbrcd")]
    public string Gsbrcd { get; set; }
    
    [Required]
    [Column("player_id")]
    public int PlayerId { get; set; }
    

    [Column("first_name")]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    public string LastName { get; set; }
    
    [Required]
    [Column("email")]
    public string Email { get; set; }
    
    [Required]
    [Column("nickname")]
    public string Nickname { get; set; }
    
    [Required]
    [Column("unique_nickname")]
    public string UniqueNickname { get; set; }
    
    [Column("zipcode")]
    public string Zipcode { get; set; }
    
    [Column("aim")]
    public string Aim { get; set; }
    
    
    [Required]
    [Column("signature")]
    public string Signature { get; set; }
    
    [Required]
    [Column("longnitude")]
    public float Longnitude { get; set; }
    
    [Required]
    [Column("lattitude")]
    public float Lattitude { get; set; }
    
    [Required]
    [Column("location")]
    public string Location { get; set; }

    
    public ICollection<Friend> Friends { get; set; }

    public Game() {}
    
    public Game(GameDto dto)
    {
        
    }

    public GameDto ToDto()
    {
        return new GameDto();
    }
}