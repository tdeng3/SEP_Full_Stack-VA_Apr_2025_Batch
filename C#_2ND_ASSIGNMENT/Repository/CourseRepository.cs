using _03ObjectOrientedProgramming.DataModel;

namespace _03ObjectOrientedProgramming.Repository;

public static class CourseRepository
{
    public static List<Course> CreateCourses()
    {
        return new List<Course>
        {
            new Course("Computer Science 101"),
            new Course("Algorithms"),
            new Course("Linear Algebra")
        };
    }
}
