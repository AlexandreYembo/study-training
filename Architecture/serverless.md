# Serverless Architecture

  1- Also known as 'Serverless Computing' or 'Function as a Service', FaaS.

  2- Is a Software Design Pattern where applications are hosted by a third-party service, eliminating the need for server software and hardware management by the developer.
  
  3- Applications are broken up into individual functions that can be invoked and scaled individually.
 
  4- Includes BaaS and FaaS
 
#### About PaaS (Platform as a Service) - still forces the developer to control the number of intances running, this concern is specifically what Serverless removes. 
 
## Serverless Definition

### Backend as a Service
  1- Are usually priced on storage
  2- BaaS services may be long-running, but that is an implementation detail of the service provider.
  

### Function as a Service
  1- Execute logic in response to events (in this context, all logic including  multiple functions or methods are groupd into a deployable unit, known as a 'Function'
 
 2- Packaging, deployment, scalling all handled transparently.
 
 3- Scaling is handled automatically, assuming the function is stateless.
 
 4-  Scenarios include:
    
   - Proxy API credentials: (this would be a good case for when you have some secrets that you do not want to expose on the client side so you can wrap those inside of a fast function.
    
   - Database queries: (eg. you want to make a call to Dynamo using a function).
    
   - Job dispatching
    
   - Domain logic
 
 5- In all of these, the function is in charge o executing a  task or performing some kind of data extract, transform, load processing.
 
 6- FaaS makes it easy to write and deploy simple micro-services
 
 7- Are usually priced on time of execution and resource consumption (like allocated RAM)
 
 8- Usually spin up for the length of the execution and then clean themselves up.


### Is this Serverless?
  1- Firebase -> Yes, It is a turnkey BaaS provider.
  2- Managed PostgreSQL -> No, the developer is still responsible for scale.
  3- AWS Lambda -> Yes, it is a FaaS provider.
  4- AWS DynamoDB -> Yes, it fits into the BaaS camp, but does not provide all of the APIs that a turnkey BaaS provider has thjis just wraps the database component.
  5- AWS Elastic Beanstalk -> No, it is a PaaS that abstracts the use of underlying IaaS (Infrastructure as a service) services, but the developer is stil responsible for scaling concerns.

### Traditional Vs. Serverless Architectures

### Serverless Offerings


#### Cloud Vendors

#### On-Premise Solutions

### Benefits Vs. Caveats(ressalvas)
