using _03ObjectOrientedProgramming.DataModel;

namespace _03ObjectOrientedProgramming.Repository;

public class InstructorRepository
{
    public static List<Instructor> CreateSampleInstructors()
    {
        return new List<Instructor>
        {
            new Instructor("Dr.", "Jones", new DateTime(1980, 3, 15), new DateTime(2010, 9, 1), 60000m),
            new Instructor("Prof.", "Brown", new DateTime(1975, 7, 8), new DateTime(2005, 6, 1), 70000m),
            new Instructor("Ms.", "Davis", new DateTime(1985, 12, 5), new DateTime(2012, 1, 15), 58000m)
        };
    }

    public static List<Department> CreateSampleDepartments(List<Instructor> instructors, List<Course> courses)
    {
        return new List<Department>
        {
            new Department("Computer Science", DateTime.Now, DateTime.Now.AddYears(1), 100000m)
            {
                Head = instructors[0],
                CoursesOffered = new List<Course> { courses[0], courses[1] }
            },
            new Department("Mathematics", DateTime.Now, DateTime.Now.AddYears(1), 85000m)
            {
                Head = instructors[1],
                CoursesOffered = new List<Course> { courses[2] }
            }
        };
    }
}
