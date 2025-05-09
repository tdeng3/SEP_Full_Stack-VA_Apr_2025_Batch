using _03ObjectOrientedProgramming.DataModel;

namespace _03ObjectOrientedProgramming.Repository;

public static class StudentRepository
{
    public static List<Student> CreateStudents(List<Course> courses)
    {
        var student1 = new Student("Alice", "Smith", new DateTime(2000, 5, 10));
        var student2 = new Student("Bob", "Johnson", new DateTime(1999, 11, 20));

        // Enroll students in courses
        student1.EnrollCourse(courses[0]);
        student1.EnrollCourse(courses[1]);
        student2.EnrollCourse(courses[2]);

        // Set grades for students
        student1.SetGrade(courses[0], 'A');
        student1.SetGrade(courses[1], 'B');
        student2.SetGrade(courses[2], 'C');

        return new List<Student> { student1, student2 };
    }
}
