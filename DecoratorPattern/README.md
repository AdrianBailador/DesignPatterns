# Decorator

Wraps an object in another object that implements the same interface
and adds behavior, so decorators can be stacked at runtime instead of
requiring a subclass for every combination.

**Use it when:** you need to add responsibilities to individual
objects (not a whole class) and the number of possible combinations
would otherwise mean a subclass explosion — here, `MilkCoffee`,
`SugarCoffee`, or both together, without a `SimpleCoffeeWithMilkAndSugar`
class.

**Watch out:** a long decorator chain can get hard to read; if the
order of wrapping matters and isn't obvious, document it.

## Run

```bash
dotnet run --project DecoratorPattern
```
