using static System.Console;

WriteLine(
    "{0,-10} {1,6} {2,6} {3,6}",
    "Type",
    "Byte(s) of memory",
    "Min",
    "Max");

WriteLine(
    "{0,-10} {1,6} {2,6} {3,6}",
    typeof(sbyte),
    sizeof(sbyte),
    sbyte.MinValue,
    sbyte.MaxValue);
