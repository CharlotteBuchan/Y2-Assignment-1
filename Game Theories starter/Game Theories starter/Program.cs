using System;

class Program
{
    static int SumOfAbsoluteValues(int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += Math.Abs(number);
        }
        return sum;
    }

    static void Main(string[] args)
    {
        int[] numbers = { -5, 10, -3, 8, 2 };
        int result = SumOfAbsoluteValues(numbers);
        Console.WriteLine("Sum of absolute values: " + result);
    }
}