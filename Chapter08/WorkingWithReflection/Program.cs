using static System.Console;
using System.Reflection;    //assembly
using System.Runtime.CompilerServices;  //Complier generated attribute
using Packt.Shared;

WriteLine("Assembly metadata:");
Assembly? assembly = Assembly.GetEntryAssembly();

if(assembly is null)
{
    WriteLine("Failed to get assembly");
    return;
}

WriteLine($"  Full Name: {assembly.FullName}");
WriteLine($"  Location:  {assembly.Location}");

IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();

WriteLine($"  Assembly-level attributes:");
foreach( Attribute a in attributes)
{
    WriteLine($"  {a.GetType()}");
}

AssemblyInformationalVersionAttribute? version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

WriteLine($"  Version: {version?.InformationalVersion}");

AssemblyCompanyAttribute? company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();

WriteLine($"  Company: {company?.Company}");


WriteLine();
WriteLine($"* Types");
Type[] types = assembly.GetTypes();

foreach(Type type in types)
{
    WriteLine();
    WriteLine($"Type: {type.FullName}");
    MemberInfo[] members = type.GetMembers();
    
    foreach(MemberInfo member in members)
    {
        WriteLine("{0}: {1} ({2})", member.MemberType, member.Name, member.DeclaringType?.Name);

        IOrderedEnumerable<CoderAttribute> coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);

        foreach(CoderAttribute coder in coders)
        {
            WriteLine("-> Modified by {0} on {1}", coder.Coder, coder.LastModified.ToShortDateString());
        }
    }
}



class Animal
{
    [Coder("Mark Price", "22 August 2021")]
    [Coder("Scott Taylor", "10 November 2023")]
    public void Speak()
    {
        WriteLine("Woof");
    }
}