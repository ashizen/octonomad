// Draft: a single day, identified by its position within a week.
// The octonary week is 8 days, so Index runs 0..7 (or 0..6 for a 7-day week).
public sealed class Day
{
    // Order matches OctonaryCalendar.oDayOfWeek.
    private static readonly string[] Names =
    {
        "Sunday", "Monday", "Tuesday", "Wednesday",
        "Thursday", "Friday", "Saturday", "Xday"
    };

    public int Index { get; }

    public string Name => Names[Index];

    public Day(int index)
    {
        if (index < 0 || index >= Names.Length)
        {
            throw new System.ArgumentOutOfRangeException(nameof(index));
        }

        Index = index;
    }

    public override string ToString() => Name;
}
