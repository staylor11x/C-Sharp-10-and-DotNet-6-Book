using System.Runtime.CompilerServices;
using static System.Console;

Task outerTask = Task.Factory.StartNew(OuterMethod);
outerTask.Wait();
WriteLine("Console app is stopping");

static void OuterMethod()
{
    WriteLine("Outer method starting...");
    Task innerTask = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent);  //what makes a parent-child combo
    WriteLine("Outer method finished.");
}

static void InnerMethod()
{
    WriteLine("Inner method starting...");
    Thread.Sleep(2000);
    WriteLine("Inner method finished.");
}