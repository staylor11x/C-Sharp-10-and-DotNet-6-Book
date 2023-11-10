/*Define Exension methods that extend number types such as big integer and int with a method named ToWords that 
 * returns a string describing the number; for example 18,000,000 would be eighteen million and 430,456 would be four hundred and 
 * thirty thousand four hundred and fifty six and so on
 * 
 * Possible needed words:
 * 
 * one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, 
 * thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen <-- these we can maybe skip out (thirteen and fifteen are exceptions)
 * 
 * tewnty, thirty, fourty, fifty, sixty, seventy, eighty, ninty
 * 
 * Hundred, Thousand, Million, Billion, Trillion, ... , infinity
 * 
 * 
 * THis is not the best solution in the world but it works, just a lot of repeating code
 * 
 * Here is a link to a similar example: https://www.c-sharpcorner.com/article/convert-numeric-value-into-words-currency-in-c-sharp/
 * 
 * Here is the solution from the book:https://github.com/markjprice/cs10dotnet6/blob/main/vs4win/Chapter08/Exercise03/NumbersToWords.cs
 * 
 * The books solution is COMPLETLEY different!! Very smart i can imagine however
 * 
 */


using static System.Console;

Write("Enter a number to convert to words! ");
string userInput = ReadLine();

if(userInput.Length == 1)
{
    string convertedNumber = ConvertOnes(userInput);
    WriteLine($"Here is your converted number: {convertedNumber}");
}
else if(userInput.Length == 2)
{
    string convertedNumber = ConvertTens(userInput);
    WriteLine($"Here is your converted number: {convertedNumber}");
}
else if(userInput.Length >= 3)
{
    string convertedNumber = ConvertHigherOrder(userInput);
    WriteLine($"Here is your converted number: {convertedNumber}");
}


string ConvertOnes(string value)
{//convert the first 9 values 

    string result = "";

    switch(value)
    {
        case "1":
            result =  "one";
            break;
        case "2":
            result = "two";
            break;
        case "3":
            result = "three";
            break;
        case "4":
            result = "four";
            break;
        case "5":
            result = "five";
            break;
        case "6":
            result = "six";
            break;
        case "7":
            result = "seven";
            break;
        case "8":
            result = "eight";
            break;
        case "9":
            result = "nine";
            break; 
    }
    return result;

}


string ConvertTens(string value)
{
    string result = "";

    switch (value)
    {
        case "10":
            result = "ten";
            break;
        case "11":
            result = "eleven";
            break;
        case "12":
            result = "twelve";
            break;
        case "13":
            result = "thirteen";
            break;
        case "14":
            result = "fourteen";
            break;
        case "15":
            result = "fifteen";
            break;
        case "16":
            result = "sixteen";
            break;
        case "17":
            result = "seventeen";
            break;
        case "18":
            result = "eighteen";
            break;
        case "19":
            result = "nineteen";
            break;
        case "20":
            result = "twenty ";
            break;
        case "30":
            result = "thirty ";
            break;
        case "40":
            result = "fourty ";
            break;
        case "50":
            result = "fifty ";
            break;
        case "60":
            result = "sixty ";
            break;
        case "70":
            result = "seventy ";
            break;
        case "80":
            result = "eighty ";
            break;
        case "90":
            result = "ninety ";
            break;
        default:
            //if the number contains anything other than 0 as its second number then replace it with zero, and ca
            // the first function on the first number 
            result = ConvertTens(value.Substring(0,1) + '0') + ConvertOnes(value.Substring(1));
            break;
    }
    return result;
}


string ConvertHigherOrder(string value)
{
    int numberDigits = value.Length;
    string result = "";
        
    switch (numberDigits)
    {
        case 1:
            result = ConvertOnes(value); break;
        case 2:
            result = ConvertTens(value); break;
        case 3:     //hundreds range
            // Take the fist number, convert it and then stick 'hundred' on the end?
            string x = ConvertOnes(value.Substring(0, 1));
            string y = ConvertTens(value.Substring(1, 2));
            result = x + " hundred and " + y;
            break;
        case 4: //thousands range
            //take the first number, convert it and then stick 'thousand on the end, then run case three on the number
            x = ConvertOnes(value.Substring(0, 1));
            y = ConvertHigherOrder(value.Substring(1, 3));
            result = x + " thousand " + y;
            break;
        case 5: //then thousands range
            //take the first two numbers, then stick thousand on the end and run case 3
            x = ConvertTens(value.Substring(0, 2));
            y = ConvertHigherOrder(value.Substring(2, 3));
            result = x + " thousand " + y;
            break;
        case 6: //hunderd thousands range
            x = ConvertHigherOrder(value.Substring(0, 3));
            y = ConvertHigherOrder(value.Substring(3));
            result = x + " thousand " + y;
            break;
        case 7: //millions range
            x = ConvertOnes(value.Substring(0, 1));
            y = ConvertHigherOrder(value.Substring(1, 6));
            result = x + " million " + y;
            break;
        case 8:
            x = ConvertTens(value.Substring(0, 2));
            y = ConvertHigherOrder(value.Substring(2, 6));
            result = x + " million " + y;
            break;
        default:
            result = "Something else has happened";
            break;
    }

    return result;
    
}