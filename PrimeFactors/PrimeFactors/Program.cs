using static System.Console;
using PrimeFactorsLib;

static void GetPrimeFactors()
{
    int number = 40;

    string factors = PrimeFactorsClass.PrimeFactors(number);
    WriteLine($"The prime factors of {number} are: {factors}");
}

GetPrimeFactors();