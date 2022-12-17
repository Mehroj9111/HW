using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CourseController
{
    private readonly CourseService _courseService;
    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<Response<List<GetCourse>>> GetCourse()
    {
        return await _courseService.GetCourse();
    }

    [HttpPost]
    public async Task<Response<AddCourse>> AddCourse(AddCourse course)
    {
        return await _courseService.AddCourse(course);
    }

    [HttpPut]
    public async Task<Response<AddCourse>> UpdateCourse(AddCourse course)
    {
        return await _courseService.UpdateCourse(course);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCourse(int id)
    {
        return await _courseService.DeleteCourse(id);
    }
}