using Microsoft.EntityFrameworkCore;
using conversorDeMonedas.Entities;
using conversorMonedas.Entities;

namespace conversorMonedas.Data
{
    public class ConversorContext : DbContext
    {
        // acá definimos un dbset para cada entidad
        public DbSet<User> Users { get; set; }
        public DbSet<Conversion> Conversions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        // Constructor que recibe las opciones de DbContextOptions
        public ConversorContext(DbContextOptions<ConversorContext> options) : base(options)
        {
        }

        // Este método puede ser utilizado para configuraciones adicionales en el contexto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}