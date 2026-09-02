# Order Processing Example

Every other project in this repo shows one pattern in isolation. This
one shows three of them working together in a single, small scenario:
placing an order.

- **Builder** (`OrderBuilder`) assembles an `Order` from a fluent
  chain of calls instead of a constructor with a long parameter list.
- **Strategy** (`IDiscountStrategy`) picks how the subtotal turns into
  a total — `NoDiscount`, `PercentageDiscount`, or
  `FixedAmountDiscount` — without `OrderProcessor` knowing which one
  it got.
- **Observer** (`IOrderObserver`) lets `OrderProcessor` notify an
  open-ended list of reactions — email, inventory, audit log — when an
  order is placed, without knowing what any of them actually do.

None of the three patterns depend on each other here: swap the
discount strategy, add or remove observers, or change how the order is
built, and the other two are unaffected. That's the point — each one
solves a separate concern, and the example composes cleanly because
they don't leak into each other.

## Run

```bash
dotnet run --project OrderProcessingExample
```
