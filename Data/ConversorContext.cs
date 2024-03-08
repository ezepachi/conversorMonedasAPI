using System.Data.Entity;
using conversorDeMonedas.Entities;

namespace conversorMonedas.Data
{
    public class ConversorContext : DbContext //hereda de DbContext para poder usar las funcionalidades de EntityFramework
    {
        public DbSet<User> Users { get; set; }
        public ConversorContext(DbContextOptions<ConversorContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
    }
}
