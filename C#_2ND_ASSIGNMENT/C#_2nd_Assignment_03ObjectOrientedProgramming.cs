using System;
namespace _03ObjectOrientedProgramming;

public class _03ObjectObjectOrientedPrograming {

    private void test()
    {
        Console.WriteLine("Hello World!");
    }
    
    public void runTest()
    {
        test();
    }

    static int[] GenerateNumbers()
    {
        Random rand = new Random();
        int[] list = new int[10];
        for (int i = 0; i < 10; i++)
        {
            list[i] = rand.Next(1, 100);
        }
        Console.WriteLine(string.Join(",", list));
        return list;
    }

    static int[] Reverse(int[] list)
    {
        int first = 0;
        int last = list.Length - 1;
        while (first < last)
        {
            int temp = list[first];
            list[first] = list[last];
            list[last] = temp;
            first++;
            last--;
        }
        return list;
    }

    static void PrintNumbers(int[] list)
    {
        Console.WriteLine(string.Join(",", list));
    }
    
    private void Fibonacci()
    {
        Console.WriteLine("Please enter an integer: ");
        int userInput = int.Parse(Console.ReadLine());
        int a = 0, b = 1, c = 0;

        for (int i = 0; i < userInput; i++)
        {
            Console.Write(a);
            if (i < userInput - 1)
            {
                Console.Write(", ");
            }

            c = a + b;
            a = b;
            b = c;
        }

    }

    public void runProgram1()
    {
        int[] numbers = GenerateNumbers();
        Reverse(numbers);
        PrintNumbers(numbers);

    }

    public void runFibonacci()
    {
        Fibonacci();
    }

}

