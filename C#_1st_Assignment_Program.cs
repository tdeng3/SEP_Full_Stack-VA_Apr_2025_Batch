// See https://aka.ms/new-console-template for more information


using _02UnderstandingTypes;

// Console.WriteLine("Hello, World!");

Assignments assignmentsQ1 = new Assignments();
assignmentsQ1.ConsoleAppQuestion1();

Assignments assignmentsQ2 = new Assignments();
assignmentsQ2.ConsoleAppQuestion2(5);




int a = 10;
int b = 0;
// int result = a / b;
// Console.WriteLine(result);

double a2 = 5.0;
double b2 = 0.0;
double doubleResult= a2 / b2;
Console.WriteLine(doubleResult); 

int x = int.MaxValue;  
x = x + 1;             
Console.WriteLine(x);

// for (; true;)
// {
//     Console.WriteLine(1);
// }

Assignments fizzBuss = new Assignments();
// fizzBuss.FizzBuzz(100);

int max = 6;

for (byte i = 0; i < max; i++)
{
    if (i == 0)
    {
        Console.WriteLine("Warning: 0 divides by anything is equal to 0, so i should start at 1");
        i = 1;
        continue;
    }
    fizzBuss.FizzBuzz(i);
}

//since 0 divides by anything is 0 so it will display fizzbuzz when i=0



Assignments pyramid = new Assignments();
pyramid.Pyramid(5);

Assignments guessNumber = new Assignments();
guessNumber.GuessRandomNumbers();

Assignments ageAndAnniversary = new Assignments();
ageAndAnniversary.CalculateAgeAndAnniversary(2000,1,1);

Assignments greets = new Assignments();
greets.Greeting();
