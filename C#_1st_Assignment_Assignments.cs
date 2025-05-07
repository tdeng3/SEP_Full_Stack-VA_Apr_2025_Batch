namespace _02UnderstandingTypes;

public class Assignments
{
    public void ConsoleAppQuestion1()
    {
        Console.WriteLine("Type: sbyte");
        Console.WriteLine("Bytes: " + sizeof(sbyte));
        Console.WriteLine("Min Value: " + sbyte.MinValue);
        Console.WriteLine("Max Value: " + sbyte.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: byte");
        Console.WriteLine("Bytes: " + sizeof(byte));
        Console.WriteLine("Min Value: " + byte.MinValue);
        Console.WriteLine("Max Value: " + byte.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: short");
        Console.WriteLine("Bytes: " + sizeof(short));
        Console.WriteLine("Min Value: " + short.MinValue);
        Console.WriteLine("Max Value: " + short.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: ushort");
        Console.WriteLine("Bytes: " + sizeof(ushort));
        Console.WriteLine("Min Value: " + ushort.MinValue);
        Console.WriteLine("Max Value: " + ushort.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: int");
        Console.WriteLine("Bytes: " + sizeof(int));
        Console.WriteLine("Min Value: " + int.MinValue);
        Console.WriteLine("Max Value: " + int.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: uint");
        Console.WriteLine("Bytes: " + sizeof(uint));
        Console.WriteLine("Min Value: " + uint.MinValue);
        Console.WriteLine("Max Value: " + uint.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: long");
        Console.WriteLine("Bytes: " + sizeof(long));
        Console.WriteLine("Min Value: " + long.MinValue);
        Console.WriteLine("Max Value: " + long.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: ulong");
        Console.WriteLine("Bytes: " + sizeof(ulong));
        Console.WriteLine("Min Value: " + ulong.MinValue);
        Console.WriteLine("Max Value: " + ulong.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: float");
        Console.WriteLine("Bytes: " + sizeof(float));
        Console.WriteLine("Min Value: " + float.MinValue);
        Console.WriteLine("Max Value: " + float.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: double");
        Console.WriteLine("Bytes: " + sizeof(double));
        Console.WriteLine("Min Value: " + double.MinValue);
        Console.WriteLine("Max Value: " + double.MaxValue);
        Console.WriteLine();

        Console.WriteLine("Type: decimal");
        Console.WriteLine("Bytes: " + sizeof(decimal));
        Console.WriteLine("Min Value: " + decimal.MinValue);
        Console.WriteLine("Max Value: " + decimal.MaxValue);
        Console.WriteLine();
    }

    public void ConsoleAppQuestion2(int i)
    {
        long years = i * 100;
        long days = years * 365 + years / 4; // Approximating leap years
        long hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        long nanoseconds = microseconds * 1000;

        Console.WriteLine($"{i} centuries = {years} years " +
                          $"= {days} days = {hours} hours = {minutes} minutes " +
                          $"= {seconds} seconds \n= {milliseconds} milliseconds " +
                          $"= {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
    
    //Practice loops and operators
    public void FizzBuzz(int count)
    {
        if (count % 3 == 0 && count % 5 == 0)
        {
            Console.WriteLine("fizzbuzz");
        }
        else if (count % 3 == 0)
        {
            Console.WriteLine("fizz");
        }
        else if (count % 5 == 0)
        {
            Console.WriteLine("buzz");
        }
    }
    public void Pyramid(int totalRows)
    {
        for (int i = 1; i <= totalRows; i++)
        {
            for (int j = 1; j <= totalRows - i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 1; k <= 2 * i - 1; k++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
    public void GuessRandomNumbers()
    {
        Console.WriteLine("Please enter a number:");
        string userInput = Console.ReadLine();
        int guessedNumber = int.Parse(userInput);
        int correctNumber = new Random().Next(3) + 1;
        
        if (guessedNumber == correctNumber)
        {
            Console.WriteLine("Congratulations! You won!");
        }
        else if (guessedNumber < correctNumber)
        {
            Console.WriteLine("Try again, your guess is lower than the correct number!.");
        }
        else if (guessedNumber > correctNumber)
        {
            Console.WriteLine("Try again, your guess is higher than the correct number!.");
        }
        
    }

    public void CalculateAgeAndAnniversary(int year, int month, int day)
    {
        DateTime today = DateTime.Today;
        DateTime birthDay = new DateTime(year, month, day);
        int daysOld = (today - birthDay).Days;
        //Explanation: daysOld % 10000 = 340 This means you've passed your last 10000-day by 340 days.
        //          the next 10000th is 10000 - 340
        int daysToNextAnniversary = 10000 - (daysOld % 10000);
        DateTime nextAnniversary = today.AddDays(daysToNextAnniversary);

        Console.WriteLine($"You are still young, only {daysOld} days old.");
        Console.WriteLine($"Your next 10000th anniversary is on: {nextAnniversary.ToShortDateString()}");
    }

    public void Greeting()
    {
        DateTime currentTime = DateTime.Now;
        int hour = currentTime.Hour;

        if (hour >= 6 && hour < 12)
        {
            Console.WriteLine("Good Morning");
        }

        else if (hour >= 12 && hour < 17)
        {
            Console.WriteLine("Good Afternoon");
        }

        else if (hour >= 17 && hour < 22)
        {
            Console.WriteLine("Good Evening");
        }

        else if (hour >= 22 || hour < 6)
        {
            Console.WriteLine("Good Night");
        }
    }
}
