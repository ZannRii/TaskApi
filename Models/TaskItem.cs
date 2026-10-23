namespace TaskApi.Models;
public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string? Description { get; set; } = "";

    public bool IsCompleted { get; set; } = false;

    // Foreign key
    public int EmployeeId { get; set; }

    // Navigation property
    public Employee? Employee { get; set; }
}