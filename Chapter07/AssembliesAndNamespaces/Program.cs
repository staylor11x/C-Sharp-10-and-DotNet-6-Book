﻿using System.Xml.Linq;
using System;
using Packt.Shared;
using static System.Console;
using DialectSoftware.Collections;
using DialectSoftware.Collections.Generics;
using System.Security.Principal;

XDocument doc = new();

string s1 = "Hello";
String s2 = "World";


WriteLine($"{s1} {s2}");

//Write("Enter a color value in hex: ");
//string? hex = ReadLine();   //or "00ffc8"
//
//WriteLine("Is {0} a valid color value? {1}",
//    arg0: hex, arg1: hex.IsValidHEx());
//
//Write("Enter a XML element: ");
//string? xmlTag = ReadLine();
//
//WriteLine("Is {0} a valid xml tag? {1}",
//    arg0: xmlTag, arg1: xmlTag.IsValidXmlTag());
//
//Write("Enter a valid passowrd");
//string? pass = ReadLine();
//
//WriteLine("Is {0} a valid password? {1}",
//    arg0: pass, arg1: pass.IsValidPassword());

Axis x = new("x", 0, 10, 1);
Axis y = new("y", 0, 4, 1);

Matrix<long> matrix = new(new[] { x, y });

for(int i = 0; i < matrix.Axes[0].Points.Length; i++)
{
    matrix.Axes[0].Points[i].Label = "x" + i.ToString();
}

for(int i = 0; i < matrix.Axes[1].Points.Length; i++)
{
    matrix.Axes[1].Points[i].Label = "y" + i.ToString();
}

foreach (long[] c in matrix)
{
    matrix[c] = c[0] + c[1];
}

foreach (long[] c in matrix)
{
    WriteLine("{0},{1} ({2}, {3}) = {4}",
        matrix.Axes[0].Points[c[0]].Label,
        matrix.Axes[1].Points[c[1]].Label,
        c[0], c[1], matrix[c]);
}