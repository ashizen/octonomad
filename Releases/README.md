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

None. The previous `OctonaryCalendarConverter0.5.apk` was removed during cleanup
and is **not** reproducible from this repository — there is no Android project
here and no Android toolchain is installed. Building an APK needs a new Android
app project (for example `net10.0-android`) referencing `Octonomad.Core`.

## Building the desktop binary

```powershell
dotnet publish Octonomad.Cli -c Release -o Releases\publish
```

That writes a self-contained-or-framework-dependent `Octonomad.Cli` build into
`Releases/publish/`, which is git-ignored. To make it a single portable file:

```powershell
dotnet publish Octonomad.Cli -c Release -r win-x64 --self-contained `
  -p:PublishSingleFile=true -o Releases\win-x64
```
