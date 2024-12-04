using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", 
        ErrorMessage = "Password must contain at least one letter and one number")]
    public string Password { get; set; }

    public string ToString()
    {
        return $"{FirstName} {LastName} - {Email} - {Password}";
    }
} 