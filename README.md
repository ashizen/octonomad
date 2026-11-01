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

| Path                            | Purpose                                                     |
| ------------------------------- | ----------------------------------------------------------- |
| `Octonomad.Core/`               | `net10.0` class library — calendar logic, no UI dependency  |
| `Octonomad.Core/OctonaryCalendar.cs` | `GregorianCalendar` subclass: year/month/day parts, era, day-of-week |
| `Octonomad.Core/oDateTime.cs`   | Thin wrapper that prints a `DateTime` in octonary form      |
| `Octonomad.Cli/`                | `net10.0` console app that references `Octonomad.Core`      |
| `Octonomad.Cli/Octonomad.cs`    | Entry point / scratch harness                               |
| `Assets/Scripts/`               | Early drafts (`Day`, `Month`, `Week`) — separate from the build |
| `Octonomad.slnx`                | Solution file                                              |

`Octonomad.Core` has **no UI or platform dependency**, so the same calendar code
can be referenced by a desktop app today and an Android app later without moving
or duplicating anything.

`Assets/Scripts/` holds an earlier sketch of the calendar as `Day` / `Month` /
`Week` types. It is **not** part of the solution and is not compiled by any
project here. As a set of files it does compile — `dotnet new console`, drop the
four files in, delete `Program.cs` — but its `Main` conflicts with
`Octonomad.Cli`, so the two entry points cannot share one assembly.

## Building

Requires the **.NET 10 SDK** — nothing else, no targeting packs:

```powershell
dotnet build Octonomad.slnx
dotnet run --project Octonomad.Cli
```

Sample output:

```
Saturday November 14 2020
Xday, October 35 2020.
2019-12-26 12:00:00 AM
Wednesday, November 36 2019.
```

To produce a standalone executable (output is git-ignored under `bin/`):

```powershell
dotnet publish Octonomad.Cli -c Release -r win-x64 --self-contained `
  -p:PublishSingleFile=true
```

## Status

- Work in progress; known issues are marked `///bug:` in the source.
- No published binaries.
- No Android build. An APK requires a separate `net10.0-android` project
  referencing `Octonomad.Core`.
- Release artifacts go on the
  [Releases](https://github.com/ashizen/octonomad/releases) page, never in git
  history.

## License

Copyright (C) 2019-2026 ashizen

This program is free software: you can redistribute it and/or modify it under
the terms of the **GNU General Public License, version 3** as published by the
Free Software Foundation. See [LICENSE](LICENSE) for the full text.

This program is distributed in the hope that it will be useful, but **without
any warranty**; without even the implied warranty of merchantability or fitness
for a particular purpose.
