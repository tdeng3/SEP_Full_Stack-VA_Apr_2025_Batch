namespace _03ObjectOrientedProgramming.DataModel;

public class Course
{
    public string CourseName { get; set; }
    private List<Student> enrolledStudents = new List<Student>();

    public Course(string courseName)
    {
        CourseName = courseName;
    }

    public void EnrollStudent(Student student)
    {
        if (!enrolledStudents.Contains(student))
            enrolledStudents.Add(student);
    }

    public List<Student> GetEnrolledStudents() => new List<Student>(enrolledStudents);
}
