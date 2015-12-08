Prime Tables - Laurie Mills

DISCLAIMER...
My installation of GitHub didn't quite work out and when I came to upload the small, incremental changes I had made to the solution, the sync failed. I don't have the knowledge of GitHub to debug the shell but I'm sure the issue is because I like to keep all code in a similar location so I hadn't used the default folder path.
Rather than make a pretence of adding in the small commits, I've uploaded the final code but also uploaded a zip file with the .git files from the initial archive in the hopes that if you overwrite the main ones, you will still see the changes I made and the order in which I wrote the program.



How to run:
-----------------------------------------------
To use the cosole application, open the PrimeNubmers exe from the bin folder


To run the unit tests, you will need NUnit 2.6.2, then open the BuildAll solution to run the unit tests through the nunit gui. If wanting to debug the nunit scripts, then adding the following to the 'nunit-x86.exe.config' stops you having to do attach to process.
<?xml version="1.0" encoding="utf-8"?>
<configuration>
 
  <startup useLegacyV2RuntimeActivationPolicy="true">
    <supportedRuntime version="v4.0.30319" />
  </startup>
 
</configuration>


To use the automated test build, you will need to download the software used in the build script...

1. Download NAnt Version 0.92 (nant-0.92-bin.zip from http://sourceforge.net/projects/nant/files/nant/0.92/) and extract the zip file 'nant-0.92-bin.zip' into 'C:\AutomatedTestTools', this will create 'C:\AutomatedTestTools\nant-0.92\bin'. If using another location, you will need to update the build script to use that instead.

2. Download NUnit2Report (NUnit2Report-V1.2.2.zip from http://sourceforge.net/projects/nunit2report/). this collates all the xml docs into a more readable format. Copy the contents of 'NUnit2Report V1.2.2 release\bin' directory into the NAnt bin directory 'C:\AutomatedTestTools\nant-0.92\bin'.

3. Download Opencover OpenCover 4.0.301 from http://opencover.codeplex.com/downloads/get/363509. This a free code coverage tool for .NET 2 and above and provides support for 32 and 64 processes. This installs OpenCover in 'C:\Program Files\OpenCover\'.
 
4. Download the latest version of Report Generator from http://reportgenerator.codeplex.com/ and extract all to 'C:\AutomatedTestTools\ReportGenerator'. This collates the codecoverage output into a more readable format.

Once all the dependent software is in place, run the PrimeNumbers-UnitTest.bat file
The script deletes the contect of the bin forlder and rebuilds the projects as release build, then runs throught the unit tests gathering the code coverage.

Provides a repeatable test environment which can be run instantly.




What I'm pleased with:
------------------------------------------------
100% code coverage for the class that generates the prime numbers and formats the strings for display

Code is readable and maintainable and has an automated test environment

the prime number generation can handle large primes but I limited the use in the console app to 50 as it really didn't display well if you tried a number as high as 5000 and it had quite an impact on performance

while the console app has a very basic user interface, it's still the first one that I have created in long time and I was happy with the dynamic column width when displaying the table (test with 1 and 30 and you will see the difference in the column widths, or use the nunit gui and look at the output tab)




What I could have done given more time:
-------------------------------------------------
implemented it in Java...
with a prettier user interface!
and output the result as csv file that could be imported into excel or something better designed to handle a 5000x5000 table. user displays aren't really designed for tables that big

created a simpler automated build script that didn't require so many dependencies such as NAnt, OpenCover, ReportGenerator etc. I've used a setup similar to what i use at work because that is what i already have installed. Additional time would have given me the opportunity to investigate the new packages that are available

a more efficient number generator (haven't looked at primes since maths at uni, had to remind myself what they were before I could even begin), I went for the basic concept with the only additional performance enhancement of only searching the list of found primes up to the sqaure root of the number that i was testing, rather than all the way to the end of the list. The Atkin's sieve should be more efficient but added more complexity so stuck with the basic sieve. 

better data validation on the table. used an int value so there will be a limit to the number of multiplications that can be done and still fit inside that object. But for a first out and a basic test of the design, it works fine.

unit testing the console app. usually only work with dlls so don't have the same depth of knowledge for testing user interfaces using continuous integration. While I have covered all the code paths using integration testing of the console app, there is no documented code coverage which is a bit annoying. It would have been nice to have that at 100% too.


