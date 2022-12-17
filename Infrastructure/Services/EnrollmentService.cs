using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Infrastructure.Services;

public class EnrollmentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public EnrollmentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetEnrollment>>> GetEnrollment()
    {
        var list =  _mapper.Map<List<GetEnrollment>>(_context.Enrollments.ToList());
        return new Response<List<GetEnrollment>>(list);
    }

    public async Task<Response<AddEnrollment>> AddEnrollment(AddEnrollment enrollment)
    {
        var newEnrollment = _mapper.Map<Enrollment>(enrollment);

        _context.Enrollments.Add(newEnrollment);
        await _context.SaveChangesAsync();
        return new Response<AddEnrollment>(enrollment);
    }

    public async Task<Response<AddEnrollment>> UpdateEnrollment(AddEnrollment enrollment)
    {
        var find = await _context.Enrollments.FindAsync(enrollment.EnrollmentId);
        find.EnrollmentId = enrollment.EnrollmentId;
        find.CourseId = enrollment.CourseId;
        find.StudentId = enrollment.StudentId;
        find.Grade = enrollment.Grade;
        await _context.SaveChangesAsync();
        return new Response<AddEnrollment>(enrollment);
    }

    public async Task<Response<string>> DeleteEnrollment(int id)
    {
        var find = await _context.Enrollments.FindAsync(id);
        _context.Enrollments.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Enrollment succesfully deleted");
    }
}