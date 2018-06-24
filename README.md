This analyzer makes sure you will never compare two `Double` or `Float` numbers directly for equality as it could lead to errors because floating-point numbers can have imperceivable rounding errors. Currently it doesn't provide any fixes because I am not sure if it's a good idea, as the implementation usually depends on the context.

## Example
The analyzer will warn you about cases like this:
```csharp
float x = 0.3f;
float y = 0.3f;

if (x == y)
    Console.WriteLine("They are equal!");
else
    Console.WriteLine("They are NOT equal!");
```

## How to use

Add the [nuget package](https://www.nuget.org/packages/FloatEquality) to your project and the analyzer will be enabled automatically. I'll try to create a Visual Studio extention as well.

## More Info
 - [Comparing floating point numbers - StackOverFlow](https://stackoverflow.com/questions/3874627/floating-point-comparison-functions-for-c-sharp)
 - [Binary floating point and .NET - Jon Skeet](http://csharpindepth.com/Articles/General/FloatingPoint.aspx)
 - [Decimal floating point - Jon Skeet](http://csharpindepth.com/Articles/General/Decimal.aspx)
 - [What Every Computer Scientist Should Know About Floating-Point Arithmetic - David Goldberg](https://docs.oracle.com/cd/E19957-01/806-3568/ncg_goldberg.html)
 
