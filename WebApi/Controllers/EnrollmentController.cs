using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EnrollmentController
{
    private readonly EnrollmentService _enrollmentService;
    public EnrollmentController(EnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }


    [HttpGet]
    public async Task<Response<List<GetEnrollment>>> GetEnrollment()
    {
        return await _enrollmentService.GetEnrollment();
    }

    [HttpPost]
    public async Task<Response<AddEnrollment>> AddEnrollment(AddEnrollment enrollment)
    {
        return await _enrollmentService.AddEnrollment(enrollment);
    }

    [HttpPut]
    public async Task<Response<AddEnrollment>> UpdateEnrollment(AddEnrollment enrollment)
    {
        return await _enrollmentService.UpdateEnrollment(enrollment);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteEnrollment(int id)
    {
        return await _enrollmentService.DeleteEnrollment(id);
    }
}