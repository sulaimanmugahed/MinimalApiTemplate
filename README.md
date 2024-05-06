
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
2. **Application Layer**: Contains business logic and coordinates data flow.
3. **Domain Layer**: Defines core business entities, rules, and behaviors.
4. **Infrastructure Layer**: Deals with external concerns (e.g., databases, file systems).

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


