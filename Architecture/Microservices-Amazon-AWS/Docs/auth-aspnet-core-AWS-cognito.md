# Authentication for ASP.NET Core websites with AWS Cognito
### Definition
Amazon Cognito lets you add user sign-up, sign-in, and access control to your web and mobile apps quickly and easily. Amazon Cognito scales to millions of users and supports sign-in with social identity providers, such as Facebook, Google, and Amazon, and enterprise identity providers via SAML 2.0.


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
  
### 2- Setup AWS Credentials + Create and Clone a GitHub Repository
a) Access IAM -> Identity and Access Management

b) Find or create a user(if you dont have). Then open up the user details and click on ```Add permissions```

c) Click on Attach existing policies directly and find the service you want, in that case ```cognito```.

d) Select ```AmazonCognitoDeveloperAuthentication```.

Once you have your permission attached to your user, go to security credentials tab (on summary page).

e) Create access key and it will generate a Access Key ID and Secret access Key.

f) Download de .csv file that you will use for configuration of SDK.

g) Go to windows explorer, on user root directory, create a folder .aws and a file credentials and must not have any extensions. Then edit this file using the code below.
```
[default]
aws_access_key_id=XXX
aws_secret_access_key=YYY
```
All keys XXX and YYY have to be used from the .csv file you have downloaded.

After doing this we can connect to a AWS via the SDK.

h) Create your repository on Git Hub and Clone in your computer.

### 3- Sign up with AWS Cognito and ASP.Net MVC Core
1- Create an application on DotNet Core - Minimal version 2.0

2- Add on NuGet a package Amazon.AspNetCore.Identity.Cognito

3- Add on NuGet a package Amazon.Extensions.CognitoAuthentication

4- Open appsettings.json

Add section:
```c#
  "AllowedHosts": "*",
  "AWS": {
    "Region": "ap-southast-2", // you can define your region which you created your cognito user pool.
    "UserPoolClientId": "[App client id]", // You get on AWS -> UserPool -> App clients
    "UserPoolClientSecret": "[App client secret]", // You get on AWS -> UserPool -> App clients
    "UserPoolId": "[Pool Id]"  // You get on AWS -> UserPool -> General Settings
  }
```

Now my SDK will be able to connect on AWS Cognito

#### 5- How to setup the identity provider
Go to startup.cs file
``` c#
  public void ConfigureServices(IServiceCollection services){
     ...
     services.AddCognitoIdentity();  // Put only this line - Before MVC.
     services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
  }
```
Inject all dependency for Cognito Identity.
```c#
  public void Configure(IApplicationBuilder app, IHostingEnvironment env)
  {
      ...
      app.UseAuthentication();  //Just before MVC
      app.UserMvc(routes => ...
  }
```
Now you can use Cognitos as Identity Provider

you can customize the options for password on SDK configuration
startup.cs, ConfigureServices method
```c#
    services.AddCognitoIdentity(config =>{
       config.Password = new Microsoft.AspNetCore.Identity.PasswordOptions
       {
            RequireDigit = false,
            RequireLength = 6
       }
    });
```
##### If you use the complexity password, you dont need to configure the Cognito SDK.

6- In your controller Account you will need to create a constructor to inject the identity.
```c#
  public class AccountController : Controller
  {
      private readonly SignInManager<CognitoUser> _signInManager;
      private readonly UserManager<CognitoUser> _userManager;
      private readonly CognitoUserPool _pool;
      
      public AccountController(SignInManager<CognitoUser> signInManager, UserManager<CognitoUser> userManager, CognitoUserPool pool)
      {
           _signInManager = signInManager;
           _userManager = userManager;
           _pool = pool;
      }
   }
```
On Signup you can use GetUser to validate if the user exist:
```c#
   var user = _pool.GetUser(model.Email);
```
So you need to check if the property of user ```status``` is nullable, so you can create a new user:
```c#
   var createdUser = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
```
If you do not pass the password, so it will generate a random password.

After create the user you need to check the property ```Succeeded```. If is true, so it was create successfuly.

iF you setup on AWS Cognito some attributes (e.g name) as required, you need to type this, otherwise you will have an exception.
```c#
  user.Attributes.Add(CognitoAttributesConstants.Name, "Alexandre");
```
### 4- Confirm Email Address.
You can implement a confirmation by email Address.
ConfirmModel.cs
```c#
      public string Email {get;set;}
      public string Code {get;set;}
```
AccountController.cs
```c#
  [HttpPost]
  public async Task<IActionResult> Confirm(ConfirmModel model)
  {
        var user = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);
        if(user != null)
        {
             var result = await _userManager.ConfirmEmailAsync(user, model.Code).ConfigureAwait(false);
             if(result.Succeeded)
             {
                 //redirect To Action.
             }
        }
  }
```
You can cast the UserManager object to Use CognitoUserManager<T>
```c#
   (_userManager as CognitoUserManager<CognitoUser>).ConfirmSignUpAsync(user, model.Code)
```
The method has the same parameter of the ```ConfirmEmailAsync``` that when you use UserManager Class

But the problem is once we use indepency inject we will not need to cast this method, it is not good.


### 5- Login
```c#
  [HttpPost]
  public async Task<IActionResult> Login_Post(LoginModel model)
  {
       var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false).ConfigureAwait(false);
       
       if(result.Succeeded)
       {
          //return result;
       }
       
       //return error message
  }
```
To protect your controller you need to add the attribute ```[authorize]``` on your method.

Add on Startup.cs a configuration. Method ```ConfigureServices```
```c#
   ...
  services.ConfigureApplicationCookie(options =>
  {
      options.LoginPath = "AccountController/Login";
  });  //add before MVC.
  services.AddMvc()...
```
