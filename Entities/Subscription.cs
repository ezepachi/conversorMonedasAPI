using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conversorMonedas.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Type { get; set; } // Free, Trial, Pro
        public int ConversionLimit { get; set; } // 10, 100, -1 (ilimitado)
        public DateTime ExpirationDate { get; set; } // Fecha de expiración para Trial
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
