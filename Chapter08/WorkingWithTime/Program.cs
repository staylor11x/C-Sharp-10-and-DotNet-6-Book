﻿using static System.Console;
using System.Globalization;

WriteLine("Earliest datetime value is : {0}",
    arg0: DateTime.MinValue);

WriteLine("Latest dattime value is: {0}",
    arg0: DateTime.MaxValue);

WriteLine("UNIX epoch dat/time value is: {0}",
    arg0: DateTime.UnixEpoch);

WriteLine("Date/TIme value now is {0}",
    arg0: DateTime.Now);

WriteLine("Date/Time value today is {0}",
    arg0: DateTime.Today);

DateTime christmas = new(year: 2023, month: 12, day: 25);

WriteLine("Chirstmas {0}", arg0: christmas);    //defualt format
WriteLine("Christmas {0:dddd, dd MMMM yyyy}", christmas);
WriteLine("Christmas is in month {0} of the year.", christmas.Month);
WriteLine("Christmas is the {0} day of the yeas", christmas.DayOfYear);
WriteLine("Christams {0} is on a {1}.", christmas.Year, christmas.DayOfWeek);

DateTime beforeXmas = christmas.Subtract(TimeSpan.FromDays(12));
DateTime afterXmas = christmas.AddDays(12);

WriteLine("12 days before christmas is: {0}", beforeXmas);
WriteLine("12 days after christmas is: {0}", afterXmas);

TimeSpan untillXmas = christmas - DateTime.Now;

WriteLine("There are {0} days and {1} hours untill christmas.", untillXmas.Days, untillXmas.Hours);

WriteLine("There are {0:N0} hours untill Christmas.", untillXmas.TotalHours);

WriteLine("There are {0} weeks untill Christmas", untillXmas.Days / 7);

DateTime kidsWakeUp = new(year: 2023, month: 12, day: 25, hour: 6, minute: 30, second: 0);

WriteLine("Kids wake up on Christmas: {0}", kidsWakeUp);
WriteLine("The kids woke me up at {0}", kidsWakeUp.ToShortTimeString());

WriteLine("Current culture is: {0}", CultureInfo.CurrentCulture.Name);

string textDate = "4 July 2021";
DateTime independanceDay = DateTime.Parse(textDate);

WriteLine("Text: {0}, DateTime: {1:d MMMM}", textDate, independanceDay);

textDate = "7/4/2021";
independanceDay = DateTime.Parse(textDate);

WriteLine("Text: {0}, DateTime: {1:d MMMM}", textDate, independanceDay);

independanceDay = DateTime.Parse(textDate, provider:CultureInfo.GetCultureInfo("en-US"));

WriteLine("Text: {0}, DateTime: {1:d MMMM}", textDate, independanceDay);



for(int year = 2020; year < 2026; year++)
{
    Write($"{year} is a leap year: {DateTime.IsLeapYear(year)}.");
    WriteLine("There are {0} daye in Feburary {1}.",
        DateTime.DaysInMonth(year: year, month: 2), year);
}

WriteLine("Is Christmas daylight saving time? {0},", christmas.IsDaylightSavingTime());

WriteLine("Is July 4th daylight saving time? {0}", independanceDay.IsDaylightSavingTime());

DateOnly queensBirthday = new(year: 2022, month: 4, day: 21);
WriteLine($"The Queen's birthday is on {queensBirthday}");

TimeOnly partyStarts = new(hour: 20, minute: 30);
WriteLine($"The Queen's party starts at {partyStarts}");

DateTime calanderEntry = queensBirthday.ToDateTime(partyStarts);
WriteLine($"Add to your calendar: {calanderEntry}.");