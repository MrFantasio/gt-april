// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

Console.WriteLine("Which task should be done? Write 1 - 4");
var choice = Console.ReadLine();

var result = choice switch
{
    "1" => $"The Fibonacci number responding to your potision is: {FibonacciGenerator.Generate()}",
    "2" => SquareGenerator.Generate(),
    "3" => BubbleSort.Generate(),
    "4" => $"{await Palindrome.GetWords()}",
    _ => "There seems to be no task responding to this number"
};

Console.WriteLine(result);


