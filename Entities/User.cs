using ConversorDeMonedasBack.Data.Models.Enum;
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
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int Conversions { get; set; }
        public string Role { get; set; } = "User";
        public UserPlan Plan { get; set; } = UserPlan.Free;
        public List<Currency>? Currencies { get; set; }
    }
}
