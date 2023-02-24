# C# Mission 3

Mission 3 focuses on having an API and is more on the backend part than the frontend. The task is to convert the claim history into a risk rating where a user enters their 
claim and Turner reads the claim history and converts them based on the keyword that matches on their risk list.

# Tools

1. C#
2. Visual Studio Code
3. .Net SDK 7.0
4. Web API
5. Postman(other API tools is fine)

# Initialisation for webapi
1. Open Terminal
2. dotnet new webapi -o TodoApi
3. cd TodoApi
4. dotnet add package Microsoft.EntityFrameworkCore.InMemory
5. dotnet dev-certs https --trust

# Initialisation for Nunit Testing Framework
1. dotnet add package NUnit
2. dotnet add package NUnit3TestAdapter
3. dotnet new nunit

# For Postman API
1. Open Postman Tools
2. Create a new post request
3. Copy and paste the endpoint url from the .Net WebAPI
4. Enter the Content Type in Header
5. Change the Body format to JSON and have them in raw and you can enter the input in the body
6. Make sure you dotnet run without any other process interfering so that the code is running and you can send request
