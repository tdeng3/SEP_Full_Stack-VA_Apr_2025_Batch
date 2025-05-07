// Assignment 02 Arrays and Strings.pdf

// Here are the answers to the coding questions.

// Create a project named 02ArraysAndStrings.

// Copy code from C#_1st_Assignment_Part2_Program.cs into Program.cs.

// Create ArraysAndStrings.cs and copy relevant code from C#_1st_Assignment_Part2_ArraysAndStrings.cs.

// Ensure Program.cs can use ArraysAndStrings.cs.

namespace _02ArraysAndStrings;

public class ArraysAndStrings {
    private void CopyingAndArray()
    {
        int[] initialArray = new int[10];
        for (int i = 0; i < 10; i++)
        {
            initialArray[i] = i;
        }
        int[] copiedArray = new int[initialArray.Length];
        for (int i = 0; i < initialArray.Length; i++)
        {
            copiedArray[i] = initialArray[i];
        }
        Console.WriteLine("Initial Array:");
        foreach (int value in initialArray)
        {
            Console.Write(value + ", ");
        }
        Console.WriteLine("\n");
        Console.WriteLine("Copied Array:");
        foreach (int value in copiedArray)
        {
            Console.Write(value + ", ");
        }

    }

    private void ShoppingCart()
    {
        List<string> initialShoppingCart = new List<string>();
        while (true)
        {
            Console.WriteLine("\nChoose an operation:");
            Console.WriteLine("+ item");
            Console.WriteLine("- item");
            Console.WriteLine("-- clear the cart");
            Console.WriteLine("++ Show the shopping cart");
            Console.WriteLine("0. Exit");
            Console.Write("Enter command:  ");
            string userInput = Console.ReadLine();
            if (userInput == "--")
            {
                // Clear the entire list
                initialShoppingCart.Clear();
                Console.WriteLine("The shopping cart is empty now.");
            }
            else if (userInput == "++")
            {
                if (initialShoppingCart.Count > 0)
                {
                    Console.WriteLine("Shopping cart: ");
                    foreach (string value in initialShoppingCart)
                    {
                        Console.WriteLine(value);
                    }
                }
                else
                {
                    Console.WriteLine("Shopping cart is empty. ");
                }
                
            }
            else if (userInput.StartsWith("+") )
            {
                string itemName = userInput.Substring(1).Trim();
                if (itemName != "" || itemName == " ")
                {
                    initialShoppingCart.Add(itemName);
                    Console.WriteLine($"'{itemName}' has been added to the shopping cart.");
                }
                
            }
            else if (userInput.StartsWith("-"))
            {
                
                string selectedItem = userInput.Substring(1).Trim();
                if (initialShoppingCart.Contains(selectedItem))
                {
                    initialShoppingCart.Remove(selectedItem);
                    Console.WriteLine($"'{selectedItem}' has been removed from the shopping cart.");
                }
                else
                {
                    Console.WriteLine($"'{selectedItem}' is not in the shopping cart.");
                }
            }
            
            else if (userInput == "0")
            {
                Console.WriteLine("Exit.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
            Thread.Sleep(1300);
        }
    }
    
    private bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    private void findAllPrimeNumbers(int startNum, int endNum)
    {
        List<int> primeNumbers = new List<int>();
        for (int number = startNum; number <= endNum; number++)
        {
            if (IsPrime(number))
            {
                primeNumbers.Add(number);
            }
        }
        Console.WriteLine($"Prime numbers: ");
        foreach (int value in primeNumbers)
        {
            Console.WriteLine(value);
        }
        
    }

    private void arrayRotationSum()
    {
        Console.WriteLine("Please enter the numbers you want to rotate: ");
        string[] input = Console.ReadLine().Split(' ');
        int n = input.Length;
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(input[i]);
        }
        Console.WriteLine("Please enter the numbers you want to rotate: ");
        int k = int.Parse(Console.ReadLine());
        int[] sum = new int[n];
        for (int r = 1; r <= k; r++)
        {
            int[] rotated = new int[n];
            for (int i = 0; i < n; i++)
            {
                int newPos = (i + r) % n;
                rotated[newPos] = array[i];
            }
            for (int i = 0; i < n; i++)
            {
                sum[i] += rotated[i];
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write(sum[i] + " ");
        }
        
    }

    private void findLongestSequence()
    {
        Console.WriteLine("Please enter an array of integers: ");
        string[] input = Console.ReadLine().Split(' ');
        int n = input.Length;
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(input[i]);
        }
        List<int> longestSequence = new List<int>();
        int max = 1;
        int longest = 1;
        int maxItem = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                longest++;
            }
            else
            {
                longest = 1;
            }

            if (longest > max)
            {
                max = longest;
                maxItem = array[i];
            }
        }
        for (int i = 0; i < max; i++)
        {
            Console.Write(maxItem + " ");
        }
    }

    private void findMostFrequentNumbers()
    {
        Console.WriteLine("Enter numbers:");
        string[] userInput = Console.ReadLine().Split();
        List<int> numbers = new List<int>();

        foreach (string s in userInput)
            numbers.Add(int.Parse(s));

        Dictionary<int, int> counts = new Dictionary<int, int>();
        int max = 0;
        int result = numbers[0];

        foreach (int num in numbers)
        {
            if (!counts.ContainsKey(num))
                counts[num] = 0;

            counts[num]++;
            if (counts[num] > max || 
                (counts[num] == max && numbers.IndexOf(num) < numbers.IndexOf(result)))
            {
                max = counts[num];
                result = num;
            }
        }

        Console.WriteLine($"The number {result} is the most frequent (occurs {max} times)");
    }

    private void reverseString()
    {
        Console.WriteLine("Please enter the numbers you want to reverse: ");
        string userInput = Console.ReadLine();
        for (int i = userInput.Length - 1; i >= 0; i--)
        {
            Console.Write(userInput[i]);
        }
    }

    private bool isPalindrome(string userInput)
    {
        string cleaned = "";
        foreach (char c in userInput.ToLower())
        {
            if (char.IsLetterOrDigit(c))
                cleaned += c;
        }
        char[] charArray = cleaned.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);
        if (cleaned == reversed)
        {
            return true;
        }
        return false;
    }

    private void ExtractUniquePalindromes()
    {
        Console.WriteLine("Please type something, and I will extract all palindromes from it: ");
        string userInput = Console.ReadLine();

        string[] words = userInput.Split(new[] { ' ', ',', '.', '!', '?', ':', ';' }, 
            StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, string> palindromeDicrionaryList = new Dictionary<string, string>();

        foreach (string word in words)
        {
            if (isPalindrome(word))
            {
                string lowerCaseWord = word.ToLower();
                if (!palindromeDicrionaryList.ContainsKey(lowerCaseWord))
                    palindromeDicrionaryList[lowerCaseWord] = word; 
            }
        }
        List<string> keys = new List<string>(palindromeDicrionaryList.Keys);
        keys.Sort(); 
        List<string> sorted = new List<string>();
        foreach (string key in keys)
        {
            sorted.Add(palindromeDicrionaryList[key]);
        }

        Console.WriteLine(string.Join(", ", sorted));
    }

    private void findProtocolServerAndResource()
    {
        Console.WriteLine("Please type in the URL: ");
        string url = Console.ReadLine();
        string protocol = "";
        string server = "";
        string resource = "";
        int pIndex = url.IndexOf("://");
        if (pIndex != -1)
        {
            protocol = url.Substring(0, pIndex);
            url = url.Substring(pIndex + 3); 
        }
        int slashIndex = url.IndexOf('/');
        if (slashIndex != -1)
        {
            server = url.Substring(0, slashIndex);
            resource = url.Substring(slashIndex + 1);
        }
        else
        {
            server = url;
        }
        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }

    public void runCopyingAndArrays()
    {
        CopyingAndArray();
    }

    public void runShoppingCart()
    {
        ShoppingCart();
    }

    public void runFindPrimeNumbers(int startNum, int endNum)
    {
        findAllPrimeNumbers(startNum, endNum);
    }

    public void runArrayRotationSum()
    {
        arrayRotationSum();
    }

    public void runFindLongestSequence()
    {
        findLongestSequence();
    }

    public void runFindMostFrequentNumbers()
    {
        findMostFrequentNumbers();
    }

    public void runReverseString()
    {
        reverseString();
    }

    public void runExtractUniquePalindromes()
    {
        ExtractUniquePalindromes();
    }

    public void runFindProtocolServerAndResource()
    {
        findProtocolServerAndResource();
    }
}


