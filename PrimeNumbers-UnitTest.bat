@echo off
SET NAnt=C:\AutomatedTestTools\nant-0.92\bin

:: Debug command line
::%NAnt%\NAnt -debug+ -buildfile:PrimeNumbers-UnitTest -logfile:"NantLog.txt"

%NAnt%\NAnt -buildfile:PrimeNumbers-UnitTest.build -logfile:"NantLog.txt"

pause