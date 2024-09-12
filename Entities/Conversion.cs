using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using conversorDeMonedas.Entities;

namespace conversorMonedas.Entities
{
    public class Conversion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FromCurrencyId { get; set; }
        public Currency FromCurrency { get; set; }
        public int ToCurrencyId { get; set; }
        public Currency ToCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal ConvertedAmount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
