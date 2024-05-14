using conversorDeMonedas.Entities;
using ConversorDeMonedasBack.Data.Models.Enum;

namespace conversorDeMonedas.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public int Conversions { get; set; }
        public UserPlan Plan { get; set; } = UserPlan.Free;

    }
}
