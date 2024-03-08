using conversorMonedas.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conversorDeMonedas.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string Password { get; set; }
        [Required]
        public string? UserName { get; set; }
        public List<Subscriptions> TypeSubscription { get; set; }

        public List<Conversion> Conversions { get; set; }
        public List <Currency> Currency { get; set; }
    }

    public enum TypeSubscription
    {
        Free,
        Trial,
        Pro
        
    }
}