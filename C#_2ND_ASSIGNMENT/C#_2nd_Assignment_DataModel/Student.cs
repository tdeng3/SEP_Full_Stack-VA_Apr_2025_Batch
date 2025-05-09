using _03ObjectOrientedProgramming.Services;

namespace _03ObjectOrientedProgramming.DataModel;

public class Student : Person, IStudentService
{
    private Dictionary<Course, char> courseGrades = new Dictionary<Course, char>();

    public Student(string firstName, string lastName, DateTime birthDate)
        : base(firstName, lastName, birthDate) { }

    public void EnrollCourse(Course course)
    {
        if (!courseGrades.ContainsKey(course))
        {
            courseGrades[course] = 'F';
            course.EnrollStudent(this);
        }
    }

    public void SetGrade(Course course, char grade)
    {
        if (courseGrades.ContainsKey(course))
        {
            courseGrades[course] = grade;
        }
    }

    public double CalculateGPA()
    {
        if (!courseGrades.Any()) return 0.0;

        double totalPoints = courseGrades.Sum(cg => GradeToPoint(cg.Value));
        return totalPoints / courseGrades.Count;
    }

    private double GradeToPoint(char grade) => grade switch
    {
        'A' => 4.0,
        'B' => 3.0,
        'C' => 2.0,
        'D' => 1.0,
        _ => 0.0
    };

    public override decimal CalculateSalary() => 0.0m;
}
