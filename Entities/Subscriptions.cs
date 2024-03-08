using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conversorMonedas.Entities
{
    public class Subscriptions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSuscription { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int MaxConvertions { get; set; }
    }
}
