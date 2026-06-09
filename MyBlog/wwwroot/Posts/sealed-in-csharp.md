# Sealed in C#: When to stop inheritance

One of the most underused keywords in C#: `sealed`

Most developers know about inheritance.

Fewer developers know when to stop it.

That's where the `sealed` keyword comes in.

Consider this class:

```csharp
public class PaymentProcessor
{
    public virtual void Process()
    {
        // Process payment
    }
}
```

Anyone can inherit and change its behavior.

Sometimes that's exactly what you want.

But sometimes it's not.


### Using `sealed`

```csharp
public sealed class PaymentProcessor
{
    public void Process()
    {
        // Process payment
    }
}
```

Now the class cannot be inherited.

Its behavior is protected from unintended extension.


### When I Use `sealed`

- Utility classes
- Helper classes
- Classes representing fixed business behavior
- Classes that are not designed for inheritance


### Common Mistake

Many developers leave every class open for inheritance by default.

The result?

- Uncontrolled extensions
- Unexpected behavior
- Increased maintenance cost

Just because a class _can_ be inherited doesn't mean it _should_ be.


### Rule of thumb

Design for inheritance only when you have a clear inheritance scenario.

Otherwise, consider sealing the class and exposing behavior through interfaces when needed.

A closed class is often easier to understand, test, and maintain than an overly extensible one.


How does your team approach inheritance?

Do you keep classes open by default, or do you prefer `sealed` unless inheritance is required?

If you found this helpful, feel free to repost and share it with your network.
