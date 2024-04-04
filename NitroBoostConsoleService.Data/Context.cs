using NitroBoostConsoleService.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Data
{
    public class Context : DbContext
    {
        DbSet<User> Users { get; set; }

        public Context() : base() { }

        //protected override void OnModelCreating(ModelBuilder Builder)
        //{
        //    Builder.Entity<User>()
        //        .HasKey(x => x.UserId);
        //}
    }
}
