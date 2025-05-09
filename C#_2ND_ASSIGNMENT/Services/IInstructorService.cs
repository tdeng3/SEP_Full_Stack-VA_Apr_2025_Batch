using _03ObjectOrientedProgramming.DataModel;

namespace _03ObjectOrientedProgramming.Services;

public interface IInstructorService : IPersonService
{
    int YearsOfExperience { get; }
    Department Department { get; set; }
}
