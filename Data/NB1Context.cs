using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data
{
    public class NB1Context : DbContext
    {
        public NB1Context(DbContextOptions<NB1Context> opt) : base(opt)
        {

        }

        public NB1Context()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\NB1DB.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>(entity =>
            {
                entity
                .HasOne(player => player.Club)
                .WithMany(club => club.Players)
                .HasForeignKey(player => player.ClubID);
            });
            modelBuilder.Entity<Manager>(entity =>
            {
                entity
                .HasOne(manager => manager.Club)
                .WithOne(club => club.Manager)
                .HasForeignKey<Manager>(manager => manager.ClubID);
            });
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}