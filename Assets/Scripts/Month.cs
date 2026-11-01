using System;

// Draft month model.
// Length is DERIVED, not stored: odd months are 41 days, even months 40, and
// the leap day is appended to the final month. This reproduces
// OctonaryCalendar.DaysToMonth365 / DaysToMonth366 exactly:
//   365 = 41+40+41+40+41+40+41+40+41
//   366 = 41+40+41+40+41+40+41+40+42
public sealed class Month
{
    /// <summary>Months in the octonary year (Jan Feb Mar May Jun Jul Aug Oct Nov).</summary>
    public const int PerYear = 9;

    public int Number { get; }
    public int Year { get; }
    public MonthType Kind { get; }
    public int Days { get; }

    public Month(int number, int year)
    {
        if (number < 1 || number > PerYear)
        {
            throw new ArgumentOutOfRangeException(nameof(number));
        }

        Number = number;
        Year = year;
        Kind = number % 2 == 1 ? MonthType.hMonth : MonthType.oMonth;
        Days = DeriveDays(number, year);
    }

    /// <summary>Odd months are "h" (41 days), even months "o" (40 days).</summary>
    public enum MonthType
    {
        hMonth,
        oMonth
    }

    private static int DeriveDays(int number, int year)
    {
        int days = number % 2 == 1 ? 41 : 40;

        // Leap day goes on the last month - matches DaysToMonth366 ending at 366.
        if (number == PerYear && IsLeapYear(year))
        {
            days++;
        }

        return days;
    }

    private static bool IsLeapYear(int year) =>
        year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);

    public override string ToString() => $"{Kind} month {Number} of {Year}: {Days} days";
}
