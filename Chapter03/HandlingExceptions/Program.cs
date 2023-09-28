using static System.Console;

WriteLine("Before Parsing");
Write("What is your age: ");
string? input = ReadLine();

//the order in which you catch the exceptions is important and is related to the inheritance hierachy of the exception types
//The compiler will likely thow a build error if the excpetions are in the wrong order!

try
{
    int age = int.Parse(input);
    WriteLine($"You are {age} years old.");
}
catch (FormatException)
{
    WriteLine("The age you have entered is not a valid number format");
}
catch(OverflowException)
{
    WriteLine("The age you have entered is a valid number format but it is either too large or too small");
}
catch(Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
WriteLine("After Parsing");