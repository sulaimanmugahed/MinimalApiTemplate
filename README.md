
# Minimal API Template

Setting up a new project can be a drag because you always have to deal
with dependencies and package configurations. This project offers a handy
template to kickstart your development. Built for .NET Core 8, it follows the
principles of Clean Architecture to keep your codebase organized and easy 
to manage. By separating different parts of the project and making 
dependencies independent, this template makes starting new projects
a breeze, saving you valuable time on setup.


## Getting Started

To use this template, follow these steps:

1. Clone the repository:

```
git clone https://github.com/sulaimanmugahed/MinimalApiTemplate.git
```

2. Navigate to the project directory:

```
cd <pathToRepo>/MinimalApiTemplate/
```

3. Now you need to install the template locally by run:

```
dotnet new install .
```
4. check if the template has been installed successfully:

```
dotnet new list         
```
 `You should find the name <c-mini-api> which is the short name of the template`
 


5. Finally create your first application with the template:

```
dotnet new c-mini-api -o YourProjectName
```

## Architecture Overview

The template Architecture pattern divides the codebase into the following layers:

1. **Presentation Layer**: Handles HTTP requests and responses.
2. **Application Layer**: The application layer sits just outside the domain layer and acts as an intermediary between the domain layer and other layers. In other words, it contains the use cases of the application and we expose the core business rules of the domain layer through the application layer. This layer depends just on the domain layer.
3. **Domain Layer**: The domain layer represents the application’s core business rules and entities. This is the innermost layer and should not have any external dependencies.
4. **Persistence Layer**: We implement all the external services like databases, file storage, emails, etc. in the infrastructure layer. It contains the implementations of the interfaces defined in the domain layer.
5. **Identity Layer**: This layer the same as Persistence layer , but focus only on the implementations of application Identity.


## Directory Structure

The template directory is organized as follows:

```
├── src
|   ├── Core          
|       ├── MinimalApiTemplate.Application  
|       ├── MinimalApiTemplate.Domain
|    
|   ├── Infrastructure
|       ├── MinimalApiTemplate.Identity
|       ├── MinimalApiTemplate.Persistence
|
|   ├── Presentation
|       ├── MinimalApiTemplate.Api
|
├── test
    ├── MinimalApiTemplate.Application.UnitTest

```


## Advantages of the architecture 

1. **Loose Coupling**:
Components are designed to be independent of each other. This allows for easier changes and maintenance without affecting other parts of the application.
2. **Testability**:
The core business logic resides in the independent layers, making it easier to write unit tests that focus on specific functionalities.
3. **Maintainability**:
Separation of concerns improves code readability and understanding, making it easier for developers to maintain the codebase in the long run.
4. **Flexibility**:
The core is independent of external frameworks and databases. This allows you to switch technologies like web frameworks or databases without affecting the core logic.
5. **Reusability**:
The core domain logic can be reused across different applications, promoting code sharing and reducing redundancy.

## Template Features 
1. User Auhentication and Authorization using Microsoft identity and jwt bearer token
2. Repository Pattern and UnitOfWork 
3. Entity Tracking and SoftDelete technique 
4. CQRS with MediatR
5. Swagger Client and Documentation
6. Endpoints Versioning
7. logging system with Serilog library
8. Custom Endpoints Filter
9. Fluent Validation
10. UnitTest with xUnit , moq, and Fluent Assertion

    

 
 

