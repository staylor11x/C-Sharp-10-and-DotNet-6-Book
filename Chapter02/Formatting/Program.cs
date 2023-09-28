// See https://aka.ms/new-console-template for more information

using static System.Console;

int numberOfApples = 12;
decimal pricePerApple = 0.35M;

WriteLine(
    format: "{0} apples costs {1:C}",
    arg0: numberOfApples,
    arg1: pricePerApple * numberOfApples
    );

//string formatted = string.Format(
//    format: "{0} apples costs {1;C}",
//    arg0: numberOfApples,
//    arg1: pricePerApple * numberOfApples
//    );

//WriteToFile(formatted); //Writes the formatted string to a file

WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples:C}");

string applesText = "Apples";
int applesCount = 1234;

string bannanasText = "Bannanas";
int bannanasCount = 56789;

WriteLine(
    "{0,-10} {1,6}",
    "Name",
    "Count");

WriteLine(
    "{0,-10} {1,6:N0}",
    applesText,
    applesCount);

WriteLine(
    "{0,-10} {1,6:N0}",
    bannanasText,
    bannanasCount);


WriteLine("Type your first name and then press ENTER: ");
string? firstName = ReadLine();

WriteLine("Type your age and then press ENTER: ");
string? age = ReadLine();

WriteLine($"Hello {firstName}, you look good for your {age}.");


Write("Press any key conbination: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();
WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
    key.Key,
    key.KeyChar,
    key.Modifiers);