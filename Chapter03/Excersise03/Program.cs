using static System.Console;


/*
 * Create a loop that counts from 0 to 100
 * If the number is divisible by 3, replace with "fizz"
 * If the number is divisible by 5, replace with "buzz"
 * If the number is divisible by 5 and 3, replace with buzz
 * 
 * 
 */

for(int i = 1; i <= 100; i++)
{
    if((i % 3 == 0) && (i % 5 == 0))
    {
        Write("FizzBuzz, ");
    }
    else if(i % 3 == 0)
    {
        Write("Fizz, ");
    }
    else if(i % 5 == 0)
    {
        Write("Buzz, ");
    }
    else
    {
        Write($"{i}, ");
    }
}