using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using conversorMonedas.Models.Enums; // Definí aquí tu enum UserRoleEnum

namespace conversorMonedas.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Password { get; set; }

        public int? SubscriptionId { get; set; } // Clave foránea para Subscription

        public Subscription Subscription { get; set; } // Propiedad de navegación

        public UserRoleEnum Role { get; set; } // Nuevo campo para roles

        public ICollection<Conversion> Conversions { get; set; }
        public ICollection<FavoriteCurrency> FavoriteCurrencies { get; set; }
    }
}