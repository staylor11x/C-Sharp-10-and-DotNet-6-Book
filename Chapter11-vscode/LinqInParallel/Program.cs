using System.Diagnostics;

using static System.Console;
 
 Stopwatch watch = new();
 Write("Press enter to start");
 ReadLine();
 watch.Start();

 int max = 45;

 IEnumerable<int> numbers = Enumerable.Range(start: 1, count: max);

 WriteLine($"Calculating Fibonacci sequence up to (max). Please wait...");

 int[] fibonacciNumbers = numbers.AsParallel()          //takes half the time to complete in parallel and all of our logical processors did max out
    .Select(number => Fibonacci(number))
    .OrderBy(number => number)
    .ToArray();

 watch.Stop();
 WriteLine("{0:#,##0} elapsed milliseconds", watch.ElapsedMilliseconds);

 Write("Results");
 foreach(int number in fibonacciNumbers)
 {
    Write($" {number}");
 }

 static int Fibonacci(int term) =>      //some basic recursion and a fancy looking function! This is maybe worh remebering seems like something that could come up in a coding challange!
    term switch
    {
        1 => 0,
        2 => 1,
        _ => Fibonacci(term - 1) + Fibonacci(term - 2)
    };
