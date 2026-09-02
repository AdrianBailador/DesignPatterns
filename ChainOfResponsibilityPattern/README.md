# Chain of Responsibility

Passes a request along a chain of handlers (`Level1Support` →
`Level2Support` → `Level3Support`) until one of them handles it,
without the caller needing to know which one will.

**Use it when:** more than one object may handle a request and the
handler isn't known ahead of time (support ticket escalation,
middleware pipelines, validation chains).

**Watch out:** if no handler in the chain ends up handling the
request, it can silently disappear — make sure there's always a
terminal handler (here, `Level3Support` always handles what reaches
it).

## Run

```bash
dotnet run --project ChainOfResponsibilityPattern
```
