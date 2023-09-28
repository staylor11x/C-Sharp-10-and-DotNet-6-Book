using static System.Console;
using static System.Convert;

int a = 10;
double b = a; //am int can be safely cast to a double
WriteLine(b);

double c = 9.8;
int d = (int)c; //needs to be done as an explicit cast, you will lose any precision after the decimal point!
WriteLine(d);

long e = 10;
int f = (int)e;
WriteLine($"e is {e:N0} and f is {f:N0}");
e = 5_000_000_000_000;
f = (int)e;
WriteLine($"e is {e:N0} and f is {f:N0}");

double g = 9.8;
int h = ToInt32(g); //this will round the value instead of trimming the decimal point!
WriteLine($"g is {g} and h is {h}");

//wierdly this will round the up if the decimal part is grater than .5 AND the number is odd, but down if the number is odd. How odd.
//This is known as bankers rounding and is is preffered becuse is reduces rounding bias! Other languages such as JavaScript use the standard rule

double[] doubles = new[] { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };

foreach(double n in doubles)
{
    WriteLine($"ToInt32({n} is {ToInt32(n)}");
}

//You can also specify what kind of rounding you would like using the math module.

foreach(double n in doubles)
{
    WriteLine(format: "Math.Round({0}, 0, MidpointRounding.AwayFromZero is {1}",
        arg0: n,
        arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero));
}


int number = 12;
WriteLine(number.ToString());

bool boolean = true;
WriteLine(boolean.ToString());

DateTime now = DateTime.Now;
WriteLine(now.ToString());

object me = new();
WriteLine(me.ToString());


//allocate an array of 128 bytes
byte[] binaryObject = new byte[128];

//populate array with random bytes
(new Random()).NextBytes(binaryObject);

WriteLine("Binary object as bytes:");

for(int index = 0; index< binaryObject.Length; index++)
{
    Write($"{binaryObject[index]:X} ");
}
WriteLine();

//convert to Base64 string and output as text
string encoded = ToBase64String(binaryObject);

WriteLine($"Binary Object as Base64: {encoded}");

int age = int.Parse("27");
DateTime birthday = DateTime.Parse("4 July 1980");

WriteLine($"I was born {age} years ago.");
WriteLine($"My birthday is {birthday}.");
WriteLine($"My birthday is {birthday:D}");  //other date formats are avaliable


Write("How many eggs are there? ");
string? input = ReadLine();

if(int.TryParse(input, out int count))
{
    WriteLine($"There are {count} eggs.");
}
else
{
    WriteLine("I could not parse the input");
}