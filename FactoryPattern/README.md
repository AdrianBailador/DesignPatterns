# Factory Method

Centralizes object creation behind a method, so callers ask for "an
Animal" by type name instead of calling `new Dog()` / `new Cat()`
directly.

**Use it when:** the exact type to create depends on a condition (a
string, config value, or input), and you want that decision in one
place instead of scattered across the codebase.

**Watch out:** for a large number of types, a `switch` factory grows
unwieldy — that's when Abstract Factory or a registration-based
factory (a `Dictionary<string, Func<Animal>>`) tends to work better.

## Run

```bash
dotnet run --project FactoryPattern
```
