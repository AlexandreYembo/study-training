# Serverless Architecture

  1- Also known as 'Serverless Computing' or 'Function as a Service', FaaS.

  2- Is a Software Design Pattern where applications are hosted by a third-party service, eliminating the need for server software and hardware management by the developer.
  
  3- Applications are broken up into individual functions that can be invoked and scaled individually.
  
 
## Serverless Definition

### Backend as a Service

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

### Traditional Vs. Serverless Architectures

### Serverless Offerings

#### Cloud Vendors

#### On-Premise Solutions

### Benefits Vs. Caveats(ressalvas)
