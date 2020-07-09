# Readme
This project was made for personal education purpose.  
It should not be considered a serious project in any way or form.  
This project has only been tested on linux and has no guarantee to work.

## Description  
The project should illustrate communication through 2 clients with RabbitMQ using dotnet core 3.1 and c#.  
The Communication is 1 way and only goes from HumanDatabase to Recieve.  
There is 2 diffrent queues to Receive one called 'log' the other 'Customer'.  

## Instructions  
1. Open a terminal and go to the folder 'Receive'  
2. Use the command "dotnet run Log" or "dotnet run Customer"
3. Open a new temrinal and go to the folder 'HumanDatabase'
4. (optional) run the tests with the command "dotnet test"
5. Run the program with the command "dotnet run"