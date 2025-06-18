using CadastroHeroisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroHeroisAPI.Data
{
    public class AppDbContext : DbContext         
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroisSuperpoderesModel>()
                .HasKey(hs => new { hs.HeroisId, hs.SuperpoderesId });
        }

        public DbSet<HeroisModel> Herois { get; set; }
        public DbSet<HeroisSuperpoderesModel> HeroisSuperpoderes { get; set; }
        public DbSet<SuperpoderesModel> Superpoderes { get; set; }

    }
}
