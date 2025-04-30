# ASP.NET Core Bookstore Application

This is a sample ASP.NET Core MVC web application built using .NET 8.0. The application uses Entity Framework Core with SQLite to manage a list of books and implements ASP.NET Core Identity for user authentication and authorization. 
Authenticated users can create, update, and delete books, while anyone can browse the list of books. Additional features include logging HTTP requests via a custom action filter and URL rewriting for cleaner route URLs.

## Features

- **CRUD for Books:** Create, Read, Update, and Delete books.
- **User Authentication:** Users can register, log in, and log out using ASP.NET Core Identity.
- **Authorization:** Only authenticated users may perform modifications (Create/Edit/Delete). The book list is publicly viewable.
- **Request Logging:** Custom filter logs HTTP requests and responses.
- **URL Rewriting:** Custom URLs such as `/store` (mapped to the Books list) and `/store/details/{id}` (mapped to Book details).
- **Graceful Error Handling:** Model-level validation and global error handling ensure clear error messages (e.g., when trying to create a book without an author).

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 (or later) or [Visual Studio Code](https://code.visualstudio.com/)
- Git

## Getting Started

Follow these steps to run the application locally:

1. **Clone the Repository**

   Open your terminal or command prompt and run:
   ```bash
   git clone https://github.com/JackTheRipper399/aspnetcore-bookstore.git
  
2. Navigate to the Project Directory
   
   cd aspnetcore-bookstore

3. Restore Dependencies
   Run the following command to restore the project’s NuGet packages:

   dotnet restore

4. Apply Migrations & Create the Database
   Use the Entity Framework Core CLI commands to create and seed the SQLite database:

   dotnet ef database update

5. Run the Application
   Start the application:

   dotnet run

   By default, the application will launch on https://localhost:5001 (or another URL as specified in your console output).

6. Access the Application
   Open your web browser and navigate to the URL provided above to explore the application.

## Deployment
You can deploy this ASP.NET Core Bookstore application to many hosting services. Below is an example of how you might deploy it to Azure App Service.

1. Publish the Application
   Use the .NET CLI to create a production build:
   
   dotnet publish -c Release -o ./publish

2. Create an App Service on Azure
   . Log in to the Azure Portal.
   . Navigate to App Services and click Create App Service.
   . Configure the basic settings (like resource group, application name, runtime stack—for .NET 8, choose the latest available—and region).

3. Deploy Your Application Files
   You have multiple options to deploy your published files:

   . Visual Studio Publish: In Visual Studio, use the Publish wizard to select Azure App Service and follow the steps to deploy your application automatically.
   . FTP or Local Git Deployment: Use the FTP details from the Azure portal or set up local Git deployment. For FTP, upload the contents of the /publish folder.
   . Azure CLI: Use Azure CLI commands to deploy your published folder. For example, you can use:
   az webapp deploy --resource-group YourResourceGroup --name YourAppServiceName --src-path ./publish

4. Configure Your Application Settings
   In the Azure portal, under your App Service's Configuration:
   . Set the ASPNETCORE_ENVIRONMENT variable to Production.
   . Update connection strings and any other environment variables (for example, the connection string for SQLite or any other database service, if needed).

5. Monitor and Scale
   Once deployed, use the Azure portal’s monitoring tools to check your application’s health and performance. You can also configure scaling options if required.

## Project Structure
Below is an overview of the repository’s folder structure:

aspnetcore-bookstore/ < br / >
│ < br / >
├── Areas/               # Contains scaffolder Identity UI pages (e.g., Login, Register) < br / >
│   └── Identity/ < br / >
│       └── Pages/ < br / >
│           └── Account/ < br / >
├── Controllers/         # MVC Controllers (e.g., BooksController.cs) < br / >
├── Data/                # EF Core DbContext and migrations (e.g., BookstoreContext.cs) < br / >
├── Filters/             # Custom filters (e.g., RequestLoggingFilter.cs) < br / >
├── Models/              # Model classes (e.g., Book.cs) < br / >
├── Views/               # MVC Views and layouts (e.g., _Layout.cshtml) < br / >
│   └── Shared/ < br / >
│       └── _Layout.cshtml < br / >
├── wwwroot/             # Static files (CSS, JS, images) < br / >
├── appsettings.json     # Application configuration and connection strings < br / >
├── Program.cs           # Application startup and middleware configuration < br / >
└── README.md            # This file < br / >
