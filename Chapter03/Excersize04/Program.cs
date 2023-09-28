using static System.Console;

int number1 = -1;
int number2 = -1;

try
{
    Write("Enter a number between 0 and 255: ");
    number1 = int.Parse(ReadLine());
}
catch(FormatException)
{
    WriteLine("Please ensure input is of the correct format");    
}

try
{
    Write("Enter another number between 0 and 255: ");
    number2 = int.Parse(ReadLine());
}
catch(FormatException)
{
    WriteLine("Please ensure input is of the correct format");    
}

if((number1 > 255 || number2 > 255) || (number1 > 255 || number2 < 0))
{
    Write("Please ensure numbers are within range");
}

try
{
    WriteLine($"{number1} / {number2} = {number1/number2}");
}
catch(DivideByZeroException)
{
    Write("Infinity");
}