// See https://aka.ms/new-console-template for more information

using System.Xml;

object height = 1.88;   //storing a double in an object
object name = "amir";   //storing a string in an object
Console.WriteLine($"{name} is {height} meters tall.");

//int length1 = name.Length;  //gives compile error
int length2 = ((string)name).Length;    //tell the compiler it is a string
Console.WriteLine($"{name} has {length2} characters.");

//storing a string in a dynamic object
//string has a length property
//dynamic something = "Amhed";

//int does not have a length property
//dynamic something = 12;

//an array of any type has a length property
dynamic something = new[] {3,5,7};

//this compiles but would throw an exception at run time if you later store a data type that does not have a property named length
Console.WriteLine($"Length is {something.Length}");

var population = 66_000_000;
var weight = 1.88;
var price = 4.99M;
var fruit = "Apples";   //strings use double quotes
var letter = 'Z';       //chars use single quotes
var happy = true;       //I am alwways happy!

//good use of var because it avoids the repeated type, as shown in the more verbose second statement
var xml1 = new XmlDocument();
XmlDocument xml2 = new XmlDocument();

//bad use of var because we cannot tell the type, so we should use a specific type declartaion as shown in the second statement
var file1 = File.CreateText("something.txt");
StreamWriter file2 = File.CreateText("something2.txt");

//default types
Console.WriteLine($"default(int) = {default(int)}");
Console.WriteLine($"dafault(bool) = {default(bool)}");
Console.WriteLine($"default(DateTime) = {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}");

int number = 13;
Console.WriteLine($"Number has been set to: {number}");
number = default;
Console.WriteLine($"Number has been reset to: {number}");


string[] names;     //can reference any size array of strings

//allocating memory for four strings in an array
names = new string[4];

//storing items at indexed positions
names[0] = "Kate";
names[1] = "Jack";
names[2] = "Rebecca";
names[3] = "Tom";

//looping througth the names
for (int i=0; i < names.Length; i++)
{
    //output the item as index position i
    Console.WriteLine(names[i]);
}

