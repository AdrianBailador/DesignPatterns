# Strategy

Extracts an algorithm (`OperationAdd`, `OperationSubtract`,
`OperationMultiply`) behind a common interface (`IStrategy`) so the
`Context` that uses it can be handed a different one at runtime.

**Use it when:** you have several interchangeable ways to do the same
job and want to pick between them without a chain of `if`/`switch`
statements at the call site.

**Watch out:** it's easy to confuse with State. Strategy is chosen by
the *caller* and doesn't usually change on its own; State is driven
by the object's *own* internal transitions (see the `StatePattern`
project).

## Run

```bash
dotnet run --project StrategyPattern
```
