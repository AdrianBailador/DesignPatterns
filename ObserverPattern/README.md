# Observer

Lets a `Subject` notify a list of registered `IObserver`s whenever
its state changes, without the subject knowing anything about the
observers beyond that interface.

**Use it when:** one change needs to trigger reactions in an unknown
or changing number of other objects (event systems, UI data binding,
pub/sub).

**Watch out:** unregister observers when they're no longer needed —
a subject that keeps a reference to an observer nobody else uses
anymore is a common source of memory leaks.

## Run

```bash
dotnet run --project ObserverPattern
```
