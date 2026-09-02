# Singleton

Ensures a class has only one instance and provides a global point of
access to it.

**Use it when:** exactly one instance of a class must coordinate
actions across the system (a configuration object, a connection pool,
a logger).

**Watch out:** it introduces global state, which makes unit testing
harder and can hide dependencies between classes. Prefer dependency
injection where you can.

This implementation uses `Lazy<T>`, which is thread-safe by default
and avoids manually locking on every access.

## Run

```bash
dotnet run --project SingletonPattern
```
