using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class OctonaryCalendar : GregorianCalendar
{
    public const int MonthsPerYear = 9;
    static readonly int[] DaysToMonth365 = { 0, 41, 81, 122, 162, 203, 243, 284, 324, 365 };
    static readonly int[] DaysToMonth366 = { 0, 41, 81, 122, 162, 203, 243, 284, 324, 366 };
    public const int MaxYear = 9999;

    public const long TicksPerDay = 864000000000;

    private const int DaysPerYear = 365;
    private const int DaysPer4Years = DaysPerYear * 4 + 1;       // 1461
    private const int DaysPer100Years = DaysPer4Years * 25 - 1;  // 36524
    private const int DaysPer400Years = DaysPer100Years * 4 + 1; // 146097

    private const int DatePartYear = 0;
    private const int DatePartDayOfYear = 1;
    private const int DatePartMonth = 2;
    private const int DatePartDay = 3;

    // Returns a given date part of this DateTime. This method is used 
    // to compute the year, day-of-year, month, or day part.
    ///Copied from GregorianCalendar
    internal virtual int GetDatePart(long ticks, int part)
    {
        // n = number of days since 1/1/0001
        int n = (int)(ticks / TicksPerDay);
        // y400 = number of whole 400-year periods since 1/1/0001 
        int y400 = n / DaysPer400Years;
        // n = day number within 400-year period 
        n -= y400 * DaysPer400Years;
        // y100 = number of whole 100-year periods within 400-year period
        int y100 = n / DaysPer100Years;
        // Last 100-year period has an extra day, so decrement result if 4
        if (y100 == 4) y100 = 3;
        // n = day number within 100-year period
        n -= y100 * DaysPer100Years;
        // y4 = number of whole 4-year periods within 100-year period
        int y4 = n / DaysPer4Years;
        // n = day number within 4-year period 
        n -= y4 * DaysPer4Years;
        // y1 = number of whole years within 4-year period 
        int y1 = n / DaysPerYear;
        // Last year has an extra day, so decrement result if 4
        if (y1 == 4) y1 = 3;
        // If year was requested, compute and return it 
        if (part == DatePartYear)
        {
            return (y400 * 400 + y100 * 100 + y4 * 4 + y1 + 1);
        }
        // n = day number within year 
        n -= y1 * DaysPerYear;
        // If day-of-year was requested, return it
        if (part == DatePartDayOfYear)
        {
            return (n + 1);
        }
        // Leap year calculation looks different from IsLeapYear since y1, y4, 
        // and y100 are relative to year 1, not year 0
        bool leapYear = (y1 == 3 && (y4 != 24 || y100 == 3));
        int[] days = leapYear ? DaysToMonth366 : DaysToMonth365;
        // m = month of year
        int m = 0;
        for (int i = 0; i < days.Length - 1; i++) { if (n > days[i] && n <= days[i + 1]) { m = i; break; } }
        // If month was requested, return it 
        if (part == DatePartMonth) return (m + 1);
        // Return 1-based day-of-month 
        return (n - days[m] + 1);
    }

    /*=================================GetAbsoluteDate========================== 
        **Action: Gets the absolute date for the given Gregorian date.  The absolute date means
        **       the number of days from January 1st, year 1.
        * */
    public static long GetAbsoluteDate(int year, int month, int day)
    {
        if (year >= 1 && year <= MaxYear && month >= 1 && month <= MonthsPerYear)
        {
            int[] days = ((year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))) ? DaysToMonth366 : DaysToMonth365;
            if (day >= 1 && (day <= days[month] - days[month - 1]))
            {
                int y = year - 1;
                int absoluteDate = y * 365 + y / 4 - y / 100 + y / 400 + days[month - 1] + day - 1;
                return (absoluteDate);
            }
        }
        throw new ArgumentOutOfRangeException(null);
    }

    // DateToTicks: Returns the tick count corresponding to the given year, month, and day.
    // Will check the if the parameters are valid. 
    public static long DateToTicks(int year, int month, int day)
    {
        return (GetAbsoluteDate(year, month, day) * TicksPerDay);
    }
    // GetDaysInMonth: Returns the number of days in the month given by the year and 
    // month arguments.
    public override int GetDaysInMonth(int year, int month, int era)
    {
        if (era == CurrentEra || era == ADEra)
        {
            if (year < 1 || year > MaxYear)
            {
                throw new ArgumentOutOfRangeException("year");
            }
            if (month < 1 || month > MonthsPerYear)
            {
                throw new ArgumentOutOfRangeException("month");
            }
            int[] days = ((year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? DaysToMonth366 : DaysToMonth365);
            return (days[month] - days[month - 1]);
        }
        throw new ArgumentOutOfRangeException("era");
    }
    // Returns the number of days in the year given by the year argument for the current era.
    public override int GetDaysInYear(int year, int era)
    {
        if (era == CurrentEra || era == ADEra)
        {
            if (year >= 1 && year <= MaxYear)
            {
                return ((year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? 366 : 365);
            }
            throw new ArgumentOutOfRangeException("year");
        }
        throw new ArgumentOutOfRangeException("era");
    }
    public override bool IsLeapYear(int year, int era)
    {
        if (era == CurrentEra || era == ADEra)
        {
            if (year >= 1 && year <= MaxYear)
            {
                return (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
            }

            throw new ArgumentOutOfRangeException("year");
        }
        throw new ArgumentOutOfRangeException("era");
    }

    public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
    {
        if (era != CurrentEra && era != ADEra)
        {
            throw new ArgumentOutOfRangeException("era");
        }
        long ticks = DateToTicks(year, month, day)
                     + new TimeSpan(0, hour, minute, second, millisecond).Ticks;
        return new DateTime(ticks);
    }

    public override int GetEra(DateTime time)
    {
        return (ADEra);
    }
    public override int GetDayOfMonth(DateTime time)
    {
        return (GetDatePart(time.Ticks, DatePartDay));
    }

    public oDayOfWeek GetODayOfWeek(DateTime time)
    {
        return (oDayOfWeek)((int)((time.Ticks / TicksPerDay) + 1) % 8);
    }

    public enum oDayOfWeek { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Xday }
    public override int GetYear(DateTime time)
    {
        return (GetDatePart(time.Ticks, DatePartYear));
    }

    public override int GetMonth(DateTime time)
    {
        return (GetDatePart(time.Ticks, DatePartMonth));
    }

    public MonthOfYear GetMonthOfYear(DateTime time)
    {
        return (MonthOfYear)GetMonth(time) - 1;
    }

    public enum MonthOfYear { January, February, March, May, June, July, August, October, November }

    /*
    public override int[] Eras => throw new NotImplementedException();

    public override DateTime AddYears(DateTime time, int years)
    {
        throw new NotImplementedException();
        //_ = base.AddYears(time, years);
    }
    public override DateTime AddMonths(DateTime time, int months)
    {
        throw new NotImplementedException();
    }
    public override int GetDayOfYear(DateTime time)
    {
        throw new NotImplementedException();
    }
    public override int GetMonthsInYear(int year, int era)
    {
        throw new NotImplementedException();
    }
    public override bool IsLeapDay(int year, int month, int day, int era)
    {
        throw new NotImplementedException();
    }

    public override bool IsLeapMonth(int year, int month, int era)
    {
        throw new NotImplementedException();
    }*/
}

