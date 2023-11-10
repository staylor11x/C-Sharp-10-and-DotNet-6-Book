using static System.Console;
using System.Text.RegularExpressions;

Write("Enter your age: ");
string? input = ReadLine();

Regex ageChecker = new(@"^\d+$");

if (ageChecker.IsMatch(input))
{
    WriteLine("Thank you");
}
else
{
    WriteLine($"this is not a valid age: {input}"); 
}

string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";

WriteLine($"Films to split: {films}");

string[] filmsDumb = films.Split(',');

WriteLine("Films split using the .split method: ");

foreach(string film in filmsDumb)
{
    WriteLine(film);
}

WriteLine();

Regex csv = new("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");

MatchCollection filmStart = csv.Matches(films);

WriteLine("Splitting with regular expressions: ");

foreach(Match film in filmStart)
{
    WriteLine(film.Groups[2].Value);
}