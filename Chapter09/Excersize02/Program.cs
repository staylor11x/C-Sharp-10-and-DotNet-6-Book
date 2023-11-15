﻿/* Create a console app that creates a list of shapes and uses serialization to save it to the filesystem using XML and then 
deserialzes it back
*/

using static System.Console;
using Packt.Shared;
using System.ComponentModel;
using static System.IO.Path;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using NewJson = System.Text.Json;
using Newtonsoft.Json.Linq;

//create a list of shapes 
List<Shape> listOfShapes = new()
{
    new Circle{Color= "Yellow", Radius=0.2},
    new Circle{Color = "Blue",Radius = 5.4},
    new Square{Color = "Red", Height = 4.8},
    new Rectangle{Color = "Green", Width=4.5,Height=7.8},
    new Square{Color="Purple",Height=4.6}
};

foreach(Shape shape in listOfShapes)
{
    WriteLine(shape);
}


//create a file to write to 
string jsonPath = Combine("shapes.json");

using(StreamWriter jsonStream = File.CreateText(jsonPath))
{
    //create an object that will format in json
    Newtonsoft.Json.JsonSerializer serializer = new();

    //serialise the obejct into a string
    serializer.Serialize(jsonStream,listOfShapes);
}

WriteLine();
WriteLine("Written {0:N0} bytes of JSON to: {1}", new FileInfo(jsonPath).Length, jsonPath);

WriteLine(File.ReadAllText(jsonPath));

//the information is now stored in the file!

//Now to deserialise, this could be a little more complcated than first anticipated
// Frst of all, how does it know what knd of object is is tryng to deserialise?

using(FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
using(StreamReader jsonReader = new StreamReader(jsonLoad))
using(JsonReader reader = new JsonTextReader(jsonReader))
{
    JsonSerializer deserializer = new Newtonsoft.Json.JsonSerializer();
    List<Shape>? loadedShapes = deserializer.Deserialize<List<Shape>>(reader);

    if(loadedShapes is not null)
    {
        foreach(Shape shape in loadedShapes)
        {
            WriteLine("{0} is {1} and has an area of {2:N2}", shape.GetType(), shape.Color, shape.Area);
        }
    }
}