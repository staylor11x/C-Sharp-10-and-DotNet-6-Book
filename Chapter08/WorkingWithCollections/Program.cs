using static System.Console;
using System.Collections.Immutable;

WorkingWithLists();
//WorkingWithDictionaries();
//WorkingWithQueues();
//WorkingWithPriorityQueues();


static void Output(string title, IEnumerable<string> collection)
{
    WriteLine(title);
    foreach(string item in collection)
    {
        WriteLine($"   {item}");
    }
}

static void WorkingWithLists()
{
    // Simple syntac for creating a list and adding three items
    List<string> cities = new();
    cities.Add("London");
    cities.Add("Paris");
    cities.Add("Milan");

    /* Alternative syntax that is converted by the compiler into the three add method calls above
    *    List<string> cities = new()
    *       {"London","Paris","Milan"};
    */

    /* Alternative syntax that passes an array of stirng values to an AddRange method
     * List<string> cities = new();
     * cities.AddRange(new[] {"London","Paris","Milan"});
     */

    Output("Initial list", cities);

    WriteLine($"The fist city in the list is {cities[0]}");
    WriteLine($"The last city in the list is {cities[cities.Count - 1]}");

    cities.Insert(0, "Sydney");

    Output("After inserting Sydney as postion 0", cities);

    cities.RemoveAt(1);
    cities.Remove("Milan");

    Output("AFter removing two cities", cities);

    //convert the list into an immutable list
    ImmutableList<string> immutableCities = cities.ToImmutableList();
    ImmutableList<string> newList = immutableCities.Add("Rio");

    Output("Immutable list of cities:", immutableCities);
    Output("New list of cities: ", newList);

}

static void WorkingWithDictionaries()
{
    Dictionary<string, string> keywords = new();

    // add using names parameters
    keywords.Add(key: "int", value: "32-bit integer data type");

    //add using positional parameters
    keywords.Add("long", "64-bit integer data type");
    keywords.Add("float", " Single Precision floating point number");

    /* Alternative syntax, compiler converts this to calls to Add method
     * Dictionary<string, string> keywords = new()
     * {
     *      {"int","32-bit integer data type"},
     *      {"long","64--bit integer data type"},
     *      {"float","Single-precision floating point number"},
     * };
     */

    /* Alternative syntax, compiler converts this to calls to Add method 
     * Dictionary<string, string> keywords = new()
     * {
     *      ["int"] = "32-bit integer data type",
     *      ["long"] = "64-bit integer data type",
     *      [float"] = "Single precision floating point number", //the last comma is optional!
     * };
     */

    Output("Dictionary keys: ", keywords.Keys);
    Output("Dictionary values: ", keywords.Values);

    WriteLine("Keywords and their definitions");
    foreach(KeyValuePair<string, string> item in keywords)
    {
        WriteLine($"   {item.Key}: {item.Value}");
    }

    // lookup a value using a key
    string key = "long";
    WriteLine($"The definition of {key} is {keywords[key]}");
}

static void WorkingWithQueues()
{
    Queue<string> coffee = new();

    coffee.Enqueue("Damir");    //front of the queue
    coffee.Enqueue("Andrea");
    coffee.Enqueue("Ronald");
    coffee.Enqueue("Amin");
    coffee.Enqueue("Irina");    //end of the queue

    Output("Initial queue from front to back: ", coffee);

    // server handles the next person in the queue
    string served = coffee.Dequeue();
    WriteLine($"Served: {served}");

    Output("The current queue from front to back: ", coffee);

    WriteLine($"{coffee.Peek()} is the next in line");

    Output("The current queue from front to back: ", coffee);
}

static void OutputPQ<TElement,TPriority>(string title, IEnumerable<(TElement Element, TPriority priority)> collection)
{
    WriteLine(title);
    foreach((TElement, TPriority) item in collection)
    {
        WriteLine($"   {item.Item1}:  {item.Item2}");
    }
}

static void WorkingWithPriorityQueues()
{
    PriorityQueue<string, int> vaccine = new();

    //add some people
    // 1 = high priority, people in their 70s or poor health
    // 2 = medium priority, eg middle aged
    // 3 = low priority, teens and twenties

    vaccine.Enqueue("Pamela", 1);
    vaccine.Enqueue("Rebecca", 3);
    vaccine.Enqueue("Juliet", 2);
    vaccine.Enqueue("Ian", 1);

    OutputPQ("Current queue for vaccination: ", vaccine.UnorderedItems);

    WriteLine($"{vaccine.Dequeue()} has been vaccinated");
    WriteLine($"{vaccine.Dequeue()} has been vaccinated");

    OutputPQ("Current queue for vaccination: ", vaccine.UnorderedItems);

    WriteLine($"{vaccine.Dequeue()} has been vaccinated");

    vaccine.Enqueue("Mark", 2);
    WriteLine($"{vaccine.Peek()} will ne vaccinated next");

    OutputPQ("Current queue for vaccination: ", vaccine.UnorderedItems);
}

