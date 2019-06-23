# CQRS - Command and Query Segregation Pattern
## CQRS and Event Sourcing
### Query
1- Requesting and Receiving data of another Microservice or data source is "Query"

2- Queries do not change the state of the system. It only reads the data and returns it to you.

### Command
1- Command invokes a action or an operation in the system.

2- Command changeshe state of the system.

## What is CQRS?
#### Command Query Responsability Segregation.
1- Separate the micro services that handle queries from the micro services which handle the commands in that case you separe 2 different microservice (one for command and other for query).
2- CQRS must be applied on a Bounded Context.
3- Is suitable for complex systems. If you are building smaller system, probably CQRS is not best for you.
![Alt text](https://github.com/AlexandreYembo/study-training/blob/master/Architecture/Microservices-Amazon-AWS/Docs/images/CQRS-Diagram.png "CQRS")