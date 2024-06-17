using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NitroBoostConsoleService.Shared.Dto;

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
        
    [Required]
    [Column("email")]
    public string Email { get; set; }

    [Column("birth_date")]
    public DateTime? Birthdate { get; set; }
    
    [Required]
    [Column("show_birth_date")]
    public bool ShowBirthdate { get; set; } = false;
    
    [Required]
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    
    public ICollection<Device> Devices { get; set; }
    
    public User() {}

    public User(UserDto dto)
    {
        FavouriteGameId = dto.FavouriteGameId;
        Nickname = dto.Nickname;
        Email = dto.Email;
        Birthdate = dto.BirthDate;
        ShowBirthdate = false;
        CreatedDate = DateTime.Now;
    }

    public UserDto ToDto() => new UserDto()
    {
        BirthDate = ShowBirthdate ? Birthdate : null,
        CreatedDate = CreatedDate,
        Email = Email,
        FavouriteGameId = FavouriteGameId,
        Id = Id,
        Nickname = Nickname
    };
}
