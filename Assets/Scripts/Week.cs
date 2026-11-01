using System.Collections;
using System.Collections.Generic;

// Draft week model.
// hebdad = 7 days, ogdad = 8 days (the octonary week).
// Composition rather than ': List<Day>' so callers cannot Add/Remove and
// change the length of a week.
public sealed class Week : IReadOnlyList<Day>
{
    private readonly Day[] _days;

    public WeekType Kind { get; }

    public int Count => _days.Length;

    public Day this[int index] => _days[index];

    public Week(WeekType kind)
    {
        Kind = kind;

        int length = kind == WeekType.hebdad ? 7 : 8;
        _days = new Day[length];

        for (int i = 0; i < length; i++)
        {
            _days[i] = new Day(i);
        }
    }

    public override string ToString() => $"{Kind} ({Count} days): {string.Join(", ", _days)}";

    public IEnumerator<Day> GetEnumerator() => ((IEnumerable<Day>)_days).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public enum WeekType
    {
        hebdad,
        ogdad
    }
}
