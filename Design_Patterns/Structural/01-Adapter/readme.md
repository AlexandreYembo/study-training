# Adapter
Links references:
https://refactoring.guru/design-patterns/adapter
https://sourcemaking.com/design_patterns/adapter

  1- Convert the interface of a class into another interface clients expect. Adapter lets classes work together that could not otherwise because of imcompatible interfaces.
  
  2- Wrap an existing class with a new interface.
  
  3- Impedance match an old component to a new system.
  
  4- It is about creating an intermediary abstraction that translate, or maps the old component to the new system.
  
  5- Can be implemented either with inheritance or with aggregation.
  
  6- Can not only convert data into various formats but can also help objects with different interfaces collaborate.
  

### Scenario
  Imagine you created an app that download stock using XML format. In future you decide to implement some features, like integration from another partners. But they only work with JSON format.

#### Problem
  You could change the code to adapt the new integration, but It will break some existing code.

### Solution
  You can create adapter to resolve.
