# Release assets

Build artifacts dropped in this folder are **git-ignored** — this folder exists
as a local staging area so nothing binary ends up in the repository history.

Publish them on the GitHub Releases page instead:

<https://github.com/ashizen/octonomad/releases>

## Why not commit binaries?

Git stores every version of a binary forever, so a few rebuilt APKs bloat the
clone size permanently and cannot be removed without rewriting history. Release
assets are versioned, downloadable, and keep the repo small.

## Current release

| Asset                             | Notes                                  |
| --------------------------------- | -------------------------------------- |
| *(none yet)*                      | Previous `OctonaryCalendarConverter0.5.apk` was removed during cleanup |

## Building the desktop binary

The .NET Framework console build lands in `bin/Release/`:

```powershell
dotnet build Octonomad.csproj -c Release -p:TargetFrameworkVersion=v4.7.1
```

Copy `bin/Release/Octonomad.exe` here if you want to attach it to a release.
