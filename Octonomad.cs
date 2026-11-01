using System;
using System.Diagnostics;
using System.Globalization;

public class Octonomad
{
    static void Main()
    {
        OctonaryCalendar oCal = new OctonaryCalendar();
        long oTicks = OctonaryCalendar.DateToTicks(2020, 8, 35);
        DateTime cDate = new DateTime(oTicks);
        Debug.WriteLine(cDate.ToString("dddd MMMM d yyyy"));
        oDateTime oDate = new oDateTime(oTicks);
        Debug.WriteLine(oDate.ToString());

        long cTicks = new DateTime(2019, 12, 26).Ticks;
        ///bug:OctonaryCalendar.getabsolutedate months from gregorian calendar
        Debug.WriteLine(new DateTime(cTicks).ToString());
        Debug.WriteLine(new oDateTime(cTicks).ToString());

    }

}
