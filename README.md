
## Overview

RecyclingApp is a web application designed to manage and track recyclable items. Users can create, edit, and delete recyclable items, and the application calculates rates based on the weight and type of recyclable items.

## Features

- Create, edit, and delete recyclable items.
- View detailed information about recyclable items.
- Automatically calculate and display the rate for recyclable items based on their weight and type.

## Requirements

- **.NET Framework**: This application is built on ASP.NET MVC 5.
- **Entity Framework**: For database interactions.
- **Microsoft SQL Server**: Ensure you have a SQL Server instance to host the database.
- **Visual Studio**: Recommended for development and running the application.

## Installation

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/yourusername/RecyclingApp.git
   cd RecyclingApp
Open the Project:
Open the RecyclingApp.sln file in Visual Studio.

Install NuGet Packages:
Restore the NuGet packages by running the following command in the Package Manager Console:

powershell
Copy code
Update-Package
Configure Database:
Ensure that your ApplicationDbContext is properly configured to connect to your SQL Server database. You may need to update the connection string in Web.config.

Run Migrations:
Run the following command in the Package Manager Console to apply any pending migrations:

powershell
Copy code
Update-Database
Build and Run:
Build the project and run it from Visual Studio.

Usage
Navigate to the Application:
Open your web browser and navigate to http://localhost:xxxx (replace xxxx with the port number assigned by Visual Studio).

Manage Recyclable Items:
Use the navigation menu to create, view, edit, and delete recyclable items.

Rate Calculation:
The application will automatically calculate the rate based on the selected recyclable type and the weight of the item.

Video Demonstration
For a demonstration of the application, you can watch the following video:
https://youtu.be/HFP7sjeKUVc

Contributing
Feel free to fork the repository, make changes, and create a pull request. Please ensure that your changes adhere to the coding standards and include tests where applicable.

License
This project is licensed under the MIT License - see the LICENSE file for details.

Acknowledgements
ASP.NET MVC 5
Entity Framework
Microsoft SQL Server
