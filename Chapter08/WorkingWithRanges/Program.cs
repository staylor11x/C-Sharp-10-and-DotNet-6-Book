using static System.Console;

string name = "Samantha Jones";

// Using Substring

int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

string firstName = name.Substring(startIndex:0, length:lengthOfFirst);

string lastName = name.Substring(startIndex:name.Length - lengthOfLast, length:lengthOfLast);

WriteLine($"Fist name: {firstName}, Last Name: {lastName}");

// using spans

ReadOnlySpan<char> nameAsSpan = name.AsSpan();
ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst];
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..^0];

WriteLine("Fist name: {0}, last name: {1}", firstNameSpan.ToString(), lastNameSpan.ToString() );