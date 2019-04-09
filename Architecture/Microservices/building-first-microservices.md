# Building Our First Microservices

## Quiz about a well-designed Microservices in Amazon Web Services.

##### 1- What is data offloading?
Key data of a service must be stored in a shared persistent store.

##### 2- What AWS component is related to data offloading?
Memcached.

##### 3- Which type of Microservice can you build in AWS?
Lambda functions which can be accessed via API Gateway.

Lambda functions which respond to a message or event.

Web API service that is hosted on ECS

##### 4- Why do we put CloudFront in front of our services
Users who are in different regions will get the data from a closer data center.

##### 5- What statement is Correct about Microservices and Databases?
DynamoDB is a good option because it allows each individual service to have its own database.

## Quiz about Architecture of Web Advert system
##### 1- What is the job of AWS Api Gateway?
It aggregates multiple APIs to one set of API that is easier to discover and use.

It lets the clietns access components that reside in a private VPC.

It acts as a proxy between our system and a third party system.

##### 2- If I build my website using a Javascript framework such as React or AngularJs, my web pages will have to talk to Api Gateway
True

##### 3- Which item is about AWS Cognito?
A directory for all your apps and users

It has built-in customizable UI to sign in users

Can be used to protect APIs

##### 4- Why is Elasticsearch used in the proposed architecture?
It enables us to perform complex searches on the advertisements. This canno be achieved via DynamoDb.

##### 5- Why is there a Search API and a search Worker?
API is Asp.net Web Api but worker is Lambda. It depends which one we prefer we can use the interchangeably.
