# BiletSinema (Streamflix)
![Project Cover Image](placeholder-cover.jpg)
### About The Project
BiletSinema is a comprehensive content management system developed using **ASP.NET Core MVC** and **Entity Framework Core**. Designed with a modern UI inspired by popular streaming platforms, the project provides CRUD operations for movies, TV series, theaters, and categories, along with advanced reporting screens, data analysis features, and secure administrator management.
### Features
#### Admin & Security Management
![Admin Panel Image](placeholder-admin-panel.jpg)
* Integration of **ASP.NET Core Identity**
* Secure administrator authentication and authorization
* Dynamic admin user creation through the admin panel dashboard
* Safe and encrypted password handling
#### Movie Management
![Movie List Image](placeholder-movies.jpg)
* List movies
* Add movies
* Update movies
* Delete movies
* Search and filtering
* PDF and Excel export
#### TV Series Management
![TV Series Image](placeholder-series.jpg)
* List TV series
* Add TV series
* Update TV series
* Delete TV series
* Search and filtering
* PDF and Excel export
#### Theater Management
![Theater Image](placeholder-theater.jpg)
* List theaters
* Add theaters
* Update theaters
* Delete theaters
* Search and filtering
* PDF and Excel export
#### Category Management
* List categories
* Add categories
* Update categories
* Delete categories
* PDF and Excel export
#### Reporting & Analytics System
![Reporting Charts Image](placeholder-reports.jpg)
* Movie and category relationship reports
* Category-based analysis
* LINQ Join queries
* LINQ Group By queries
* Chart-based reporting screens (integrated with Chart.js)
* Statistical data visualization
#### User Interface
![User Interface Image](placeholder-ui.jpg)
* Dynamic and responsive Netflix-style dark theme UI
* Seamless horizontal content scrolling
* Live search functionality via JavaScript
* External QR Code redirection support to relevant platforms (e.g., IMDB)
### Technologies Used
* ASP.NET Core MVC
* Entity Framework Core
* ASP.NET Core Identity
* SQL Server
* LINQ
* HTML5, CSS3, JavaScript
* Bootstrap 5
* Chart.js
* QuestPDF
* EPPlus
### Database
The project strictly follows the **Code First** approach.
Migration commands:
```powershell
Add-Migration Init
Update-Database
Installation
Clone the repository.
Configure the connection string in appsettings.json according to your local SQL Server environment.
Run the migrations in the Package Manager Console or via CLI.
Start the application. (The default admin user is seeded automatically upon first run).
Purpose
This project was developed for educational, learning, and portfolio purposes.
