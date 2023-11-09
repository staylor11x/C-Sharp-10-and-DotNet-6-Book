using System.Globalization;
using static System.Console;

string city = "London";
WriteLine($"{city} is {city.Length} charcters long");
WriteLine($"The first char is {city[0]} and the third is {city[2]}");

string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellin";

string[] citiesArray = cities.Split(',');

WriteLine($"There are {citiesArray.Length} items in the array.");
foreach(string item in citiesArray)
{
    WriteLine(item);
}

string fullName = "Alan Jones";
int indexOfTheSpace = fullName.IndexOf(' ');

string firstName = fullName.Substring(0, indexOfTheSpace);

string lastName = fullName.Substring(indexOfTheSpace + 1);

WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");

string company = "Microsoft";
bool startsWithM = company.StartsWith('M');
bool containsN = company.Contains("N");
WriteLine($"Text: {company}");
WriteLine($"Starts with M: {startsWithM}, contains an N: {containsN}");

string recombined = string.Join(" => ", citiesArray);
WriteLine(recombined);

string fruit = "Apples";
decimal price = 0.39M;
DateTime when = DateTime.Today;

//using the + operator, or string.Concat to concatonate strings is bad practice as .NET must create a completley new string in memory!!!

WriteLine($"Ineterpolated: {fruit} cost {price:C} on {when:dddd}");
WriteLine(string.Format("stirng.Format: {0} cost {1:C} on {2:dddd}.",
    arg0: fruit, arg1: price, arg2: when));