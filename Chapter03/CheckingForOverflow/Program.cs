using static System.Console;
checked
{
    int x = int.MaxValue - 1;
    try
    {
        WriteLine($"Initial Value: {x}");
        x++;
        WriteLine($"After Incrementing: {x}");
        x++;
        WriteLine($"After Incrementing: {x}");
        x++;
        WriteLine($"After Incrementing: {x}");
    }
    catch(OverflowException)
    {
        WriteLine("The code overflowed but we caught the exception");
    }
}
unchecked
{
    int y = int.MaxValue + 1;
    WriteLine($"Initial Value: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
}

double h = 10;
double j = 0;

WriteLine(h / j);