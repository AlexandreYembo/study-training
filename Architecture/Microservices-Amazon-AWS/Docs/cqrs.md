# Command and Query Segregation (CQRS) Pattern.

### Domain Driven Design and Microservices
1- A domain is a sphere of knowledge or activity.

2- In software engineering a domain is the area of business that the application is intended to apply.

In microservice, the scenario example we can have 2 differents Domain:

``` Domain 1 - Adverts [Adverts.Api] ```

```
Domain 2 - Search domain [Search.Api]
                 [Search.Worker]
```

3- Domain logic or domain layer refers to the logic and business rules of an application.

4- Domain model is an object (model) which is relevant to and coherent with a domain layer.

#### What is Domain Driven Design?

A method of software design in which:

1- Focus is on the domain, and domain logic. Understanding the business over technology.

2- Constantly consult with the domain expert to improve the domain logic and domain models.
