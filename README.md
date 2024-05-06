
# Minimal API Clean Architecture Template

This project is a template for creating a new minimal API project in .NET Core 8, following the principles of Clean Architecture. It provides a modular and maintainable codebase by enforcing a clear separation of concerns and independence of dependencies.

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
|        ├── MinimalApiTemplate.Persistence
|
├── test
```

## Usage

To add new features or modify existing ones, follow these guidelines:

1. Define new endpoints in the `YourProject.Api` project.
2. Implement business logic in the `YourProject.Application` project.
3. Define entities, rules, and behaviors in the `YourProject.Domain` project.
4. Implement infrastructure-related code (e.g., database access) in the `YourProject.Infrastructure` project.

Make sure to adhere to the principles of Clean Architecture, keeping the layers decoupled and the dependencies flowing inward.

## Testing

To write tests for the project, follow these best practices:

- Write unit tests for the domain and application layers.
- Test business logic independently of infrastructure concerns.
- Use mocking frameworks to isolate dependencies during testing.
- Aim for high test coverage to ensure code quality.

## Contributing

Contributions to this project are welcome! If you'd like to contribute, please follow these guidelines:

- Submit bug reports or feature requests through the issue tracker.
- Fork the repository and create a new branch for your contributions.
- Make your changes and submit a pull request with a clear description of the changes.


```

Feel free to customize the README file according to your project's specific details and requirements.
