
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    // GET: 
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeService.GetAll();
        return Ok(employees);
    }

    // GET: 
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _employeeService.GetById(id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    // POST: 
    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        var createdEmployee = await _employeeService.Create(employee);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdEmployee.Id },
            createdEmployee
        );
    }

    // DELETE:
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _employeeService.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
