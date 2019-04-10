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
 
 - Message customizations (Select email verification messages by sending a code or a link to approve or validate)
 
 - App clients (If you want to use app such as Mobile Application)
 
 - Triggers (We can setup Lambda function for different workflows such as: Pre sign-up, Pre authentication, Custom message, etc)
 

c) next click on Create Pool

d) You will have the Pool Id generated when you create a pool. It is important.

