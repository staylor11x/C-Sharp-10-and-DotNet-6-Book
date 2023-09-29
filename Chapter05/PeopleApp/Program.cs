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

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Jack"));

WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters("Jump!", 98.5));
WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
WriteLine(bob.OptionalParameters(number: 0, active: false));    //use named parameters to skip over optional parameters

int a = 10;
int b = 20;
int c = 30;

WriteLine($"Before: a = {a}, b = {b}, c = {c}");
bob.PassingParameters(a, ref b, out c);
WriteLine($"After: a = {a}, b = {b}, c = {c}");

int d = 10;
int e = 20;

WriteLine($"Before: d = {d}, e = {e}, f = dosen't exist yet!");

//simplified C# 7.0 or later syntax for an out parameter
bob.PassingParameters(d, ref e, out int f);
WriteLine($"After: d = {d}, e = {e}, f = {f}");

Person sam = new()
{
    Name = "Sam",
    DateOfBirth = new(1972, 1, 27)
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

sam.FavouriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favourite ice cream is {sam.FavouriteIceCream}.");

sam.FavoritePrimaryColor = "Red";

WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}");

sam.Children.Add(new() { Name = "Charlie" });
sam.Children.Add(new() { Name = "Ella" });

WriteLine($"Sam's first child is {sam.Children[0].Name}");          //using the longer children syntax
WriteLine($"Sam's second child is {sam.Children[1].Name}");

WriteLine($"Sam's first child is {sam[0].Name}");       //using the indexer method and syntax
WriteLine($"Sam's first child is {sam[1].Name}");


object[] passengers =
{
    new FirstClassPassenger {AirMiles = 1_419},
    new FirstClassPassenger {AirMiles = 16_562},
    new BusinessClassPassenger{},
    new CoachClassPassenger { CarryOnKG = 25.7},
    new CoachClassPassenger { CarryOnKG = 0},
};

foreach(object passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        /* C# 8 Syntax
        FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
        FirstClassPassenger _ => 2000M, */

        //C# 9 or later syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35000 => 1500M,
            > 15000 => 1750M,
            _ => 2000M,
        },

        BusinessClassPassenger _ => 1000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}


ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger"
};

ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4
};

ImmutableVehicle repaintedCar = car with { Color = "PloyMetal Grey Metallic" };

WriteLine($"Original car color was {car.Color}");
WriteLine($"New car color is {repaintedCar.Color}");

ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar;    //calls the deconstruct method
WriteLine($"{who} is a {what}");