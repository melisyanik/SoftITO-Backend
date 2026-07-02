# BiletSinema

<div align="center">
  <!-- You can add a project logo or banner here -->
  <img src="docs/images/project-banner.png" alt="BiletSinema Banner" width="100%">
  
  <p align="center">
    <strong>A Content Management System for Movies, TV Series, and Theaters.</strong>
  </p>
</div>

## About The Project

BiletSinema is a web-based content management system (CMS) developed using ASP.NET Core MVC and Entity Framework Core. It is designed to handle relational data between entertainment media and provides an administration panel for managing movies, TV series, theaters, and their associated categories.

The project includes reporting screens, statistical data visualization, data exporting (PDF/Excel), and a secure authentication system for administrators.

![Dashboard Preview](docs/images/dashboard-preview.png)
> *Preview of the main administration dashboard and reporting charts.*

---

## Key Features

### Authentication & Authorization
* **Secure Login System:** Integrated with ASP.NET Core Identity for robust security.
* **Role Management:** Admin panel to manage users, assign roles, and restrict access to critical operations.
* **User Management:** Create, update, and manage administrative accounts.

![Admin & Identity Management](docs/images/admin-users.png)

### Content Management
* **Movie Management:** Complete control over movie listings. Add metadata, update details, and assign categories.
* **TV Series Management:** Track and manage TV series data efficiently.
* **Theater Management:** Keep track of theater plays, schedules, and details.
* **Dynamic Categorization:** Many-to-many relationship handling between content and categories.

![Content Management Screen](docs/images/content-management.png)

### Advanced Reporting & Analytics
* **Visual Dashboards:** Chart.js integration for visual data representation of categories and content distribution.
* **Complex LINQ Queries:** Utilizes Entity Framework Core capabilities (Join, Group By) to generate insights.
* **Export Capabilities:** 
  * Generate PDF reports using QuestPDF.
  * Export data tables to Excel format using EPPlus.

![Reporting & Analytics](docs/images/reporting-charts.png)

---

## Built With

This project leverages modern .NET technologies and popular frontend libraries:

### Backend
* ASP.NET Core MVC
* Entity Framework Core (Code-First approach)
* ASP.NET Core Identity
* C# / LINQ

### Frontend
* Bootstrap 5
* Chart.js
* Razor Views (.cshtml)

### Libraries & Tools
* QuestPDF
* EPPlus
* SQL Server

---

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine.

### Prerequisites
* .NET SDK
* SQL Server (LocalDB or a full instance)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/BiletSinema.git
   ```

2. Navigate to the project directory:
   ```sh
   cd BiletSinema
   ```

3. Configure the Database Connection:
   Open `appsettings.json` and update the `DefaultConnection` string to point to your SQL Server instance.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BiletSinemaDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. Run Entity Framework Migrations:
   
   Using .NET CLI:
   ```sh
   dotnet ef database update
   ```
   Or using Package Manager Console:
   ```powershell
   Update-Database
   ```

5. Run the Application:
   ```sh
   dotnet run
   ```

---

## Screenshots

<details>
<summary><b>Click to expand screenshots</b></summary>
<br>

**1. Movie List and Data Table**  
![Movie List](docs/images/movie-list.png)

**2. Add / Edit Content Form**  
![Add Content Form](docs/images/edit-form.png)

**3. PDF Export Output Example**  
![PDF Export](docs/images/pdf-export-example.png)

**4. Excel Data Export Example**  
![Excel Export](docs/images/excel-export-example.png)

</details>

---

## Purpose

This project was developed primarily for educational purposes to demonstrate proficiency in structuring an ASP.NET Core MVC application, implementing relational databases using EF Core, and integrating third-party libraries for reporting and visualization.
