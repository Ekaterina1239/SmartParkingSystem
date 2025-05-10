Project Description
Smart Parking System is a software application designed to help manage parking spots and vehicles within a parking lot. This system allows users to park vehicles, release them, and track parking status, including the availability of parking spots and total revenue generated.

The project uses Entity Framework Core for database management, with SQL Server as the backend database. The system features a user interface (UI) that allows for easy interaction with the system, enabling users to:

Park a vehicle

Release a vehicle

View parking spot availability

Monitor total revenue generated

The application supports different types of vehicles, including cars, motorcycles, and electric cars, each with its own hourly rate. The system manages parking spots, keeping track of whether they are occupied and the vehicle parked in each spot.

Key Features
Park a Vehicle: Users can input the parking spot number, select a vehicle type (Car, Motorcycle, Electric Car), and park the vehicle in an available spot.

Release a Vehicle: Users can input the vehicle plate number to release the vehicle and calculate the parking fee based on the parking duration.

Parking Status: The system provides a list of occupied parking spots, available spots, and the total revenue generated.

Vehicle Management: The system supports multiple vehicle types and calculates parking fees based on vehicle type.

Technologies Used
C# for application logic.

Entity Framework Core for database operations.

SQL Server for storing parking lot and vehicle data.

WPF (Windows Presentation Foundation) for the UI.

.NET Core for cross-platform capabilities and future scalability.

How to Run
Prerequisites:
Visual Studio 2019/2022 or later.

.NET Core SDK (version 3.1 or later).

SQL Server or SQL Server LocalDB.

Setup Instructions:
Clone this repository to your local machine.

Open the project in Visual Studio.

Install required NuGet packages for Entity Framework Core:

Open NuGet Package Manager for the solution.

Search for and install Microsoft.EntityFrameworkCore.SqlServer and Microsoft.EntityFrameworkCore.Tools.

Open Package Manager Console in Visual Studio.

Run the following commands to create the database:

Add-Migration InitialCreate — This will generate the migration for the database schema.

Update-Database — This will apply the migration and create the database.

Press F5 to build and run the application.

The application will open a window where you can park a vehicle, release a vehicle, and check the status of the parking lot.
