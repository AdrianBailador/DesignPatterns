# Proxy

Puts a stand-in (`ProxyImage`) in front of an expensive object
(`RealImage`), implementing the same interface (`IImage`), so the
real object is only created when it's actually needed.

**Use it when:** you want to defer expensive work (lazy loading, as
here), control access to an object, or add logic like caching or
logging around it, without changing the interface callers use.

**Watch out:** a proxy that accumulates unrelated behavior over time
stops being a proxy and starts being a god object — keep its job
narrow (access control, caching, lazy init) and put real logic
elsewhere.

## Run

```bash
dotnet run --project ProxyPattern
```
