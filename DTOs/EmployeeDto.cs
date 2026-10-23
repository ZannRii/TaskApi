using System.ComponentModel.DataAnnotations;
namespace TaskApi.DTOs;
public class EmployeeDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Employee name is required.")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [StringLength(150)]
    public string Email { get; set; } = "";
}