# Prototype

Creates new objects by cloning an existing instance (`Shape.Clone()`)
instead of building one from scratch with `new`.

**Use it when:** creating an object is expensive, or you want a copy
that starts from a pre-configured instance and only tweaks a couple
of fields (like the `clone.Color = "Blue"` in this example).

**Watch out:** a naive clone only copies references for any nested
objects (a shallow copy). If a `Shape` held a mutable reference type,
`Clone()` would need to deep-copy it explicitly to avoid the clone
and the original sharing state.

## Run

```bash
dotnet run --project PrototypePattern
```
