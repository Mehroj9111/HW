using Domain.Entities;

namespace Domain.Dtos;

public class GetStudent
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string FileName { get; set; }
}