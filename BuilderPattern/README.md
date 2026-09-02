# Builder

Separates the construction of a complex object from its
representation, using a fluent chain of setters that ends in
`Build()`.

**Use it when:** an object has many optional fields and you want to
avoid a constructor with a long parameter list (or a dozen
overloads).

**Watch out:** for a simple object with two or three fields, a plain
constructor or object initializer is usually clearer than a builder.

## Run

```bash
dotnet run --project BuilderPattern
```
