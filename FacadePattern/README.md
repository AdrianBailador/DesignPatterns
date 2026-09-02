# Facade

Provides a simple entry point (`Facade`) in front of several
subsystems, so callers don't need to know how `SubSystemOne`,
`SubSystemTwo` and `SubSystemThree` interact.

**Use it when:** a subsystem is made up of many moving parts and most
callers only need a couple of common, high-level operations.

**Watch out:** a facade should stay a thin coordinator. If it starts
containing real business logic, that logic probably belongs in the
subsystem instead.

## Run

```bash
dotnet run --project FacadePattern
```
