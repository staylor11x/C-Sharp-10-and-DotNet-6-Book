using static System.Console;

int max = 255;

if(max > 255)
{
    WriteLine("Value must be between 0 and 255");
}

for(byte i=0; i < max; i++)
{
    WriteLine(i);
}

