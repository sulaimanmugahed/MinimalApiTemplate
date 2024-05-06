
# Minimal API Clean Architecture Template

This project is a template for creating a new minimal API project in .NET Core 8, following the principles of Clean Architecture. It provides a modular and maintainable codebase by enforcing a clear separation of concerns and independence of dependencies.

## Features


## Getting Started

To use this template, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/your-repository.git`
2. Install the required dependencies.
3. Build and run the project.

## Architecture Overview

The Clean Architecture pattern divides the codebase into the following layers:

1. **Presentation Layer**: Handles HTTP requests and responses.
2. **Application Layer**: The application layer sits just outside the domain layer and acts as an intermediary between the domain layer and other layers. In other words, it contains the use cases of the application and we expose the core business rules of the domain layer through the application layer. This layer depends just on the domain layer.
3. **Domain Layer**: The domain layer represents the application’s core business rules and entities. This is the innermost layer and should not have any external dependencies.
4. **Persistence Layer**: We implement all the external services like databases, file storage, emails, etc. in the infrastructure layer. It contains the implementations of the interfaces defined in the domain layer.
5. **Identity Layer**: this layer the same as Persistence but handle only the Identity of the application

For a detailed explanation of Clean Architecture, refer to the "Architecture" section below.

## Directory Structure

The project directory is organized as follows:

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
|    ├── Presentation
|       ├── MinimalApiTemplate.Api
|
├── test

```


