# Builder
## Fluent interface
### Definition: An interface wich allows you to change several calls by returning a reference to the object you are working with.
### Example:
####    1- Implementation: public People GetName() => new People();
####    2- Uses: new People().GetName().GetName().GetName(), etc....
