# Command

Wraps a request (calling `Receiver.Action()`) as an object
(`ConcreteCommand`) that implements a common `ICommand` interface, so
the `Invoker` can hold, pass around, and execute it without knowing
what it actually does.

**Use it when:** you need to queue, log, undo, or parameterize
actions — a menu item, a toolbar button, or a job queue are typical
examples.

**Watch out:** if you never need to queue, undo, or decouple the
caller from the receiver, a plain method call is simpler than a
Command object.

## Run

```bash
dotnet run --project CommandPattern
```
