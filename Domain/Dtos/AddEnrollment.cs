using Domain.Entities;

namespace Domain.Dtos;

public class AddEnrollment
{
    public int EnrollmentId { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public int Grade { get; set; }
}