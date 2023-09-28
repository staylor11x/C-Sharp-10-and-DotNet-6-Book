using static System.Console;

//TimesTable(6);

//decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "AK");
//WriteLine($"You must pay {taxToPay} in tax");

//RunCardinalToOrdinal();

//RunFactorial();

RunFibImperitive();

static void TimesTable(byte number)
{
    WriteLine($"This is the {number} times table");

    for(int row = 1; row <= 12; row++)
    {
        WriteLine($"{row} x {number} = {row * number}");
    }
    WriteLine();
}

static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
{
    decimal rate = 0.0M;

    switch(twoLetterRegionCode)
    {
        case "CH":
            rate = 0.08M;
            break;
        case "DK":
        case "NO":
            rate = 0.25M;
            break;
        case "GB":
        case "FR":
            rate = 0.2M;
            break;
        case "HU":
            rate = 0.27M;
            break;
        case "OR":
        case "AK":
        case "MT":
            rate = 0.0M;
            break;
        case "ND":
        case "WI":
        case "ME":
        case "VA":
            rate = 0.05M;
            break;
        case "CA":
            rate = 0.0825M;
            break;
        default:    //most US States
            rate = 0.06M;
            break;
    }

    return amount * rate;
}

///<summary> 
/// Pass a 32-bit integer and it will be converted into it's ordinal form
/// </summary>
/// <param name="number">Number is a cardinal value i.e. 1, 2, 3 and so on. </param>
/// <returns> Number as an ordinal value i.e. 1st, 3rd, 4th and so on.</returns>
static string CardinalToOrdinal(int number)
{
    switch (number)
    {
        case 11:    //specical case for 11 to 13
        case 12:
        case 13:
            return $"{number}th";
        default:
            int lastDigit = number % 10;

            string suffix = lastDigit switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
            return $"{number}{suffix}";
    }
}
static void RunCardinalToOrdinal()
{
    for (int number = 1; number <= 40; number++)
    {
        Write($"{CardinalToOrdinal(number)} " );
    }
    WriteLine();
}

static long Factorial(long number)
{ 
    /*
     * Note: this is a recursive function!
     * 
     * Recusion is clever but it can lead to problems such as a stack overflow due to too many function calls.
     * This is because memory is used to store data on every function call and it eventually uses too much. 
     * Iteration can be a more pratical solution in languages such as c#.
     */

    if(number < 1)
    {
        return 0;
    }
    else if(number == 1)
    {
        return 1;
    }
    else
    {
        checked    //check for overflow
        {
            return number * Factorial(number - 1);
        }
    }
}

static void RunFactorial()
{
    for(long i = 1; i < 25; i++)
    {
        try
        {
            WriteLine($"{i}! = {Factorial(i):N0}");
        }
        catch (System.OverflowException)
        {
            WriteLine($"{i}! is too big for a 64-bit integer");
        }
    }
}

static int FibImperitive(int term)
{
    if (term == 1)
    {
        return 0;
    }
    else if (term == 2)
    {
        return 1;
    }
    else
    {
        return FibImperitive(term - 1) + FibImperitive(term - 2);
    }
}

static int FibFunctional(int term) =>
    term switch
    {
        1 => 0,
        2 => 1,
        _ => FibFunctional(term - 1) + FibImperitive(term - 2)
    };

static void RunFibImperitive()
{
    for(int i = 1; i <= 30; i++)
    {
        WriteLine("The {0} term of the Fibonachi Sequence is {1:N0}.",
            CardinalToOrdinal(i),
            FibFunctional(i));
    }
}