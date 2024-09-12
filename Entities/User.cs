using ConversorDeMonedasBack.Data.Models.Enum;
using conversorMonedas.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conversorDeMonedas.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } // Nombre de usuario único
        public string Email { get; set; } // Correo electrónico único
        public string PasswordHash { get; set; } // Hash de la contraseña
        public Subscription Subscription { get; set; } // Relación con Suscripción
        public ICollection<Conversion> Conversions { get; set; } // Conversiones realizadas
        public ICollection<FavoriteCurrency> FavoriteCurrencies { get; set; } // Monedas favoritas
    }
}
