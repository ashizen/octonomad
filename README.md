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
| `Assets/Scripts/`               | Early, incomplete drafts (`Day`, `Month`, `Week`) — not compiled |
| `Octonomad.slnx`                | Solution (new XML format, .NET 10 SDK)                      |
| `Releases/`                     | Local staging area for build artifacts — contents are git-ignored |

`Octonomad.Core` has **no UI or platform dependency**, so the same calendar code
can be referenced by a desktop app today and an Android app later without moving
or duplicating anything.

`Assets/Scripts/` holds early, unfinished drafts (`Day`, `Month`, `Week`). They
are **not** part of the build and do not currently compile — kept as a sketch of
the modelling direction.

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

## Status

Work in progress. Known issues are marked with `///bug:` comments in the source.

Binary builds are published on the [Releases](../../releases) page rather than
committed to the repository. There is no Android build yet — see
`Releases/README.md`.

## License

Copyright (C) 2019-2026 ashizen

This program is free software: you can redistribute it and/or modify it under
the terms of the **GNU General Public License, version 3** as published by the
Free Software Foundation. See [LICENSE](LICENSE) for the full text.

This program is distributed in the hope that it will be useful, but **without
any warranty**; without even the implied warranty of merchantability or fitness
for a particular purpose.
