# Cleaning and Running a .NET Project

Keeping a .NET project healthy often starts with two simple commands: `dotnet clean` and `dotnet run`.

These commands help remove old build artifacts and start your application with a fresh build.

## Why use `dotnet clean`?

Over time, your project collects generated files inside folders like `bin` and `obj`.

Sometimes these old files can cause confusing behavior, especially after changing dependencies, switching branches, or updating project settings.

Running `dotnet clean` removes those build outputs so your next build starts from a clean state.

```bash
dotnet clean
```

## Why use `dotnet run`?

After cleaning the project, you usually want to build and launch it.

That is where `dotnet run` comes in.

```bash
dotnet run
```

This command builds the project if needed, then starts the application.

## Typical workflow

A common workflow looks like this:

```bash
dotnet clean
dotnet run
```

This is especially useful when:

- The app behaves unexpectedly after code changes
- Build artifacts seem outdated
- You switched branches in Git
- You updated NuGet packages
- You want to verify the project starts from a clean state

## Helpful tip

If you want an even more complete reset, you can also restore packages again before running:

```bash
dotnet clean
dotnet restore
dotnet run
```

## Final thoughts

`dotnet clean` and `dotnet run` are simple commands, but they solve many day-to-day development issues.

When something feels off in a .NET project, starting clean is often the fastest way to get back on track.
