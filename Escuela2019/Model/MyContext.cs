using Microsoft.EntityFrameworkCore;

namespace Safnow.Model
{
    public class MyContext : DbContext
    {
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<VerificationCode> Codes { get; set; }
        public DbSet<Ubication> Ubications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=safnownet;Uid=safnow;Pwd=safnow;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(u => u.PhoneNumber).IsUnique();
            modelBuilder.Entity<Usuario>().HasMany(u => u.Alertas).WithOne(a => a.Usuario)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Alerta>().HasMany(a => a.Ubications).WithOne(u => u.Alert)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder); 
            
        }
    }
}