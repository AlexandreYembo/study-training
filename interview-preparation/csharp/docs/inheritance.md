# Inheritance
```public sealed class``` -> Cannot be used as a base class.

```public abstract class``` -> Can be used as a base class but not allow to instantiate.

### Overriding members
```virtual``` -> Allow a class member to overriden in a derived class.

```override``` -> Overrides a virtual member defined in the base class.

```abstract``` -> Requires that a class member to be overriden in the derived class.
```c#
abstract class Shape
{
    public abstract int GetArea();
}
```

```new Modifier``` -> Hides a member inherited from a base class.
```c#
public class BaseC
{
    public int x;
    public void Invoke() { }
}
public class DerivedC : BaseC
{
    new public void Invoke() { }
}
```