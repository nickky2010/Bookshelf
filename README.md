# RESTful Web API on an ASP.NET Core platform using Swagger

This application is a web service that can interact with various applications. At the same time, the application can be an `ASP.NET` web application, or it can be a mobile or regular desktop application.
***
#### What is `Swagger`?

`Swagger™` is a project used to describe and document `RESTful APIs`.

The `Swagger` specification defines a set of files required to describe such an API. These files can then be used by the `Swagger-UI` project to display the `API` and `Swagger-Codegen` to generate clients in various languages. Additional utilities can also take advantage of the resulting files, such as testing tools.

***
## Brief description of this project:


* mapping betwing models from Automapper; 
* dependency injection from `ASP.NET Core` and `Ninject`;
* handling concurrency issues for entities; 
* patterns `Repository` and `UnitOfWork`;
* localization of exceptions on Russian and English languages;
* `Lazy` initialization in `EFUnitOfWork` class;
* overload methods `OrderByBubble()` and `OrderByShell()` which give ability sort by column name;
* basic authorization and authentication functionality;
* functionality middleware exception error handling;
* all relationships between models are used (one to one, one to many, many to many);
* data validation.

#### View of the application window after launch:

![Alt text](/Task/Image/1.png?raw=true "View of the application window after launch")
***
## Work with the application:
***
#### Authorization and authentication functionality:

![Alt text](/Task/Image/2.png?raw=true "")

#### Token:

![Alt text](/Task/Image/3.png?raw=true "")

#### Authorization:

![Alt text](/Task/Image/4.png?raw=true "")

![Alt text](/Task/Image/5.png?raw=true "")

#### Services functionality:

![Alt text](/Task/Image/6.png?raw=true "")

#### Author service (GET method) functionality:

![Alt text](/Task/Image/7.png?raw=true "")

#### Server responce on GET method:

![Alt text](/Task/Image/8.png?raw=true "")

#### Report service functionality:

![Alt text](/Task/Image/9.png?raw=true "")

#### Server responce on Report service method:

![Alt text](/Task/Image/10.png?raw=true "")

#### If you are not authorized and authenticated, server responce on Report service method:

![Alt text](/Task/Image/11.png?raw=true "")


