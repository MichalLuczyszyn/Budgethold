namespace Budgethold.Modules.Users.Core.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class SignInDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}