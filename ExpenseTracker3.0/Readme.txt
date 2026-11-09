# ExpenseTracker3.0

A .NET 8 ASP.NET Core MVC application for creating, viewing, editing, and deleting personal expenses.

## Features

- View all expenses
- Display the total expense amount
- Add new expenses
- Edit existing expenses
- Delete expenses
- Categorize expenses by type
- Select an expense date
- Store expense data in SQL Server
- Use custom edit and delete images

## Technologies

- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap
- Razor views
- C# 12

## Project Structure


## Requirements

Install the following software before running the application:

- Visual Studio 2022 or newer
- .NET 8 SDK
- SQL Server or SQL Server LocalDB
- Entity Framework Core tools

## Database Configuration

The application uses Entity Framework Core with SQL Server.

Update the connection string in `appsettings.json` to match your SQL Server installation:


Also make sure the SQL Server connection used in `Program.cs` matches your database server.

> Do not commit passwords or sensitive connection strings to source control.

## Create or Update the Database

Open the Visual Studio Package Manager Console and run:


If migrations already exist, only run:


Alternatively, use the .NET CLI:


## Running the Application

1. Open `ExpenseTracker3.0.sln` in Visual Studio.
2. Verify the SQL Server connection.
3. Apply the database migrations.
4. Set `ExpenseTracker3.0` as the startup project.
5. Press `F5` or select **Start Without Debugging**.

The application opens in a browser using the configured HTTPS or HTTP launch URL.

## Main Pages

| Page | Description |
|---|---|
| `/Home/Index` | Application home page |
| `/Home/Expenses` | Displays all expenses and the total |
| `/Home/CreateEditExpense` | Creates or edits an expense |
| `/Home/Privacy` | Privacy page |

## Expense Fields

Each expense contains:

- `Value` — Expense amount
- `Description` — Expense description, up to 75 characters
- `ExpenseType` — Expense category
- `ExpenseDate` — Date of the expense

## Image Files

Custom images used by the application should be stored in:


They can then be referenced in Razor views using paths such as:


## Troubleshooting

### Database connection errors

- Confirm that SQL Server is running.
- Verify the server name in `Program.cs` and `appsettings.json`.
- Confirm that the database exists.
- Run `Update-Database`.

### Images are not displayed

- Confirm that the image is inside `wwwroot/images`.
- Verify the filename and file extension.
- Use a web path such as `~/images/example.png`, not a local Windows path.

### Changes are not visible

- Rebuild the project.
- Refresh the browser.
- Clear the browser cache if necessary.

## License

This project is for educational and personal use.

