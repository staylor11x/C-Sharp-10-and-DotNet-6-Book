using System.Xml.Serialization;
using Packt.Shared;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using NewJson = System.Text.Json.JsonSerializer;

//create an object graph
List<Person> people = new()
{
    new(30000M)
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new(1974,3,14)
    },
    new(40000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new(1969,11,23)
    },
    new(20000M)
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new(1984,5,4),
        Children = new()
        {
            new(0M)
            {
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new(2000,7,12)
            }
        }
    }
};

// Create object that will format a list of persons as xml
XmlSerializer xs = new(people.GetType());

//create file to write to 
string path = Combine("People.xml");

using(FileStream stream = File.Create(path))
{
    //serialize the object graph to the stream
    xs.Serialize(stream,people);
}

WriteLine("Written {0:N0} bytes of XML to {1}", new FileInfo(path).Length, path);
WriteLine();

//display the serialized object graph
WriteLine(File.ReadAllText(path));

using(FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    //deserialize and cast the object into a list of person
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;

    if(loadedPeople is not null)
    {
        foreach(Person p in loadedPeople)
        {
            WriteLine($"{p.LastName} has {p.Children?.Count ?? 0} children.");
        }
    }
}


/*Working with JSON now!!*/

//create a file to write to
string jsonPath = Combine("people.json");

using(StreamWriter jsonStream = File.CreateText(jsonPath))
{
    //create an object that will format an JSON
    Newtonsoft.Json.JsonSerializer jss = new();

    //serialize the object graph into a string
    jss.Serialize(jsonStream, people);
}

WriteLine();
WriteLine("Written {0:N0} bytes of JSON to: {1}", new FileInfo(jsonPath).Length, jsonPath);

//display the serialized object graph
WriteLine(File.ReadAllText(jsonPath));

/*Using the new Json Option*/

using(FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    //deserialize object graph into List of person
    List<Person>? loadedPeople = await NewJson.DeserializeAsync(utf8Json:jsonLoad, returnType: typeof(List<Person>)) as List<Person>;

    if(loadedPeople is not null)
    {
        foreach(Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count ?? 0);
        }
    }
}