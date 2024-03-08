using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conversorMonedas.Entities
{
    public class Conversion
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConversion { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdCurrencyFrom")]
        public int IdCurrencyFrom { get; set; }

        [ForeignKey("IdCurrencyTo")]
        public int IdCurrencyTo { get; set; }
        public float Amount { get; set; }
        public float Result { get; set; }
        public DateTime Date { get; set; }
    }
}
