# Ohm Calculator Coding Challenge

See [Instructions.md](Instructions.md) file for the instructions for the challenge. Feel free to ask any questions in the issues section or create a pull request for suggested changes.

>Built using Visual Studio 2017 in .NET Core.  
>Uses some newer compiler tricks available in VS2015/VS2017 (C#6).  
>  *  nameof expressions
>  *  auto property initializers
>  *  string interpolation

This solution is a little overbuilt but is designed in a way that is easy to test, 
simple to add new features (such as 5 or 6 band color), and exposes its functionality more like 
an api or sdk. This allows a developer consuming it various options for implementation, high level of readability 
and all providing safe and consistent results. 

This code was refactored a few times over to try and find a balance between showcasing code skill, style and knowledge while not overbuilding something for the sake of overbuilding. I included unit tests for testing the larger components of the solution as well as the validation cases. I will likely come back and include additional tests for the calculator output itself but it would be very time consuming to provide complete coverage for all of the different color combinations.

I chose to expose the "UI" as a command line interface (CLI) mostly due to time limitations and also wanting to showcase skills and style in other areas of the solution. I typically try and build out most of my solutions where the UI is just a view anyway and all of the real work happens in other libaries. 

### Future Considerations
  
  * Create an object to return the calculation with both the ohm value and tolerance. 
    * Then the UI could choose to display both or only one.
  * Refactor the OhmValueCalcuator to use static methods instead of instance methods.
    * This was required based on the coding instructions since we had to implement an interface and static methods do not fit into that model. Since the OhmValueCalulator has no actual state or members of it's own, it would be easier to use and clearer to expose the methods as static.
  * Implement color code values in config file or somewhere else. 
    * Considered this earlier but since the color values are static and should never change, it didn't seem worth the added flexibility over concrete classes. This also allowed the colors themselves to be strongly typed and easier to use.
  * Create other branches of this solution to showcase different ways of completing the coding challenge.
    * Quick and dirty
      * Switch/case statements
      * Simple validation for null checks and correct color name
      * Single project solution with the exception of the Tests project
    * Web API with Web UI
    * Aspect oriented validation
      * Utilizing PostSharp or another AOP library, create aspects for validation so that we can annotate either the method or method params with validation attributes and have the code read a little cleaner. I wanted to implement this on this solution but it felt a little overbuilt and would have taken too much time.
    * Use reflection to create instances of the colorcodes instead of a static dictionary.
      * This would mean less maintenance if things were added later but there is a performance trade-off and it's unlikely that new colors are going to be added anyway.

### Packages Used in Solution
  * [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
  * [CommandLineParser](https://github.com/commandlineparser/commandline)
