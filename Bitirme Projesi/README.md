# SmartMunicipality

SmartMunicipality is a modern, comprehensive municipal management web application designed to connect citizens with local government services. The platform features bill payments, subscription management, complaint reporting, operator dashboards, and an AI-driven chatbot helper.

## Features

- **Citizen Portal**:
  - Subscription Management (Water, Gas, Electricity, etc.)
  - Bill Viewing and Secure Payments
  - Complaint Submission and Status Tracking
  - Profile Management

- **Operator Portal**:
  - Centralized Complaint Processing and Status Updates
  - Subscription Approval and Management
  - Billing Administration

- **AI Chatbot Helper**:
  - Integrated municipal assistant using Gemini / OpenAI API
  - Helps citizens with guidelines, general inquiries, and drafting complaints

- **Clean Architecture & Multi-Layer Design**:
  - Separate concerns with Data Access, Model, and Web layers
  - Hybrid ORM capability using both Entity Framework Core (EF Core) and Dapper for performance optimization

## Technology Stack

- **Backend**: .NET 8 Web API & MVC
- **Data Access**: Entity Framework Core & Dapper
- **Database**: SQL Server
- **Authentication**: ASP.NET Core Identity & JWT (JSON Web Tokens)
- **Logging**: Serilog
- **Documentation**: Swagger UI

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or Express)

### Setup

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd SmartMunicipality
   ```

2. **Configure Database Connection**:
   Update the connection string under `ConnectionStrings:DefaultConnection` in `appsettings.json` for both `SmartMunicipality.EFCoreApi` and `SmartMunicipality` projects.

3. **Run Migrations & Seed Data**:
   Database seeding runs automatically on startup.

4. **Run the projects**:
   You can run both the API and Web MVC application simultaneously or individually:
   ```bash
   dotnet run --project SmartMunicipality.EFCoreApi
   dotnet run --project SmartMunicipality
   ```
