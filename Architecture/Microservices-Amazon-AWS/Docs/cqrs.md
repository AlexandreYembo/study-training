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

##### There is a concept called Ubiquitous language structured around the domain model, used and understood by all team members both techies and business experts.

### Concepts:
#### 1- Bounded Context:
1- Is a boundary around models that are described by a certain Ubiquitous language.

#### Every Micro-service represents a Bounded Context

#### Important: When you have many APIs calling each other, does not make sense have 2 or 3 different micro-services, because they are part of only one Bounded Context, in that case the have to be part of only one micro-service.
![Alt text](https://github.com/AlexandreYembo/study-training/blob/master/Architecture/Microservices-Amazon-AWS/Docs/ddd.PNG "DDD")

#### Then if you have 2 or more Bounded Context you have to separated them for each bounded context you will have one micro-service.
