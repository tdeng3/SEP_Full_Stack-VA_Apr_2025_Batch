using _03ObjectOrientedProgramming.DataModel;

namespace _03ObjectOrientedProgramming.Services;

public interface IDepartmentService
{
    Instructor Head { get; set; }
    decimal Budget { get; set; }
    List<Course> CoursesOffered { get; set; }
}
