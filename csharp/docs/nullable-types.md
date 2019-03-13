# Nullable Types
## Value Types
  1- Cannot be null
```c#
  bool hasAccess = true; // or false
```

## Nullable Types
  If you need to map some information that could return null information, for example from Database, you use Nullable types.
```c#
    Nullable<DataTime> date = null
    //or
    DateTime? date = null;
```
if you use date.Value and the property is null, the exception will happen. In that case, you need to use GetValueOrDefault() to avoid this problem.

### Null Coalescing Operator
```c#
  DateTime? date = null
  DateTime date2 = date ?? DateTime.Today;
```

### Tertiary Operator
```c#
  DateTime? date = null
  DateTime date2 = (date != null) ? date.GetValueOrDefault() : DateTime.Today;
```
