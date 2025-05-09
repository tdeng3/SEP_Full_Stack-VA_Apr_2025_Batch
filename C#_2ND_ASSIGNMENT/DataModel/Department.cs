namespace _03ObjectOrientedProgramming.DataModel;

public class Department
{
    public string Name { get; set; }
    public Instructor Head { get; set; }
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Course> CoursesOffered { get; set; }

    public Department(string name, DateTime startDate, DateTime endDate, decimal budget)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Budget = budget;
        CoursesOffered = new List<Course>();
    }

    // Add a course to the department
    public void AddCourse(Course course)
    {
        if (!CoursesOffered.Contains(course))
            CoursesOffered.Add(course);
    }
}
