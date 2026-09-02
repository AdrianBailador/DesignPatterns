# State

Lets an object (`OrderContext`) change its behavior when its internal
state changes, by delegating to a state object (`PendingState`,
`ShippedState`, `DeliveredState`) instead of a field full of flags and
`if` statements.

**Use it when:** an object's behavior depends on a state that changes
over its lifetime, and each state allows different transitions (here,
a `DeliveredState` order can't advance any further).

**Watch out:** it's easy to confuse with Strategy — see the note in
`StrategyPattern/README.md` for the distinction.

## Run

```bash
dotnet run --project StatePattern
```
