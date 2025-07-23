# Rehli.RoP

Rehli.RoP is a .NET library designed to simplify and enhance the handling of results in functional programming. It provides a set of extensions and utilities to work with success and error flows, making your code more readable and maintainable.

## Features

- **Result Handling**: Centralized `Result` class to represent success and error states.
- **Extension Methods**: Includes `OnSuccess`, `OnError`, and `Fallback` extensions to streamline result processing.

## Project Structure

- **`Result.cs`**: Core implementation of the `Result` class.
- **`Extensions/`**: Contains extension methods for handling results:
  - `FallbackExtensions.cs`
  - `OnErrorExtensions.cs`
  - `OnSuccessExtensions.cs`
- **`bin/` and `obj/`**: Build and object files generated during compilation.

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later

### Installation

Clone the repository and navigate to the project directory:

```bash
git clone <repository-url>
cd Rehli.RoP
```

### Build

To build the project, run:

```bash
dotnet build
```


## License

This project is licensed under the MIT License.

## Contact

For questions or feedback, please open an issue on GitHub.
