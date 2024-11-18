using Microsoft.EntityFrameworkCore;
using conversorMonedas.Entities;

namespace conversorMonedas.Data
{
    public class ConversorContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Conversion> Conversions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<FavoriteCurrency> FavoriteCurrencies { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public ConversorContext(DbContextOptions<ConversorContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Code = "USD", Legend = "Dólar Americano", Symbol = "$", ConvertibilityIndex = 1 },
                new Currency { Id = 2, Code = "ARS", Legend = "Peso Argentino", Symbol = "$", ConvertibilityIndex = 0.002m },
                new Currency { Id = 3, Code = "EUR", Legend = "Euro", Symbol = "€", ConvertibilityIndex = 1.09m }
            );
            
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { Id = 1, Type = "Free", ConversionLimit = 10, ExpirationDate = DateTime.UtcNow.AddMonths(1), UserId = 1 },
                new Subscription { Id = 2, Type = "Premium", ConversionLimit = -1, ExpirationDate = DateTime.UtcNow.AddYears(1), UserId = 2 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "user1", Firstname = "John", Lastname = "Doe", Email = "john@example.com", Password = "123456", SubscriptionId = 1 },
                new User { Id = 2, Username = "user2", Firstname = "Jane", Lastname = "Smith", Email = "jane@example.com", Password = "654321", SubscriptionId = 2 }
            );
            
            
            // Relaciones
            modelBuilder.Entity<User>()
                .HasOne(u => u.Subscription)
                .WithOne(s => s.User)
                .HasForeignKey<Subscription>(s => s.UserId);

            modelBuilder.Entity<Conversion>()
                .HasOne(c => c.User)
                .WithMany(u => u.Conversions)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<FavoriteCurrency>()
                .HasOne(fc => fc.User)
                .WithMany(u => u.FavoriteCurrencies)
                .HasForeignKey(fc => fc.UserId);

            modelBuilder.Entity<FavoriteCurrency>()
                .HasOne(fc => fc.Currency)
                .WithMany()
                .HasForeignKey(fc => fc.CurrencyId);

            base.OnModelCreating(modelBuilder);
            }
        }
    }
    


    