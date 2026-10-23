using System.Text.Json.Serialization;
namespace TaskApi.Models;
public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    // One employee can have many tasks
    [JsonIgnore]
    public List<TaskItem> Tasks { get; set; } = new();
}