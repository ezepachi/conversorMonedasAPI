using System.ComponentModel.DataAnnotations;

public class CreateAndUpdateUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; } 

    [Required]
    [MaxLength(30)]
    public string Username { get; set; }

    public int? SubscriptionId { get; set; }
}