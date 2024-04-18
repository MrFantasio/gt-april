namespace ConsoleApp1;

public class FibonacciGenerator
{
    public static int Generate()
    {
        Console.WriteLine("Write a number");
        var input = Console.ReadLine().Replace(" ", "");
        if (int.TryParse(input, out int position))
        {
            var result = FibonacciCounter(position);
            return result;
        }

        throw new Exception("Please insert an integer");
    }

    public static int FibonacciCounter(int pos)
    {
        int a = 0;
        int b = 1;
        int temp;

        for (int i = 0; i < pos; i++)
        {
            temp = a;
            a = b;
            b = temp + b;
        }

        return a;
    }
}