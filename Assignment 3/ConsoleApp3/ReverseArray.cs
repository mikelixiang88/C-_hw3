namespace ConsoleApp3;

public class ReverseArray
{
    static void Main(string[] args)
    {   
        // You can pass any length you want to GenerateNumbers method.
        
        int[] numbers = GenerateNumbers();
        Reverse(numbers);
        PrintNumbers(numbers);
        
        //Fibonacci
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(Fibonacci(i));
        }
    }

// GenerateNumbers method to create an array of specified length
    static int[] GenerateNumbers()
    {
        Console.WriteLine("Please enter the length of your array");
        int length = Convert.ToInt32(Console.ReadLine());
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            // I like enumerating starting with 0 because I like CS
            Console.WriteLine($"Please enter the value of your {i}th element");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        return numbers;
    }

// Reverse method to reverse the contents of the array
    static void Reverse(int[] numbers)
    {
        int temp;
        for (int i = 0; i < numbers.Length / 2; i++)
        {
            temp = numbers[i];
            numbers[i] = numbers[numbers.Length - i - 1];
            numbers[numbers.Length - i - 1] = temp;
        }
    }

// PrintNumbers method to print out each item in the array
    static void PrintNumbers(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    static int Fibonacci(int index)
    {
        if (index < 1) return -1;
        else if (index <= 2) return 1;
        return Fibonacci(index - 1) + Fibonacci(index - 2);
    }
}