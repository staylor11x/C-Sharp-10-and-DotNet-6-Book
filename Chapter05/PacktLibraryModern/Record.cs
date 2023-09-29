using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

public class ImmutablePerson
{
    public string? FirstName { get; init; }
    public string ? LastName { get; init;}
}

public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string ? Color { get; init; }
    public string ? Brand { get; init; }

}

//public record ImmutableAnimal
//{
//    public string Name { get; init; }
//    public string Species { get; init; }
//}

//simpler way to define a record
//auto generates the properties, constructor and deconsstructor
public record ImmutableAnimal(string name, string species);


