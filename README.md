# Retrieve Shows Function

This project is an Azure Function that provides an API to retrieve a list of musical shows. It connects to a SQL database to fetch show details and returns them as a JSON response.

## Description

The `ReturnShows` function is an HTTP-triggered Azure Function. When invoked, it queries a SQL database view (`[dbo].[SHOWS_VW]`) using an Azure Functions SQL Input Binding and returns the results.

## Technologies Used

*   **Framework**: .NET 10
*   **Platform**: Azure Functions (Isolated Worker Model)
*   **Database Integration**: Azure Functions SQL Extension
*   **Language**: C#

## How to Build and Test

### Prerequisites

*   [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
*   [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
*   Visual Studio Code (recommended) with the Azure Functions extension.

### Build

To build the project, run the following command in the terminal:

```bash
dotnet build
```

### Run Locally

To start the function locally:

```bash
func start
```

Or, if using Visual Studio Code, simply press `F5` to start debugging.

The function will be available at: `http://localhost:7071/api/Shows`

### Test

You can test the API using the `ReturnShows.http` file included in the repository (requires the REST Client extension for VS Code) or via `curl`:

```bash
curl http://localhost:7071/api/Shows
```

## Production URL

The production API endpoint is:

```
GET https://retrieve-shows-api.azurewebsites.net/api/Shows?code=<FUNCTION_KEY>
```

*Note: Accessing the production endpoint requires a valid function key.*
