using System.ComponentModel.DataAnnotations;

namespace conversorDeMonedas.Models.Dtos
{
    public class CreateAndUpdateUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}