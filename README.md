
# Design Patterns

![Build and Test](https://github.com/AdrianBailador/DesignPatterns/actions/workflows/build.yml/badge.svg)

This repository contains a .NET 10 solution implementing various design patterns in C#. Each design pattern is implemented in a separate console project within the solution.

Each project folder has its own `README.md` explaining what problem the pattern solves and when to reach for it.

## Project Structure

The repository is organized as follows:

```
DesignPatterns/
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
cd /path/to/DesignPatterns/SingletonPattern
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

**Creational**

1. Singleton
2. Factory Method
3. Builder
4. Prototype

**Structural**

5. Adapter
6. Decorator
7. Facade
8. Bridge
9. Composite
10. Proxy

**Behavioral**

11. Observer
12. Command
13. Strategy
14. State
15. Chain of Responsibility
16. Template Method
17. Iterator

**Other**

18. Dependency Injection (not a GoF pattern, but common enough in C# to include)

Each design pattern is implemented in its own project and contains code examples demonstrating its usage.

## Running the Tests

The `DesignPatterns.Tests` project covers all 18 patterns above. Run it with:

```bash
dotnet test DesignPatterns.sln
```

CI also runs `dotnet format --verify-no-changes` to catch style issues, and
publishes a coverage summary to each run's job summary on GitHub Actions.

## License

This project is licensed under the [MIT License](LICENSE).

