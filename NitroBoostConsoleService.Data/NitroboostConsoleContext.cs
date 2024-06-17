using Microsoft.EntityFrameworkCore;
using NitroBoostConsoleService.Data.Entities;

namespace NitroBoostConsoleService.Data;

public class NitroboostConsoleContext : DbContext
{
    private DbSet<User> Users { get; set; } 
    private DbSet<Device> Devices { get; set; }
    private DbSet<Game> Games { get; set; }
    private DbSet<Friend> Friends { get; set; }
    
    public NitroboostConsoleContext()
    {
    }

    public NitroboostConsoleContext(DbContextOptions<NitroboostConsoleContext> options)
        : base(options)
    {
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql("Host=localhost;Database=nitroboost-console;Username=blurrito;Password=YCR-200400;");
    //     //optionsBuilder.UseNpgsql("Host=35.234.101.141;Port=5432;Database=console-database;Username=postgres;Password=YCR-200400;");
    // }
}
