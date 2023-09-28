using System.Runtime.InteropServices.ObjectiveC;
using static System.Console;

string password = "ninja";

if(password.Length < 8)
{
    WriteLine($"Your password is too short, please enter a password greater than {8} chactacters");
}
else
{
    WriteLine("Your password is strong");
}

//add and remove the "" to change the behaviour

object o = 3;
int j = 4;

if (o is int i)
{
    WriteLine($"{i} x {j} = {i*j}");
}
else
{
    WriteLine("o is not an int!!");
}

int number = (new Random()).Next(1, 7);
WriteLine($"My random number is {number}");

switch (number)
{
    case 1:
        WriteLine("One");
        break;  //jumps to the end of the switch statement
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3: //mulitple case section

    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
        goto A_label;
    default:
        WriteLine("Default");
        break;
}//end of switch statement

WriteLine("After the end of switch");
A_label:
WriteLine($"After A_label");

//string path = "C:\Users\scott\OneDrive\Dev\C# Course\Chapter03";
string path = @"C:\Users\scott\OneDrive\Dev\C# Course\Chapter03";

Write("Press R for read-only or W for writable: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();

Stream? s;

if (key.Key == ConsoleKey.R)
{
    s = File.Open(
        Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate,
        FileAccess.Read);
}
else
{
    s = File.Open(
        Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate,
        FileAccess.Write);
}

string message;

switch (s)
{
    case FileStream writableFile when s.CanWrite:
        message = "The stream is a file that i can write to";
        break;
    case FileStream readonlyFile:
        message = "The stream is a read-only file";
        break;
    case MemoryStream ms:
        message = "The stream is a memory address";
        break;
    default:    //always evaluated last despitre its current position
        message = "The stream is some other type";
        break;
    case null:
        message = "The stream is null";
        break;
}

WriteLine(message);

//or using switch expressions, this looks very swanky

message = s switch
{
    FileStream writeableFile when s.CanWrite => "The stream is a file I can write to",
    FileStream readonlyFile => "The stream is a read-only file",
    MemoryStream ms => "The stream is a memory address",
    null => "The stream is null",
    _ => "The stream is some other type"
};

WriteLine(message);