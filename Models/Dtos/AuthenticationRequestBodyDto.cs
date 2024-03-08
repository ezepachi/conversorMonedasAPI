using System.ComponentModel.DataAnnotations;

namespace conversorDeMonedas.Models.Dtos
{
    public class AuthenticationRequestBody
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}