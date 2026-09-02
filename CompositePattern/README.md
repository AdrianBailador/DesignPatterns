# Composite

Lets individual objects (`FileItem`) and groups of objects
(`DirectoryItem`) be treated through the same interface
(`FileSystemItem`), so `GetSize()` works the same way whether it's
called on a single file or a directory tree.

**Use it when:** you're modeling a part-whole hierarchy (file
systems, UI component trees, org charts) and want client code to
treat a single item and a group of items the same way.

**Watch out:** operations that only make sense for one side (e.g.
`FileItem.Delete()` vs. "delete this whole directory") can complicate
the shared interface — decide up front how deep that symmetry needs
to go.

## Run

```bash
dotnet run --project CompositePattern
```
