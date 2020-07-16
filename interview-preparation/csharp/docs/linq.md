#   Linq
  1- Stands for: Language Integrated Query.
  
  2- Gives you the capability to query objects.
  
## You can query
  1- Objects in memory, eg. collections (LINQ to Objects)
  
  2- Databases (LINQ to Entities)
  
  3- XML (LINQ to XML)
  
  4- ADO .Net Data Set (LINQ to Data Sets)


Select -> Is used for projections or transformations.
Single or SingleOrDefault -> Is the same argument as the where, that returns only element of sequence that satisfied condition
First or FirstOrDefault -> Is used to get the first object in a collection.
Last or LastOrDefault -> Is used to get the last object in a collection.
Skip and Take -> is used to pagination

#### LINQ Extension Methods
```c#
  var cheapBooks = books
                      .where(b => b.Price < 10)
                      .OrderBy(b => b.Title)
                      .Select(b => b.Title);
```

#### LINQ Query Operators
```c#
  var cheapBooks = from b in books
                   where b.Price < 10
                   orderby b.Title
                   select b.Title;
```

###### Which syntax you use?
In term of power and flexibility, LINQ Extension Methods is more powerful because internally all LINQ Query Operators are translate to this extension method LINQ Extension Methods.
But for sintaxes like group by is better to use LINQ Query Operators because is more clear. 
