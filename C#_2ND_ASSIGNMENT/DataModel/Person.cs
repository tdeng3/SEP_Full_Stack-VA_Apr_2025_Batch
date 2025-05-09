namespace _03ObjectOrientedProgramming.DataModel;

public abstract class Person
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime BirthDate { get; private set; }
    private List<string> addresses = new List<string>();

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public int CalculateAge()
    {
        var today = DateTime.Today;
        var age = today.Year - BirthDate.Year;
        if (BirthDate.Date > today.AddYears(-age)) age--;
        return age;
    }

    public void AddAddress(string address)
    {
        addresses.Add(address);
    }

    public List<string> GetAddresses()
    {
        return new List<string>(addresses);
    }

    public abstract decimal CalculateSalary();

}
