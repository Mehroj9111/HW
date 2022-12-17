using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController
{
    private readonly StudentService _studentService;
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }


    [HttpGet]
    public async Task<Response<List<GetStudent>>> GetStudent()
    {
        return await _studentService.GetStudent();
    }

    [HttpPost]
    public async Task<Response<GetStudent>> AddStudent([FromForm]AddStudent student)
    {
        return await _studentService.AddStudent(student);
    }

    [HttpPut]
    public async Task<Response<GetStudent>> UpdateStudent([FromForm]AddStudent student)
    {
        return await _studentService.UpdateStudent(student);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudent(int id)
    {
        return await _studentService.DeleteStudent(id);
    }
}