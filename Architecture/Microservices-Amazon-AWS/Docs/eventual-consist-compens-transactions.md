# Eventual Consistency and Compensating Transactions

### Transaction Across Microservices
A distributed transaction is a ```unit of work ``` or a ```task``` that has to be performed by more than one Microservice.

If one microservice cannot complete its task the all other Microservices must rollback what they have done.
