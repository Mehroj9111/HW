using Domain.Entities;

namespace Domain.Dtos;

public class GetCourse
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
}