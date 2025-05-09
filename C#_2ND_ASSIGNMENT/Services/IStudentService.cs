using _03ObjectOrientedProgramming.DataModel;

namespace _03ObjectOrientedProgramming.Services;

public interface IStudentService : IPersonService
{
    void EnrollCourse(Course course);
    void SetGrade(Course course, char grade);
    double CalculateGPA();
}
