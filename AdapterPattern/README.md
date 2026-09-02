# Adapter

Wraps an existing class (`Adaptee`) with an incompatible interface
behind a new one (`ITarget`) that the rest of the code expects.

**Use it when:** you need to use an existing class, often from a
library you don't control, but its interface doesn't match what your
code needs.

**Watch out:** an adapter that accumulates too much logic of its own
is usually a sign the wrapped class should be replaced, not adapted
forever.

## Run

```bash
dotnet run --project AdapterPattern
```
