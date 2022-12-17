using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

namespace Infrastructure.Services;

public class StudentService
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _environment;
    private readonly IMapper _mapper;

    public StudentService(DataContext context,IWebHostEnvironment environment,IMapper mapper)
    {
        _context = context;
        _environment = environment;
        _mapper = mapper;
    }
    public async Task<Response<List<GetStudent>>> GetStudent()
    {
        var list = _mapper.Map<List<GetStudent>>(_context.Students.ToList());
        return new Response<List<GetStudent>>(list);
    }

    public async Task<Response<GetStudent>> AddStudent(AddStudent student)
    {

        var newStudent = _mapper.Map<Student>(student); 
         var response = _mapper.Map<GetStudent>(student);
        newStudent.FileName = await UploadFile(student.File);
        _context.Students.Add(newStudent);
        await _context.SaveChangesAsync();
        return new Response<GetStudent>(response);
    }

    public async Task<Response<GetStudent>> UpdateStudent(AddStudent student)
    {

        var response = _mapper.Map<GetStudent>(student);

        var find = await _context.Students.FindAsync(student.StudentId);
        find.StudentId = student.StudentId;
        find.FirstName = student.FirstName;
        find.LastName = student.LastName;
        find.FileName = student.FirstName;

        if(student.File != null)
        {
            find.FileName = await UpdateFile(student.File, find.FileName);
        }

        await _context.SaveChangesAsync();
        return new Response<GetStudent>(response);
    }

    public async Task<Response<string>> DeleteStudent(int id)
    {
        var find = await _context.Students.FindAsync(id);
        _context.Students.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Student succesfully deleted");
    }

    private async Task<string> UploadFile(IFormFile file)
    {
        if(file == null) return null;


        var path = Path.Combine(_environment.WebRootPath, "studentimage");
        if(Directory.Exists(path) == false) Directory.CreateDirectory(path);

        var filepath = Path.Combine(path, file.FileName);
        using (var stream = new FileStream( filepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        
        return file.FileName;
    }
    private async Task<string> UpdateFile(IFormFile file, string oldFileName)
    {
        //delete old file if exists
        var filepath = Path.Combine(_environment.WebRootPath, "studentimage", oldFileName);
        if(File.Exists(filepath) == true) File.Delete(filepath);

        var newFilepath = Path.Combine(_environment.WebRootPath, "studentimage", file.FileName);
        using (var stream = new FileStream(newFilepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return file.FileName;

    }
}