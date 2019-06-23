# Exponential Back Off and Circuit Breaker Patterns
### Definition
Two patterns use to call web api.

### Exponentially Back Off
1- Sometimes non-responsive Microservices are transient and correct after a short delay.

2- Wait for a bit and try again.

3- Before each try wait exponentially longer.


#### Steps call

Every time you retry you have to wait longer. 

1- I make a call and I don't get any response and then I wait for 2 seconds. 

2- So I retry for the first time now if I don't get any responses for the second retry or for the third call I need to wait to powered by two for example for second again. ``` 2 ^ 2 = 4 ```

3- If I make a call and I don't get any response for the third retry I need to wait to powered by three equal 8 seconds. ``` 2 ^ 3 = 8 ```
if I make a call and I dont

##### In overall it means ``` try again ```

### Back off
If I make a call for the first time and I don't get any responses I wait for a bit and then try again. 

Just step back wait for ``` x ``` amount of time for example two seconds or half second and then try again if it fails again wait a bit and etc.

### Circuit Breaker
1- If a fault is not transient, immediately fail the calls to a give Api fox ``` x ``` amount of time.

2- If you can return something useful although not complete return it.

It is a kind of break for exponentially back off pattern as well as a circuit breaker says that sometimes if you sense that a problem with the microservices is not transient and it's not going to get fixed by itself anytime soon immediately fail all because all the API calls to that microservice or API for ``` x ``` amount time.


### Implementation
1- Install a package from NuGet called ``` Microsoft.Extensions.Http.Polly ```

2- In ``` Startup.cs ``` 

when you register your independency injection by using ``` services.AddHttpClient ``` this is used for HttpClient instance, you have to put the follow code:

``` c#
  services.AddHttpClient(<IAdvertApiClient, IAdvertApiClient>);

  /// you add the extension for policy handler
  .AddPolicyHandler();

   services.AddHttpClient(<IAdvertApiClient, IAdvertApiClient>).AddPolicyHandler(GetRetryPolicy());

   //GetRetryPolicy this is a method to get Retry Policy.
   private IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(){
      return HttpPolicyExtensions.HandleTransientHttpError().OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
              .WaitAndRetryAsync(5, retyAttempy => TimeSpan.FromSeconds(Math.Pow(2, retyAttempy))); 
              
              // 5 - retry count.
             //Math.Pow for exponential power.
   }

   Now you are going to implement Circuit Breaker pattern. In startup.cs it is necessary to add new Policy Handler.

   ``` c#

      services.AddHttpClient(<IAdvertApiClient, IAdvertApiClient>)
              .AddPolicyHandler(GetRetryPolicy())
              .AddPolicyHandler(GetCircuitBreakerPatternPolicy());

      
      private IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPatternPolicy(){
          return HttpPolicyExtensions.HandleTransientHttpError().CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));

          // for 30 secounds I will try three tries everthing any call should be broken.
      }
   ```

```