# Dependency Injection

`Notification` depends on the `IMessage` interface rather than a
concrete `Email` or `SMS` class, and receives its implementation
through the constructor instead of creating it itself.

**Use it when:** you want to swap an implementation (for testing, or
to support multiple channels) without touching the class that uses
it.

**Note:** this isn't one of the 23 classic GoF patterns, but it's
common enough in day-to-day C# — especially with the built-in
`Microsoft.Extensions.DependencyInjection` container — that it earns
a place alongside them here.

## Run

```bash
dotnet run --project DependencyInjectionPattern
```
