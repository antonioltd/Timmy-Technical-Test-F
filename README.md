# Timmy-Technical-Test-FairFx

Testing Tools:
   - Visual Studio 2017
   - C# language
   - Specflow
   - RestSharp
   - Nunit3
   - NUnit3 Console Runner
  
 Pre-request:
   - compile/build is required. 
         e.g. run the command "dotnet build ~/<Solution path>/TechnicalTest.sln"  in the command line
 
 Framework objective:
         This framework is designed for BDD approach. User with minimal coding skills can write a test scenario with this framework.
   I decided to consider BDD because of its flexiblity within the entire team. As we know BDD Test scenarios are easy to understand since    its written in plain english with the help of Gherkin syntax. Business can participate with writting the and validating the testcases      with this approach.
 
 How to run:
   - once the solution is compiled
   - open the command line and navigate to ~\Runner\Tools. This will take you to NUnit3 test runner.
   - issue this command to run the tests:
   
   Syntax:
          nunit3-console.exe [Test.dll Path] --out[File path to where the test result is saved]
          
          e.g. nunit3-console.exe "~Test\bin\Debug\Test.dll" --out=c:/TestOutput.xml]
