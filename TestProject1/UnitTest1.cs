using ConsoleApp1;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FibonacciTest()
    {
        int[] fibonacciSerie = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144];
        for(int i = 0; i < fibonacciSerie.Length; i++)
        {
            Assert.AreEqual(FibonacciGenerator.FibonacciCounter(i), fibonacciSerie[i]);
        }
    }

    [Test]
    public void BubbleTest()
    {
        List<int> testSerie = [1, 5, 23, 67, 123, 23, 78, 2, 3, 6, -1, -10, 0];
        List<int> keySerie = [-10, -1, 0, 1, 2, 3, 5, 6, 23, 23, 67, 78, 123];
        Assert.AreEqual(BubbleSort.Sorter(testSerie), keySerie);
    }
    
}