# Authentication for ASP.NET Core websites with AWS Cognito
### Authenticating Users
#### Specifications of an Authentication system for Microservices
1- Must have centralized repositories for users accounts.
 
2- Must be highly availble and reliable.
 
3- Most support multiple user stores. E.g Support Staff Users and Website Users.

4- Must support authentication through OAuth and OpenId Connect.

5- Must support federation (linking with Google, Facebook, etc.)

6- Should be plugged into ASP.NET Core Identity.

7- Must support token authentication (with Jwt) as well as API Authentication


### Step to configure the Authentication
### 1- Configuring AWS Cognito.
 - Manage User Pool (user pool is just a store of users that we can use)
 
 - Manage Identity Pool (for accessing Amazon services)

a) Select User Pool and create a user pool.

b) Provide a name of Pool name and select Review Defaults.

we can edit:
 
 - Attributes (select username, email, and other way to validate the authentication)
 
 - Polices (password polices and permissions)
 
 - MFA and verifications (Multi-Factor Authentication and notifications by using email or SMS or other message services provider).
 
 - Message customizations (Select email verification messages by sending a code or a link to approve or validate).
 
 - App clients (If you want to use app such as Mobile Application. You can have multiple app clients).
 
 - Triggers (We can setup Lambda function for different workflows such as: Pre sign-up, Pre authentication, Custom message, etc)
 

c) next click on ```Create Pool```

d) You will have the Pool Id generated when you create a pool. It is important.

e) Go to App clients and client on ```Add an app client```

##### You can have different ways of authentication for different apps.

  a) Specify a App client name
  - ```Generate client secret``` if you use apps we need to sign up using the new identity provider htat is provided by Amazon.
  
  If you creating an App such ASPNET MVC and the authentication API is gonna be called by my backedn code which is being executed on their servers, so you need to select the option ```Enable sign-in API for server-based authentication (ADMIN_NO_SRP_AUTH)```.
  
  b) Click on ```Create app client ```.
  
  c) App client id will be generated and also App client secret.
