using static System.Console;

WriteLine("I can run everywhere");

if (OperatingSystem.IsMacOS())
{
    WriteLine("I am MacOS");
}
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
{
    WriteLine("I am Windows");
}
else
{
    WriteLine("I am some other mysterious operating system");
}

WriteLine("Press enter to stop me");
ReadLine();
