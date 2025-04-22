# My ASP.NET Core Web API Projects

This repository contains a collection of ASP.NET Core Web API projects designed to showcase my skills in building RESTful services. Each project demonstrates different aspects of API development, from basic CRUD operations to more advanced concepts like authentication, data relationships, and integration with external APIs.

## Projects Overview

1.  **Task Management API**

    * **Description:** A RESTful API for managing tasks or to-do lists. Users can create, read, update, and delete tasks, assign priorities, set due dates, and mark tasks as completed.
    * **Technologies:** ASP.NET Core, Entity Framework Core (SQLite/SQL Server), (Optional) ASP.NET Core Identity.
    * **Features:**
        * CRUD operations for tasks.
        * Filtering tasks by status, priority, or due date.
        * Basic error handling and validation.
    * **Key Skills Demonstrated:** RESTful API design, database integration, CRUD operations.


## General Setup Instructions (Applicable to all projects)

These steps are a general guide.  Specific project requirements may vary, so refer to the project-specific sections for any deviations.

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) (Specify the minimum required version, e.g., .NET 6 or later)
* (Optional) A database management tool (e.g., [SQLite Browser](https://sqlitebrowser.org/), [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)) if you want to directly inspect the databases.

### Installation

1.  Clone the repository:

    ```bash
    git clone [https://github.com/your-username/your-repo-name.git](https://github.com/your-username/your-repo-name.git)
    ```

2.  Navigate to the project directory:

    ```bash
    cd your-repo-name
    ```

3.  (Optional - if you have a solution file) Restore dependencies:

    ```bash
    dotnet restore
    ```

### Building and Running

1.  Navigate to the specific project directory (e.g., `cd TaskManagementAPI`).
2.  Build the application:

    ```bash
    dotnet build
    ```

3.  Run the application:

    ```bash
    dotnet run
    ```

    * The application will typically start and display the base URL (e.g., `https://localhost:5001`).

4.  Use a tool like [Swagger UI](https://swagger.io/tools/swagger-ui/), [Postman](https://www.postman.com/), or [curl](https://curl.se/) to interact with the API endpoints.

## Project-Specific Details

### 1. Task Management API

* **Project Directory:** `TaskManagementAPI`
* **Database:**
    * SQLite (default):  The database file (`.db`) will be created in the application's output directory.
    * SQL Server:  If you want to use SQL Server, you'll need to:
        * Update the connection string in `appsettings.json`.
        * Ensure you have a SQL Server instance running.
        * Apply database migrations: `dotnet ef database update`
* **Authentication:** (If implemented) Follow the instructions in the project's README for user registration and login.
* **Endpoints:**
    * `GET /api/tasks`:  Get all tasks.
    * `GET /api/tasks/{id}`: Get a specific task.
    * `POST /api/tasks`: Create a new task.
    * `PUT /api/tasks/{id}`: Update a task.
    * `DELETE /api/tasks/{id}`: Delete a task.
* **Filtering:**
    * `GET /api/tasks?status=completed`:  Filter by status.
    * `GET /api/tasks?priority=high`: Filter by priority.
    * `GET /api/tasks?dueDate=2024-12-25`:  Filter by due date.
* **To Use:**
     * Create Tasks: Use POST /api/tasks
     * View all tasks: Use GET /api/tasks
     * Complete a task: Use PUT /api/tasks/{id} and set status to completed.






## Testing

[If you have unit tests for your projects, describe how to run them here.  Specify which projects have tests. If none of your projects have tests, you can remove this section or leave it commented out.\]
For Example:
### Running Unit Tests (for Task Management API)

1.  Navigate to the test project directory ( `cd TaskManagementAPI.Tests`).
2.  Run the tests:

    ```bash
    dotnet test
    ```
## Deployment



\[Optional:  For each project, list potential future features or improvements.  This demonstrates your ability to think ahead and plan for scalability and maintainability.  For example: "Implement soft deletes," "Add support for more complex filtering," "Implement a rate limiting middleware." \]
For Example:
* **Task Management API:**
    * Add Database.
    * Add deadline and timeline.
    * Implement email notifications for due dates.


## Author

\[Jervie]
[https://github.com/Kyzer0]
