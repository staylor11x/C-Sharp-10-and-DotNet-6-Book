﻿using static System.Console;

static double Add(double a, double b)
{
    return a + b;
}

double a = 4.5;
double b = 2.5;
double answer = Add(2, 5);
WriteLine($"{a} + {b} = {answer}");

WriteLine("Press enter to close the app.");
ReadLine();