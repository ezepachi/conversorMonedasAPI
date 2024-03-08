using conversorDeMonedas.Entities;

namespace conversorDeMonedas.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
