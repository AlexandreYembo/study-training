# Eventual Consistency and Compensating Transactions

### Transaction Across Microservices
A distributed transaction is a ```unit of work ``` or a ```task``` that has to be performed by more than one Microservice.

If one microservice cannot complete its task the all other Microservices must rollback what they have done. It is called ```Compensate transaction```.

#### How to handle distributed transactions?
#### 1- Try to avoid the distributed transactions as much as possible.

#### 2- Eventual Consistency and Compensation
The system will be consistent at some point in the future.

The data will stay in a pending stated until all Microservices confirm the transaction.

Traditional transactions are ```ACID``` (Atomicity Consistency Isolation Durability)

Distributed transactions are BASE.
