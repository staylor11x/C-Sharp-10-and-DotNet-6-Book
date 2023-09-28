using static System.Console;

namespace Packt
{
    public class Calculator
    {
        public static void Gamma()
        {
            WriteLine("I'm Gamma!");
            Delta();
        }

        private static void Delta()
        {
            WriteLine("I'm Delta!");
            File.OpenText("Bad file path");
        }
    }
}