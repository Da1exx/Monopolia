using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRating
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Rating> Ratings => Set<Rating>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>(
                b =>
                {
                    b.HasKey("Id");
                    b.Property(b => b.PlayerName);
                    b.Property(b => b.PlayerMoney);
                    b.Property(b => b.Tern);

                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer("server=localhost;database=Rating;Integrated Security=true");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка подключения к базе данных " + e.Data);
                Environment.Exit(1);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
        }
    }
}
