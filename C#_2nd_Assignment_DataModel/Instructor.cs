using _03ObjectOrientedProgramming.Services;

namespace _03ObjectOrientedProgramming.DataModel;

public class Instructor : Person, IInstructorService
{
    public DateTime JoinDate { get; private set; }
    public decimal BaseSalary { get; private set; }
    public Department Department { get; set; }

    public Instructor(string firstName, string lastName, DateTime birthDate, DateTime joinDate, decimal baseSalary)
        : base(firstName, lastName, birthDate)
    {
        JoinDate = joinDate;
        BaseSalary = baseSalary >= 0 ? baseSalary : throw new ArgumentException("Salary cannot be negative.");
    }

    public int YearsOfExperience => DateTime.Today.Year - JoinDate.Year;

    public override decimal CalculateSalary()
    {
        decimal bonus = YearsOfExperience * 500;
        return BaseSalary + bonus;
    }
}
