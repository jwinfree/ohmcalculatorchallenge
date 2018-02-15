Code Challenge Instructions 
------------------------------  
You have 2 days to complete the submission. 
This is a chance for you to showcase your coding skills and practices. 

1. The electronic color code (http://en.wikipedia.org/wiki/Electronic_color_code) is used to indicate the values or ratings 
of electronic components, very commonly for resistors. Write a class that implements the following interface. 
Feel free to include any supporting types as necessary. 

public interface IOhmValueCalculator 
{ 
   /// <summary> 
   /// Calculates the Ohm value of a resistor based on the band colors. 
   /// </summary> 
   /// <param name="bandAColor">The color of the first figure of component value band.</param> 
   /// <param name="bandBColor">The color of the second significant figure band.</param> 
   /// <param name="bandCColor">The color of the decimal multiplier band.</param> 
   /// <param name="bandDColor">The color of the tolerance value band.</param> 
   int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor); 

} 

2. Using your favorite unit test framework, write the unit tests you feel are necessary to adequately 
test the code you wrote as your answer to question one. 

3. Create a user interface (console or web or GUI) that will allow someone to use the calculator you created in question one.

Resistance = (1st Digit x 10 + 2nd Digit) x Multiplier
Example: This resistor, read from left to right, has the colored bands of RED, VIOLET, YELLOW, SILVER.

Using the formula and chart above, the resistance would be:

R = 1st Digit x 10 + 2nd Digit) x Multiplier
R = (RED X 10 + VIOLET) x YELLOW
R = (2 x 10 + 7) x 10,000
R = 27 x 10,000
R = 270,000 ohm (270 K ohms)

Since the final band is silver, the tolerance is 10%.