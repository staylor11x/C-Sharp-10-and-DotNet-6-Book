using Excersise02;
using static System.Console;

/*
 * More than one way to skin le chat with this question 
 */

Rectangle r = new Rectangle(5,8);
WriteLine($"Square H: {r.Height}, W: {r.Width}, Area: {r.Area}");

Square s = new(5);
WriteLine($"Square H: {s.Height}, W: {s.Width}, Area: {s.Area}");

Circle c = new(5);
WriteLine($"Circle R: {c.Radius}, Area: {c.Area}");