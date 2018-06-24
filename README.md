This analyzer makes sure you will never compare two `Double` or `Float` numbers directly for equality as it will lead to errors because they will basically never be equal. Currently it doesn't provide any fixes because I am not sure if it's a good idea, as the implementation usually depends on the context.

## More Info
 - [Comparing floating point numbers - StackOverFlow](https://stackoverflow.com/questions/3874627/floating-point-comparison-functions-for-c-sharp)
 - [Binary floating point and .NET - Jon Skeet](http://csharpindepth.com/Articles/General/FloatingPoint.aspx)
 - [Decimal floating point - Jon Skeet](http://csharpindepth.com/Articles/General/Decimal.aspx)
 - [What Every Computer Scientist Should Know About Floating-Point Arithmetic - David Goldberg](https://docs.oracle.com/cd/E19957-01/806-3568/ncg_goldberg.html)
 
