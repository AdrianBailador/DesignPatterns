# Iterator

Gives sequential access to a collection's elements (`BookCollection`)
without exposing its internal storage, through a custom
`IEnumerator<T>` (`BookIterator`).

**Use it when:** you want a uniform way to walk different collection
types, or you need to control traversal (order, filtering, lazy
loading) without leaking the underlying structure.

**Note:** C#'s `foreach` and `yield return` already implement this
pattern for you in most cases — this project spells out the iterator
explicitly (`IEnumerator<T>` with `MoveNext`/`Current`/`Reset`) to
show the mechanics `foreach` normally hides.

## Run

```bash
dotnet run --project IteratorPattern
```
