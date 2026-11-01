using System;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine(new Week(Week.WeekType.hebdad));
        Console.WriteLine(new Week(Week.WeekType.ogdad));
        Console.WriteLine();

        int common = 0;
        int leap = 0;

        for (int m = 1; m <= Month.PerYear; m++)
        {
            common += new Month(m, 2021).Days;
            leap += new Month(m, 2020).Days;
        }

        // Must match OctonaryCalendar.DaysToMonth365[9] and [9] for leap years.
        Console.WriteLine($"2021 (common): {common} days");
        Console.WriteLine($"2020 (leap):   {leap} days");
        Console.WriteLine();

        Console.WriteLine(new Month(1, 2021));
        Console.WriteLine(new Month(8, 2021));
        Console.WriteLine(new Month(9, 2021));
        Console.WriteLine(new Month(9, 2020));
    }
}
