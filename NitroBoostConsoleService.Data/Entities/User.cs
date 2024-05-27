using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NitroBoostConsoleService.Data.Entities;

public class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [ForeignKey($"favourite_{nameof(Game)}")]
    [Column("favourite_game_id")]
    public long? FavouriteGameId { get; set; }

    [Required]
    [Column("nickname")]
    public string Nickname { get; set; } = string.Empty;
        
    // [Required]
    // [Column("unique_nickname")]
    // public string UniqueNickname { get; set; } = string.Empty;
    //     
    // [Required]
    // [Column("email")]
    // public string Email { get; set; } = string.Empty;
    //     
    // [Required]
    // [Column("password")]
    // public string Password { get; set; } = string.Empty;

    [Column("birth_date")]
    public DateTime? Birthdate { get; set; }
    
    [Required]
    [Column("show_birth_date")]
    public bool ShowBirthdate { get; set; } = false;

    [Required]
    [Column("validated")]
    public bool Validated { get; set; } = false;
    
    public ICollection<Device> Devices { get; set; }
}
