##### AAA - Arrange, Act and Assert
###### Arrange
This place provide when you create all objects and instance to be used when you call the method

##### Act
Contains the call method

##### Assert
Provide test validation based on the return of ```act``` and defining which result will be expected.


```c#
[Fact]
public async Task MiddlewareFilter_SetsMiddlewareFilterFeature_OnExecution(){
    //Arrange
    Task requestDelegate(HttpContext context) => Task.FromResult(true);
    var middlewareFilter = new MiddlewareFilter(requestDelegate);
    var httpContext = new DefaultHttpContext();
    var resourceExecutingContext = GetResourceExecutingContext(httpContext);
    var resourceExecutingDelegate = GetREsourceExecutingDelegate(httpContext);

    //Act
    await middlewareFilter.OnResourceExecutingAsync(resourceExecutingContext, resourceExecutingDelegate);

    var feature = resourceExecutingContext.HttpContext.Features.Get<IMiddlewareFilterFeature>();

    //Assert
    Assert.NotNull(feature);
    Asset.Same(resourceExecutingContext, feature.ResourceExecutingContext);
    Asset.Same(resourceExecutingDelegate, feature.ResourceExecutingDelegate);
}
```

##### Nomenclature
Name used: ``` TestObject_BehaviorMethod_ExpectedBehavior ```

```[class_name]_[Method_Name]_[Expected_Behavior] ```

Example:
```c#
public async Task PaymentService_ValidateFunds_ReturnLowBalance
```

or you can use:
```[Method_Name]_[State]_[Expected_Behavior] ```

Example:
```c#
public async Task ValidateFunds_LowBalance_ShouldDenyPayment
```

### xUnit
There are 2 ways you can test using xUnit: ```[Fact]``` and ```[Theory]```

#### Fact
You can assert an result expected, but you cannot create many scenarios in same method.

#### Theory
You can assert many scenarios in the same method by using the attribute ```[InlineData]```. For each scenario you need to add one more attribute and define the parameters and a constant you want to compare.

### Asserts


### Traits
This feature allows you to organize the test by category.
```c#
[Fact(DisplayName="Deny Payment due to the Low Balance")]
[Trait("PaymentService", "Payment Valid Funds Trait Tests)]
public async Task ValidateFunds_LowBalance_ShouldDenyPayment
```
Then on Visual studio, in Test Explorer, right click and remove the option show by hierarchy.

### Fixture
A class is recreated for each test method and I dont want to create the object in each class constructor. Then, using ```Fixture``` will help to create an object that can be used across many classes.

Create a new class ```<className>TestsFixture```
```c#
public class PaymentServiceTestsFixture : IDisposable
{
    public Payment GenerateValidFund()
    {
        return new Payment()
        {
            Amount: 10,
            Funds: 100,
            PaymentType: PaymentType.CreditCard
        };        
    }

    public Payment GenerateInValidFund()
    {
        return new Payment()
        {
            Amount: 10,
            Funds: 0,
            PaymentType: PaymentType.CreditCard
        };        
    }
    
    public void Dispose()
    {
       
    }
}

```

Now you create a new class that will be use to implement, but in fact you don't need to instance everytime and it will save the current object state.

```c#
[CollectionDefinition(nameOf(PaymentServiceCollection))]
public class PaymentServiceCollection : ICollectionFixture<PaymentServiceTestsFixture>
{

}
```

and in the test class
```c#
[Collection(nameof(PaymentServiceCollection))]
public class PaymentServiceTests
{
    private readonly PaymentServiceTestsFixture _paymentServiceTestsFixture;
    public PaymentServiceTests(PaymentServiceTestsFixture paymentServiceTestsFixture){
        _paymentServiceTestsFixture = paymentServiceTestsFixture;
    }

    Fact(DisplayName="Deny Payment due to the Low Balance")]
    [Trait("PaymentService", "Payment Valid Funds Trait Tests)]
    public async Task ValidateFunds_LowBalance_ShouldDenyPayment()
    {
        //Arrange
        _paymentServiceTestsFixture.GenerateInValidFund();
    }
}

```