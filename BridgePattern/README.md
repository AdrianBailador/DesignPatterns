# Bridge

Splits an abstraction (`Abstraction`) from its implementation
(`IImplementation`) so the two can vary independently — you can add a
new `ConcreteImplementation` without touching `Abstraction`, and vice
versa.

**Use it when:** a class has two dimensions that would otherwise
multiply into a subclass for every combination (e.g. shape × render
API, or remote control × device).

**Watch out:** it's easy to confuse with Adapter. Adapter makes two
*existing*, incompatible interfaces work together; Bridge is a
deliberate up-front design split between abstraction and
implementation.

## Run

```bash
dotnet run --project BridgePattern
```
