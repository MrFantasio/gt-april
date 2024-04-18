namespace ConsoleApp1;

public class BubbleSort
{
    public static string Generate()
    {
        List<int> list = [];
        
        list = AddingNumber(list);
        var arr = Sorter(list);
        var sortedList = String.Empty;
        for (int i = 0; i < arr.Length; i++)
            sortedList += arr[i] + " ";
        return sortedList;
    }

    public static int[] Sorter(List<int> list)
    {
        int[] arr = list.ToArray();
        int temp = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    temp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = temp;
                }
            }
        }
        
        return arr;
    }

    private static List<int> AddingNumber(List<int> list)
    {
        Console.WriteLine("Enter a number, finish by entering a letter");
        var input = Console.ReadLine();
        if (int.TryParse(input, out var number))
        {
            list.Add(number);
            AddingNumber(list);
        }

        return list;
    }
}