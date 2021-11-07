# Pierre's Treats and flavors tracker

#### _A web-based application to track Pierre's bakery's treats and flavors._

#### By **Sisi Vieira**

## Technologies Used

* _C#_
* _.NET 5.0.100_
* _ASP.NET Core MVC_
* _donet.ef.5.0.10_
* _Microsoft.NET.Sdk.Web_
* _Microsoft.NET.Test.Sdk 15.0.0_
* _MSTest.TestAdapter 1.3.2_
* _MSTest.TestFramework 1.3.2_
* _Microsoft.AspNetCore.Identity.EntityFrameworkCore 5.0.0_
* _Microsoft.EntityFrameworkCore 5.0.0_
* _Microsoft.EntityFrameworkCore.Design 5.0.0_
* _Pomelo.EntityFrameworkCore.MySql 5.0.0-alpha.2_

## Description

* A user should be able to see a list of all treats, and they are able to see a list of all flavors.
* A treat can have many flavors and a flavor can have many treats.
* The application should have user authentication. A user should be able to log in and log out. Only logged in users should have create, update and delete functionality. All users should be able to have read functionality.
* A user should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

## Setup/Installation Requirements

### Install C#, .NET, MySQL Community Server and MySQL Workbench
* Open the terminal on your local machine
* If [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) and [.NET](https://docs.microsoft.com/en-us/dotnet/) are not installed on your local device, follow the instructions [here](https://www.learnhowtoprogram.com/c-and-net-part-time-c-and-react-track/getting-started-with-c/installing-c-and-net)
* If [MySQL Community Server](https://dev.mysql.com/downloads/mysql/) and [MySQL Workbench](https://www.mysql.com/products/workbench/) are not installed on your local device, follow the instructions [here](https://www.learnhowtoprogram.com/c-and-net-part-time-c-and-react-track/getting-started-with-c/installing-and-configuring-mysql)
* If [dotnet-ef](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) is not installed on your local device, install it with the terminal command `dotnet tool install --global dotnet-ef --version 5.0.10`

### Clone the project
* Navigate to the directory inside of which you wish to house this project
* Clone this project with the command `$ git clone https://github.com/cicy886/PierresTreat.Solution.git`

### Scaffold and connect the database
* Launch the MySQL server with the command `mysql -uroot -p[YOUR-PASSWORD-HERE]`
* In your terminal, navigate to the production project directory with the command `$ cd PierresTreat.Solution/PierresTreat`
* In your terminal, create a file within the project in which to store your connection string for connecting the project to the database with the command `touch appsettings.json`
* In your text editor add the following code to the newly created appsettings.json file. *Note that uid and pwd may vary depending on your local MySql configurations.
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=sisi_vieira;uid=root;pwd=[YOUR-PASSWORD-HERE];"
  }
}
```

### Using Migration
* In your terminal, use command `dotnet ef migrations add [Name]` and `dotnet ef database update` after you make any changes to the models and want to update the database.
* In your terminal, use command `dotnet ef migrations remove` if you made a mistake with your most recent migraton and you haven't pushed the changes to Github.

### Run the project
* Recreate project environment and install required dependencies with terminal command `$ dotnet restore`
* Run the program in the console with the command `$ dotnet run`

## Known Bugs

* No known bugs.

## License
[MIT](https://opensource.org/licenses/MIT)

Copyright (c) **2021 Sisi Vieira**