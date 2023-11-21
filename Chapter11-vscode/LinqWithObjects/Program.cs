using static System.Console;

// a string array is a sequence that implements IEnumerable<string>
string[] names = new[] {"Michael","Pam","Jim","Dwight","Angela","Kevin","Toby","Creed"};

WriteLine("Deffered Execution");

//Question: which name ends with an M?
//Writeen using a linq extension method
var querey1 = names.Where(name => name.EndsWith("m"));

//Question: Which names end with an M?
//Written using lin querey comprehension syntax
var querey2 = from name in names where name.EndsWith("m") select name;

//answer is returned as an array of strings containing Pam and Jim
string[] result1 = querey1.ToArray();

//answer returned as a list of strings containing Pam and Jim
List<string> result2 = querey2.ToList();

//answer returned as we enumerate over the results
foreach(string name in querey1)
{
    WriteLine(name);    //outputs Pam
    WriteLine();
    names[2] = "Jimmy"; //change jim to jimmy
    //on the second iteration jimmy does not end with an m, due to deffered execution this means it is not shown
}

//var query = names.Where(new Func<string,bool>(NamesLongerThanFour));  //the 1st way

//var query = names.Where(NamesLongerThanFour);     //the 2nd way

IOrderedEnumerable<string> query = names        //start the querey off with var, then when you are finished change it to a solid type
    .Where(name => name.Length > 4)   //the 3rd way! The best because is uses lambda expression and they are cool!
    .OrderBy(name => name.Length)      //format the expressions like this because its easier to read.
    .ThenBy(name => name);

foreach(string item in query)
{
    WriteLine(item);
}



static bool NamesLongerThanFour(string name)
{
    return name.Length > 4;
}

WriteLine("Filtering by type");

List<Exception> exceptions = new()
{
    new ArgumentException(),
    new SystemException(),
    new IndexOutOfRangeException(),
    new InvalidOperationException(),
    new NullReferenceException(),
    new InvalidDataException(),
    new OverflowException(),
    new DivideByZeroException(),
    new ApplicationException()
};

IEnumerable<ArithmeticException> arithmeticExceptionsQuery = exceptions.OfType<ArithmeticException>();

foreach(ArithmeticException exception in arithmeticExceptionsQuery)
{
    WriteLine(exception);
}