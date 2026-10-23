
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Models;

namespace TaskApi.Services;

public class TaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAll()
    {
        return await _context.Tasks
            .Include(t => t.Employee)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetById(int id)
    {
        return await _context.Tasks
            .Include(t => t.Employee)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TaskItem> Create(TaskRequestDto request)
    {
        // Check whether the employee exists
        var employeeExists = await _context.Employees
            .AnyAsync(e => e.Id == request.EmployeeId);

        if (!employeeExists)
            throw new ArgumentException("Employee not found.");

        var task = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted,
            EmployeeId = request.EmployeeId
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<bool> Update(int id, TaskRequestDto request)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return false;

        var employeeExists = await _context.Employees
            .AnyAsync(e => e.Id == request.EmployeeId);

        if (!employeeExists)
            throw new ArgumentException("Employee not found.");

        task.Title = request.Title;
        task.Description = request.Description;
        task.IsCompleted = request.IsCompleted;
        task.EmployeeId = request.EmployeeId;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }
}
