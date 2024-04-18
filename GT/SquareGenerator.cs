namespace ConsoleApp1;

public class SquareGenerator
{
    public static string Generate()
    {
        Console.WriteLine("Write an odd number");
        var input = Console.ReadLine().Replace(" ", "");
        if (int.TryParse(input, out int value))
        {
            var starSymbol = '*';
            var starRow = "*";
            if (value % 2 == 1)
            {
                for (int i = 0; i < value / 2 + 0.5; i++)
                {
                    if (i > 0)
                    {
                        starRow += starSymbol.ToString();
                        starRow += starSymbol.ToString();
                    }

                    Console.WriteLine(starRow.PadLeft((value - 1) / 2 + 1 + i));
                }

                var temp = 0;
                for (int i = (value + 1) / 2; i < value; i++)
                {
                    temp++;
                    starRow = starRow.Substring(1, starRow.Length - 2);
                    Console.WriteLine(starRow.PadLeft(value - temp));
                }
                return "There we go!";
            }

            throw new Exception("Please write an odd number");
        }

        throw new Exception("Please write a number");
    }
}