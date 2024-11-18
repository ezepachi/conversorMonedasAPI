using ConversorDeMonedasBack.Data.Models.Enum;

namespace conversorDeMonedas.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Conversions { get; set; }
        public UserPlan Plan { get; set; }

    }
}
