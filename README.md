# Octonomad

An experimental **octonary (base‑8) calendar** implemented on top of the .NET
`System.DateTime` / `System.Globalization.GregorianCalendar` types.

The year is divided into **9 months** built on 41‑day-ish blocks:

| block   | cumulative days (common year) |
| ------- | ----------------------------- |
| month 1 | 41                            |
| month 2 | 81                            |
| month 3 | 122                           |
| month 4 | 162                           |
| month 5 | 203                           |
| month 6 | 243                           |
| month 7 | 284                           |
| month 8 | 324                           |
| month 9 | 365                           |

Weeks are 8 days long (`Sunday … Saturday, Xday`), and leap years follow the
Gregorian rule (÷4, except centuries unless ÷400).

## Layout

| File                 | Purpose                                                            |
| -------------------- | ------------------------------------------------------------------ |
| `OctonaryCalendar.cs`| `Calendar` subclass: day/month/year parts, era, day-of-week         |
| `oDateTime.cs`       | Thin wrapper that prints a `DateTime` in octonary form              |
| `Octonomad.cs`       | Console entry point / scratch harness                               |
| `Assets/Scripts/`    | Early, incomplete drafts (`Day`, `Month`, `Week`) — not compiled    |
| `Octonomad.csproj`   | .NET Framework 4.0 project (classic MSBuild format)                 |

`datetime.cs`, `datetimeformat.cs` and `gregoariancalendar.cs` are *not* part of
the project. They are local reference copies of the Microsoft .NET Reference
Source, used only as reading material while porting logic; the real
`System.DateTime` and `System.Globalization.GregorianCalendar` come from the
framework (mscorlib). They are git-ignored and not distributed here.

## Building

Needs the **.NET Framework 4.0 Targeting Pack** (or MSBuild from Visual Studio):

```powershell
msbuild Octonomad.csproj -p:Configuration=Release
```

If only a newer targeting pack is installed, you can build against it instead:

```powershell
dotnet build Octonomad.csproj -p:TargetFrameworkVersion=v4.7.1 -p:Configuration=Release
```

## Status

Work in progress. Known issues are marked with `///bug:` comments in the source.

Binary builds are published on the [Releases](../../releases) page rather than
committed to the repository.
