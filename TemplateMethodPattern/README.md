# Template Method

Defines the skeleton of an algorithm in a base class (`Export()`),
deferring the individual steps (`GetHeader`, `GetRowSeparator`,
`GetFooter`) to subclasses (`CsvExporter`, `JsonExporter`).

**Use it when:** several variants of an algorithm share the same
overall structure but differ in specific steps, and you want to avoid
duplicating that structure in every variant.

**Watch out:** too many overridable steps make the base class hard to
follow. If subclasses only ever override one or two of many hooks,
consider Strategy instead, injecting just the piece that varies.

## Run

```bash
dotnet run --project TemplateMethodPattern
```
