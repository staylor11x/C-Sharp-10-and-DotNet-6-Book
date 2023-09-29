using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Packt.Shared
{
    public partial class Person
    {
        //fields
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person> ();
        public const string Species = "Homo Sapiens";

        //read only fields - it is better pracitce to use these instead of const fields, this is becuase it uses a live value. 
        // if you use a const value then change the value, you must ensure that all the nessecary assemblies (ones that use this value) are recompiled!!
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instansiated;

        //constructors
        public Person()
        {
            //set the default values for fields
            //including the read-only fields
            Name = "Unknowm";
            Instansiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instansiated = DateTime.Now;
        }

        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on {DateOfBirth:dddd}.");
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}.";
        }

        public (string Name, int Number) GetFruit()
        {
            return (Name: "Apples", Number: 5);
        }

        public void Deconstruct(out string name, out DateTime dob)
        {
            name = Name;
            dob = DateOfBirth;
        }

        public void Deconstruct(out string name, out DateTime dob, out WondersOfTheAncientWorld fav)
        {
            name = Name;
            dob = DateOfBirth;
            fav = FavouriteAncientWonder;
        }

        public string SayHello()
        {
            return $"{Name} says 'Hello!";
        }

        public string SayHello(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }

        public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true)
        {
            return string.Format("Command is {0}, number is {1}, active is {2}", command, number, active);
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            //Out parameters cannot have a defualt value AND they must be initialised within the method
            z = 99;
            //increment each param
            x++;
            y++;
            z++;
        }
    }
}
