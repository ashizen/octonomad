using System;
using System.Globalization;

public class Octonomad
{
    static void Main()
    {
        OctonaryCalendar oCal = new OctonaryCalendar();
        long oTicks = OctonaryCalendar.DateToTicks(2020, 8, 35);
        DateTime cDate = new DateTime(oTicks);
        Console.WriteLine(cDate.ToString("dddd MMMM d yyyy"));
        oDateTime oDate = new oDateTime(oTicks);
        Console.WriteLine(oDate.ToString());

        long cTicks = new DateTime(2019, 12, 26).Ticks;
        ///bug:OctonaryCalendar.getabsolutedate months from gregorian calendar
        Console.WriteLine(new DateTime(cTicks).ToString());
        Console.WriteLine(new oDateTime(cTicks).ToString());
    }
}
