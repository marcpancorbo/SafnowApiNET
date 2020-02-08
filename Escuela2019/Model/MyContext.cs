using Microsoft.EntityFrameworkCore;
namespace Escuela2019.Model
{
    public class MyContext : DbContext
    {
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=SafnowNET; user=safnow;password=safnow;");
        }

    }
}