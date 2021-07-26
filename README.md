# StatsCalculator
Simple statistical calculator application use to calculate sum, average, mean 

The solution is implemented as WebAPI in .Net 5

The Solution contains 2 projects <br>
**StatsCalculator** - Containing the implementation <br>
**StatsCalculatorUnitTests** - Containing the unit tests <br>
<br>
The following APIs and provided calculating/Testing the ArithmeticMean, Standard Deviation (both population, sample based), Frequency in bin of 10 <br>

**1./api/StatsCalculator/CalculateMean **
This api will need the the input as the full file path of the csv file located in the server. For example c:\testdata\SampleData.csv <br>
**Expected Output**: The ArithmeticMean value <br>
**2./api/StatsCalculator/CalculateStandardDeviation **
This api will need 2 inputs. a) The full file path of the csv file in server b) string "population" or "sample" for the type of standard deviation <br>
**Expected Output**: The standard Deviation Value<br>
**3./api/StatsCalculator/GetHistogramAndFrequency **
This api will need 2 inputs. a) The full file path of the csv file in server b) The bin bucket value. For example, 10 will provide buckets of 0-9, 10-19, ... <br>
**Expected Output**: The output will have bucket, frequency and the values in the bucket <br>
<br>
<br>
**Running**
Run the application like a web api from the visual studio or compile and build and run the dll or the .exe file generated. <br>
Please use the swagger for providing the inputs. The end points are mentioned above. On running from visual studio, the swagger is automatically launched on default browser.
<br>
<br>
<br>
<br>








