using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class oDateTime : IEquatable<oDateTime>
{
    public DateTime dateTime { get; set; }
    OctonaryCalendar ocal;

    public oDateTime(long oTicks)
    {
        ocal = new OctonaryCalendar();

        dateTime = new DateTime(oTicks);
    }

    public override String ToString()
    {
        return String.Format("{0}, {1} {2} {3}.", ocal.GetODayOfWeek(dateTime).ToString(),
            ocal.GetMonthOfYear(dateTime), ocal.GetDayOfMonth(dateTime), ocal.GetYear(dateTime));
    }

    public bool Equals(oDateTime? other)
    {
        return other is not null && dateTime == other.dateTime;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as oDateTime);
    }

    public override int GetHashCode()
    {
        return dateTime.GetHashCode();
    }
}