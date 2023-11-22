using System.Diagnostics;

using static System.Console;

OutPutThreadInfo();
Stopwatch timer = Stopwatch.StartNew();

/*
WriteLine("Running methods synchronously on one thread");
MethodA();
MethodB();
MethodC();
*/

/*
WriteLine("Running methods asynchronously on multiple threads");
Task taskA = new(MethodA);
taskA.Start();
Task taskB = Task.Factory.StartNew(MethodB);
Task taskC = Task.Run(MethodC);

Task[] tasks = {taskA,taskB,taskC};
Task.WaitAll(tasks);
*/

WriteLine("Passing the result of one task as the input to anther.");

Task<string> taskServicethenSProc = Task.Factory
    .StartNew(CallWebService)   //returns Task<decimal>
    .ContinueWith(prevoiousTask =>  //returns Task<string>
    CallStoredProcedure(prevoiousTask.Result));

WriteLine($"Result: {taskServicethenSProc.Result}");

WriteLine($"{timer.ElapsedMilliseconds:#,##0.00}ms elapsed");

static void OutPutThreadInfo()
{
    Thread t = Thread.CurrentThread;

    WriteLine("Thread Id: {0}, Priority: {1}, Background: {2}, Name: {3}",
        t.ManagedThreadId,t.Priority,t.IsBackground,t.Name);
}

static void MethodA()
{
    WriteLine("Starting method A...");
    OutPutThreadInfo();
    Thread.Sleep(3000); //simulate three seconds of work
    WriteLine("Finished method A");
}

static void MethodB()
{
    WriteLine("Starting method B...");
    OutPutThreadInfo();
    Thread.Sleep(2000); //simulate 2000 seconds of work
    WriteLine("Finished method B");
}

static void MethodC()
{
    WriteLine("Starting method C...");
    OutPutThreadInfo();
    Thread.Sleep(1000); //simulate 1000 seconds of work
    WriteLine("Finished method C");
}

static decimal CallWebService()
{
    WriteLine("Starting call to web service...");
    OutPutThreadInfo();
    Thread.Sleep(new Random().Next(2000,4000));
    WriteLine("Finished call to web service.");
    return 89.99M;
}

static string CallStoredProcedure(decimal amount)
{
    WriteLine("Starting call to stored procedure");
    OutPutThreadInfo();
    Thread.Sleep(new Random().Next(2000,4000));
    WriteLine("Finished call to stored procedure.");
    return $"12 products cost more than {amount:C}.";
}