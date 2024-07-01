# PagingBlazor
My inspiration of this project is from <a href="https://code-maze.com/blazor-webassembly-pagination/"> Here </a>

And then I implement with repository pattern(Most of my projects use this pattern) so I create this project to show how to use repository pattern with paging, it useful for my projects so I want to share to all.

This project show how to retrieve tons of data. If we have a lot of data and we want to query all data to show in web at only one request, It can produce error or request time out.
Therefore my idea to show each page per 10 records. If you want more record just click page number you want to see. So it posible to see many datas without timeout.

In the project I use Blazor WebAssembly to be fontend, and ASP.net core Web API to be backend.
## Tool
1. Visual studio 2022
2. SqlServer Express Edition
3. NSwagStudio v14.0.7

## PagingBlazor.Client
This project is Blazor WebAssembly It is my frontend project.
## PagingBlazor.API
This project is Web API It contain controller, service, repository and model(In real life I suggest to separate repository to individual project but in this case I just want to show how it working).
## PagingBlazor.Entities
This project is data manipulation. It contains EF DbContext and migration. (I think you should know this concept, I don't want to explian it if you want more detail I give you the link below)

## How to work
First of all you download all code and open with Visual Studio open **Package Manager Console** run this command 
```
PM> update-databse
```
After the database is created from this step. You have to see the tables **AddrInfo** and **__EFMigrationsHistory**, run insert query from file **AddrInfo.sql** or you uncomment the code in **20240701055544_initialDB.cs** from *PagingBlazor.Entities\Migrations* before you run migration command(*update-databse*) But I recommend you to run from SQL file is better because it faster (the examples of data around 10 thousand records).

At this point, if you run the program I think you should see the data when you click **Address Info** menu like picture below.

<img src="https://github.com/tree12/PagingBlazor/blob/main/images/image1.png" width="80%" title="hover text">

Everytime you click the page number It retrives the data in each page from the server.

## Tips
I use NSwagStudio to generate the file to connect to web API from Blazor WebAssembly because I lazy to manually create it(**ServiceGen.cs** in PagingBlazor.Client). if you want to know how to connect WebAPI with HttpClient class you can learn at this <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-8.0" target="_blank">link</a>

### Reference
https://code-maze.com/blazor-webassembly-pagination/

https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx

https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

