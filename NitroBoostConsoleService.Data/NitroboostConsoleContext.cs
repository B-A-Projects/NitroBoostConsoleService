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
}
