using Packt.Shared;
using static System.Console;

Person bob = new();
bob.Name = "bob smith";
bob.DateOfBirth = new DateTime(1965, 12, 22);
bob.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
bob.Children.Add(new Person { Name = "Alfred" });   //C# 3.0 and later
bob.Children.Add(new() { Name = "Zoe" });   //C# 9.0 and later

WriteLine(format:"{0} was born on {1:dddd, d MMMM yyyy}", bob.Name, bob.DateOfBirth);
WriteLine("{0}'s favourite wonder is {1}. It's integer is {2}.", bob.Name, bob.FavouriteAncientWonder, (int)bob.FavouriteAncientWonder);
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
WriteLine($"{bob.Name} has {bob.Children.Count} children");
WriteLine($"{bob.Name} is a {Person.Species}");
WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

foreach(Person child in bob.Children)
{
    WriteLine($"{child.Name}");
}

Person alice = new()
{
    Name = "Alice Slowey",
    DateOfBirth = new(1998, 3, 7)
};

WriteLine("{0} was born on the {1:dd MM yy}", alice.Name, alice.DateOfBirth);

BankAccount.InterestRate = 0.012M;  //stores a shared value

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;

WriteLine("{0} earned {1:C} interest.", jonesAccount.AccountName, jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Mrs. Gerrier";
gerrierAccount.Balance = 98;

WriteLine("{0} earned {1:C} interest.", gerrierAccount.AccountName, gerrierAccount.Balance * BankAccount.InterestRate);


Person blankPerson = new();

WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.", blankPerson.Name, blankPerson.HomePlanet, blankPerson.Instansiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine("{0} of {1}, was created at {2:hhh:mm:ss} on a {2:dddd}.", gunny.Name, gunny.HomePlanet, gunny.Instansiated);

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

(string Name, int Number) fruit = bob.GetFruit();
WriteLine($"{fruit.Name}, {fruit.Item2} there are. ");

(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

//deconstructing a person
var (name1, dob1) = bob;
WriteLine($"Deconstructed: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");