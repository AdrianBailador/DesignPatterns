
# Design Patterns

This repository contains a Visual Studio Code solution for implementing various design patterns in C# using .NET Core. Each design pattern is implemented in a separate console project within the solution.

## Project Structure

The repository is organized as follows:

```
DesignPatternsSolution/
│
├── SingletonPattern/
│   ├── Program.cs
│   └── ...
│
├── FactoryPattern/
│   ├── Program.cs
│   └── ...
│
├── BuilderPattern/
│   ├── Program.cs
│   └── ...
│
├── ...
```

Each folder represents a design pattern and contains a console project that implements that specific pattern.

## How to Run

1. Open a terminal and navigate to the directory of the project you want to run. For example, to run the Singleton pattern:

```bash
cd /path/to/project/DesignPatternsSolution/SingletonPattern
```

2. Build the project using the `dotnet build` command:

```bash
dotnet build
```

3. Once built, run the program using the `dotnet run` command:

```bash
dotnet run
```

This command will build the project if necessary and then execute the application.

If you want to run a specific project instead of all projects in the solution, you can specify the project name after the `dotnet run` command. For example:

```bash
dotnet run --project SingletonPattern
```

This will run only the `SingletonPattern` project. Replace `SingletonPattern` with the name of the project you want to run.

## Implemented Design Patterns

1. Singleton
2. Factory
3. Builder
4. Dependency Injection
5. Adapter
6. Decorator
7. Facade
8. Bridge
9. Observer
10. Command
11. Strategy

Each design pattern is implemented in its own project and contains code examples demonstrating its usage.

