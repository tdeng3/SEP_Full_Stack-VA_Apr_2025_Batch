using _03ObjectOrientedProgramming.DataModel;

namespace _03ObjectOrientedProgramming.Services;

public interface ICourseService
{
    void EnrollStudent(Student student);
    List<Student> GetEnrolledStudents();
}
