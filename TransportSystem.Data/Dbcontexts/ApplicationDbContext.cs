using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportSystem.Data.DbModels;
using TransportSystem.Data.Entities;

namespace TransportSystem.Data.Dbcontexts
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<DepartingTerminal> DepartingTerminal { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Bus> Buses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bus>().HasOne(b => b.Terminal)
                .WithMany(b => b.Bus).OnDelete(DeleteBehavior.ClientCascade);
            base.OnModelCreating(builder);

            builder.Entity<Bus>().HasOne(b => b.DepartingTerminal)
                .WithMany(b => b.Bus).OnDelete(DeleteBehavior.ClientCascade);
            base.OnModelCreating(builder);

            builder.Entity<Seat>().HasOne(b => b.Bus).WithMany(b => b.Seat).HasForeignKey("BusId");
        }

    }
}
