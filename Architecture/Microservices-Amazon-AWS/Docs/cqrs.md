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