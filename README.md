# MyBlogs: A Robust Blog Management System

## Overview

MyBlogs is a small blog project developed using .NET 6. It provides a simple and efficient way to manage blog content through a RESTful API. The project contains the following entities: Author, Article, and ArticleType. Each entity supports CRUD operations and a pagination query for the "retrieve" operation. The system leverages asynchronous programming for CRUD operations, ensuring high performance and responsiveness. All APIs have been tested using Swagger.

## Core Entities

The system revolves around three primary entities:
- Author
- Article
- ArticleType

Each entity is fully equipped with asynchronous CRUD operations, ensuring a seamless and flexible content management experience. Additionally, a pagination query has been implemented for the "Retrieve" operation, enhancing the system's scalability and performance.

## Technology Stack

- **Programming Language**: C# .NET 6
- **Authentication**: JWT for robust and secure Authentication and Authorization
- **Architecture**: MVC (Model, Repository, Services, Controller) for a clean and maintainable structure
- **ORM Framework**: SqlSugar, a lightweight yet powerful ORM Framework
- **Database**: MySQL, a reliable and widely-used open-source database
- **Object Mapping**: AutoMapper on DTO for efficient object-to-object mapping

## Packages Utilized

### BlogsPlatform [net6.0]
- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1
- Microsoft.AspNetCore.Authentication.JwtBearer 6.0.7
- Swashbuckle.AspNetCore 6.5.0

### MyBlog.Model [net6.0]
- SqlSugarCore 5.1.4.162

### MyBlog.Repository [net6.0]
- SqlSugar.IOC 2.0.0

### MyBlog.JWT [net6.0]
- Swashbuckle.AspNetCore 6.5.0
- System.IdentityModel.Tokens.Jwt 7.6.3

## Getting Started

To get started with MyBlogs, ensure that you have .NET 6 and MySQL installed on your machine. After cloning the repository, restore the necessary packages by executing `dotnet restore` in the root directory of the project.

## Usage

1. **Running the JWT Service**:
   - Begin by navigating to the `MyBlog.JWT` directory.
   - Execute the command `dotnet run`.
   - Once the service is active, you can access the Swagger UI at `http://localhost:6060/swagger` to interact with the APIs.

2. **Running the Blog Project**:
   - Navigate to the `BlogsPlatform` directory.
   - Execute the command `dotnet run`.
   - With the application running, you can access the Swagger UI at `http://localhost:7146/swagger` to interact with the APIs.

3. **Accessing Protected APIs**:
   - This project uses JWT for authentication. Some APIs in the blog project require authentication, and you will receive a 401 error if you try to access them without logging in.
   - Start by running the blog project and use the `createAuthor` API to create a user.
   - Next, run the JWT service and use the `login` API. Enter your username and password.
   - You will receive a token in the response. Copy this token.
   - Click on the `Authorize` icon and enter the token in the following format: "Bearer {your token}".
   - You should now have access to all APIs.


### Azure
   - The web application API has been deployed on Azure.
   - You can explore and use the [blogs API](https://mytempblogswebapi.azurewebsites.net/swagger/index.html) and [JWT API](https://tempblogjwt.azurewebsites.net/swagger/index.html).

   - Some APIs are accessible without authentication. For example: 
      - Author: Author; FindAuthor; CreateAuthor
      - Type: Type
      - etc.

   - To access protected APIs, follow these steps:
      1. Use CreateAuthor API to create an author 
      2. Access login API from [JWT API](https://tempblogjwt.azurewebsites.net/swagger/index.html) using the accountNumber and password you just created
      3. If successful, you will receive a token in the response body: response["data"]
      4. Go back to [blogs API](https://mytempblogswebapi.azurewebsites.net/swagger/index.html). Click the Authorize icon at the top right corner. 
         - Enter "Bearer {your token}" (without quotation marks and curly braces).
         - Note: There should be a whitespace between "Bearer" and your token.
      5. Now, you can access all APIs!





