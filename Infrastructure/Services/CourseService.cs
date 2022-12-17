using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Infrastructure.Services;

public class CourseService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CourseService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetCourse>>> GetCourse()
    {
        var list =  _mapper.Map<List<GetCourse>>(_context.Courses.ToList());
        return new Response<List<GetCourse>>(list);
    }

    public async Task<Response<AddCourse>> AddCourse(AddCourse course)
    {
        var newCourse = _mapper.Map<Course>(course);

        _context.Courses.Add(newCourse);
        await _context.SaveChangesAsync();
        return new Response<AddCourse>(course);
    }

    public async Task<Response<AddCourse>> UpdateCourse(AddCourse course)
    {
        var find = await _context.Courses.FindAsync(course.CourseId);
        find.CourseId = course.CourseId;
        find.Title = course.Title;
        find.Credits = course.Credits;
        await _context.SaveChangesAsync();
        return new Response<AddCourse>(course);
    }
    
    public async Task<Response<string>> DeleteCourse(int id)
    {
        var find = await _context.Courses.FindAsync(id);
        _context.Courses.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Course succesfully deleted");
    }
}