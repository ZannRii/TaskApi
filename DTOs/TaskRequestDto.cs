
using System.ComponentModel.DataAnnotations;

namespace TaskApi.DTOs;

public class TaskRequestDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid employee.")]
    public int EmployeeId { get; set; }
}
