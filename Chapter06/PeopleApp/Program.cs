using Packt.Shared;
using static System.Console;

Person harry = new() { Name = "Harry" };
Person mary = new() { Name = "Mary" };
Person jill = new() { Name = "Jill" };

// call instance method
Person baby1 = mary.ProcreateWith(harry);
baby1.Name = "Gary";

//call static method
Person baby2 = Person.Procreate(harry, jill);

//call an operator
Person baby3 = harry * mary;

WriteLine($"{harry.Name} has {harry.Children.Count} children.");
WriteLine($"{mary.Name} has {mary.Children.Count} children.");
WriteLine($"{jill.Name} has {jill.Children.Count} children.");
WriteLine(
    format: "{0}'s first child is named \"{1}\".",
    arg0: harry.Name,
    arg1: harry.Children[0].Name);

WriteLine($"5! is {Person.Factorial(5)}");

static void Harry_Shout(object? sender, EventArgs e)
{
    if (sender is null) return;
    Person p = (Person)sender;
    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
}

harry.Shout += Harry_Shout;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();


//non-generic Lookup collection
System.Collections.Hashtable lookupObject = new();

lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2; //lookup the value that had 2 as its key
WriteLine(format: "Key {0} has value: {1}",
    arg0: key,
    arg1: lookupObject[key]);

//lookup the value that has harry as its key
WriteLine(format: "Key {0} has value: {1}",
    arg0: harry,
    arg1: lookupObject[harry]);

//generic lookup collection
Dictionary<int, string> lookupIntString = new();

lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;
WriteLine(format: "Key {0} has value: {1}",
    arg0: key,
    arg1: lookupIntString[key]);


Person[] people =
{
    new() {Name = "Simon"},
    new() {Name = "Jenny"},
    new() {Name = "Adam"},
    new() {Name = "Richard"}
};


//sort using interface wihtin class
WriteLine("Initial list of people: ");
foreach(Person person in people)
{
    WriteLine($" {person.Name}");
}

WriteLine("Use Pseron's IComparable implementation to sort:");
Array.Sort(people);

foreach(Person p in people)
{
    WriteLine($" {p.Name}");
}


//sort using interface in seperate class, this sorts the names by length. If the names are the same length 
//then they are sorted alphabetically
WriteLine("Use PersonComparer's IComparer implementation to sort:");
Array.Sort(people, new PersonComparer());
foreach(Person p in people)
{
    WriteLine($" {p.Name}");

}


//Defining Struct Types
DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;

WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year: 1990, month: 7, day: 28)
};
john.WriteToConsole();

john.EmployeeCode = "JJ001";
john.HiredDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HiredDate:dd/MM/yy}");

WriteLine(john.ToString());

Employee aliceInEmployee = new()
{
    Name = "Alice",
    EmployeeCode = "AA123",
};

Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

/*
 * Casting with Inheritance hierarchies
*/

//if(aliceInPerson is Employee)
//{
//    WriteLine($"{nameof(aliceInPerson)} IS an employeee");
//    Employee explicitAlice = (Employee)aliceInPerson;   
//    //safely do something with explicitAlice
//}

if(aliceInPerson is Employee explicitAlice)
{
    //this also works the same as above
    WriteLine($"{nameof(aliceInPerson)} IS an employeee");
}

Employee? aliceAsEmployee = aliceInPerson as Employee;  //could be null

if(aliceAsEmployee != null)
{
    WriteLine($"{nameof(aliceAsEmployee)} AS Employee");
    //this is also an alternative, just always remember to check for null before using the result!
}

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch(PersonException ex)
{
    WriteLine(ex.Message);
}

//extending types when you cant inherrit

string email1 = "Pamela@test.com";
string email2 = "ian&test.com";

WriteLine("{0} is a valid email address: {1}",
    arg0: email1,
    arg1: email1.IsValidEmail()
    );

WriteLine("{0} is a valid email address: {1}",
    arg0: email2,
    arg1: email2.IsValidEmail()
    );