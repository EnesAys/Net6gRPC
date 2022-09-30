using Microsoft.AspNetCore.Mvc;
using StudentClientApi.Models;
using StudentClientApi.Services;

namespace StudentClientApi.Controllers;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public async Task<IActionResult> AddStudents(StudentReq request)
    {         
        return Ok(await _studentService.InsertStudentsAsync(request));
    }
     [HttpGet]
    public async Task<IActionResult> GetStudents()
    {         
        return Ok(await _studentService.GetStudentsAsync());
    }
}
