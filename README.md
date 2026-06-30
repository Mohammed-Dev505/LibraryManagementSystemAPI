# 📚 Library Management System – ASP.NET Core Web API

A **clean, structured, and production-oriented Library Management System API** built with **ASP.NET Core Web API (.NET 8)** following strict **Clean Architecture** principles and enterprise design patterns.

---

## 🎯 Project Objective

This project was built to demonstrate advanced backend engineering capabilities, including:

* **Decoupled Architecture:** Clean separation of concerns across multiple layers.
* **Row-Level Security:** Bulletproof data isolation based on JWT identity tokens.
* **Dynamic RBAC (Role-Based Access Control):** Centralized administration endpoints to manage system privileges dynamically.
* **Robust Enterprise Features:** Dynamic filtering, global exception handling middleware, and automated fluent input validations.

---

## 🧱 Architecture & Design Principles

The solution is split into **4 decoupled layers** adhering strictly to **Clean Architecture** guidelines:

* **Domain Layer:** Core enterprise entities (`Book`, `Author`, `Borrow`, `Review`), fully isolated without external dependencies.
* **Application Layer:** Contains business workflows, interfaces, custom Exceptions, DTOs, AutoMapper profiles, and FluentValidation rules.
* **Infrastructure Layer:** Handles data persistence via EF Core, Identity setups, DB context configurations, and repository implementations.
* **Web API Layer:** The presentation tier containing thin controllers, centralized middlewares, and JWT authentication filters.

### 💎 Key Architectural Decisions:

* **Thin Controllers:** Controllers only route requests; 100% of the business logic is in the application services.
* **Data Capsulation:** Domain entities are never exposed directly to the client; all contracts utilize strictly mapped DTOs.
* **Performance Optimization:** Async queries (`async/await`) utilized universally combined with `.AsNoTracking()` for read-only operations.

---

## 🛠️ Technologies

* **Framework:** ASP.NET Core Web API (.NET 8)
* **Database & ORM:** Microsoft SQL Server + Entity Framework Core (Code-First)
* **Security:** ASP.NET Core Identity + JWT Bearer Token Authentication
* **Mapping & Validation:** AutoMapper & FluentValidation
* **API Documentation:** Swagger / OpenAPI with Authorization Header Support
* **Design Patterns:** Unit of Work & Repository Pattern
* **Other Tools:** LINQ & RESTful API Design, Git & GitHub

---

## 🚀 Key Technical Features

### 🔐 1. Identity & Dynamic Role-Based Security (RBAC)

* **Automatic Access Control:** Registration defaults users to the **User** role securely.
* **Dynamic Role Management:** Embedded a protected administrative subsystem (`RolesController`) restricted exclusively to **Admin** users. This allows dynamic creation, deletion, and assignment of system roles to users on-the-fly without database modification.
* **Core Protection Rules:** The system safeguards critical structures by explicitly blocking the deletion of fundamental default roles (such as the main 'Admin' role).
* **Data Isolation:** Implemented strict resource ownership verification. In `ReviewService` and `BorrowService`, endpoints validate that the resource owner matches the authenticated `userId` extracted securely from JWT claims, preventing cross-user data tampering.

### 🔍 2. Dynamic, Defensive Filtering & Sorting

* **Smart Queries:** Advanced LINQ Expressions built defensively using `string.IsNullOrEmpty` checks. The API allows optional compound filtering (e.g., searching books by Title, Author Name, or both simultaneously) without throwing `NullReferenceException` if fields are left blank by the Front-End.
* **Server-Side Pagination:** Generic paging system (`Skip`/`Take`) to optimize data payloads, returning dynamic metadata like `totalPages` and `hasNextPage`.

### 🚨 3. Centralized Exception Handling Middleware

* Custom production-ready middleware that intercepts application exceptions globally, converting them into uniform, predictable JSON responses with proper HTTP Status Codes:
  * `NotFoundException` $\rightarrow$ **404 Not Found**
  * `BadRequestException` $\rightarrow$ **400 Bad Request**
  * `UnauthorizedException` $\rightarrow$ **401 Unauthorized**

---

## 🧩 Extension Methods Overview

To keep the `Program.cs` exceptionally clean and maintainable, services are registered using dedicated architectural extension classes:

| Extension Class | Responsibility |
|----------------|----------------|
| `DBExtension` | Database context registration |
| `IdentityExtension` | ASP.NET Identity setup |
| `AuthExtension` | JWT Authentication configuration |
| `ServicesExtension` | Application services & Unit of Work registration |
| `FluentValidationExtension` | FluentValidation automatic registration |
| `SwaggerExtension` | Swagger with JWT authorization bearer support |
| `MiddlewareExtension` | Centralized Global Exception Handling middleware |
| `SecurityMiddlewareExtension` | Authentication & Authorization middleware configuration |

**Resulting Clean `Program.cs` Structure:**

```csharp

builder.Services.AddDatabase(configuration);
builder.Services.AddIdentityService();
builder.Services.AddJwtAuthentication(configuration);
builder.Services.AddApplicationService();
builder.Services.AddValidationServices();
builder.Services.AddSwagger();

app.UseGlobalException();
app.UseSecurity();

✅ FluentValidation Strategy
All input payloads are strictly vetted with developer-friendly error messages before hitting the business layer:

| DTO | Validation Rules Applied |
|-----|--------------------------|
| `RegisterModel` | Username (3–50 chars), valid Email syntax, Password (min 6 chars) |
| `CreateAuthorDto` | Author Name is required (3–100 chars) |
| `CreateBookDto` | Title and ISBN are required, valid AuthorId link |
| `CreateBorrowDto` | Valid BookId reference, DueDate must be a strict future date |
| `CreateReviewDto` | Numerical Rating strictly constrained between (1–5), Comment required |


📄 Pagination

### Request

```http
GET /api/books?pageNumber=1&pageSize=10&search=clean+code
```

### Response

```json
{
  "data": [],
  "pageNumber": 1,
  "pageSize": 10,
  "totalCount": 50,
  "totalPages": 5,
  "hasPreviousPage": false,
  "hasNextPage": true
}
```

🔑 Core API Endpoints
🔐 Authentication

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/auth/register` | Registers a new user account | ❌ No |
| POST | `/api/auth/login` | Validates credentials & returns JWT Token | ❌ No |


🛠️ Role Administration

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/roles/get-all-roles` | Fetch all system roles registered in the database | ✅ Yes (Admin) |
| POST | `/api/roles/add-role` | Registers a new dynamic identity role  | ✅ Yes (Admin) |
| POST | `/api/roles/assign-role-to-user` | Links a specific role name to a user via User ID | ✅ Yes (Admin) |
| DELETE | `/api/roles/delete-role` | Drops a system role (Guarded against Admin delete) | ✅ Yes (Admin) |

✍️ Authors Management

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/authors` | Get all authors (Paginated + Dynamic Filter) | ✅ Yes |
| GET | `/api/authors/{id}` | Get author details by Guid ID | ✅ Yes |
| POST | `/api/authors` | Create a new author record | ✅ Yes (Admin) |
| PUT | `/api/authors/{id}` | Update existing author details | ✅ Yes (Admin) |
| DELETE | `/api/authors/{id}` | Safe delete an author record | ✅ Yes (Admin) |


📘 Books Management

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/books` | Get books (Paginated + Author/Title Search) | ✅ Yes |
| GET | `/api/books/{id}` | Get book by ID with eager-loaded Author details | ✅ Yes |
| POST | `/api/books` | Add a new book to the catalog | ✅ Yes (Admin) |
| PUT | `/api/books/{id}` | Update book details and copies available | ✅ Yes (Admin) |
| DELETE | `/api/books/{id}` | Remove a book from circulation | ✅ Yes (Admin) |


🔄 Borrowing Operations

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/borrow` | Retrieve active borrowings for the logged-in user | ✅ Yes |
| POST | `/api/borrow` | Borrow a book (Validates copies availability) | ✅ Yes |
| PUT | `/api/borrow/{id}` | Update borrowing state (Returned / Overdue) | ✅ Yes (Admin) |

⭐ Reviews & Ratings

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/reviews/book/{bookId}` | Get all paginated customer reviews for a book | ✅ Yes |
| POST | `/api/reviews` | Post a new review & rating (Linked to user token) | ✅ Yes |
| PUT | `/api/reviews/{id}` | Update review description/stars (Owner Only) | ✅ Yes |

⚙️ Getting Started & Local Installation

1. Prerequisites
.NET 8 SDK installed.
Microsoft SQL Server running locally.

2. Universal Database Configuration
The appsettings.json file inside the Web API project is preconfigured with a universal local server instance source (.\\). You do not need to manually modify the server name to run the migration:
"ConnectionStrings": {
  "DefaultConnection": "Data Source=.\\;Initial Catalog=LibraryManagementSystemAPI_DB;Integrated Security=True;TrustServerCertificate=True"
}

3. Applying Database Migrations (Package Manager Console)

Open the Package Manager Console (PMC) in Visual Studio, ensure the Default project dropdown is set to LibraryManagementSystemAPI (the main API startup target), and execute the following commands sequentially to generate migration files and construct your database schema:

# 1. Generate the migration assembly files inside the Infrastructure layer

Add-Migration InitialCreate -Project Infrastructure

# 2. Execute and apply the migrations to create the local database and tables

Update-Database


4. Running the Application
Register \rightarrow Login \rightarrow Authorize via Swagger \rightarrow Test Endpoints.
Run via Visual Studio (F5) or via .NET CLI:
dotnet run --project LibraryManagementSystemAPI.API

Once launched, explore the fully documented contract definitions by navigating to: https://localhost:XXXX/swagger.

​🧑‍💻 Author
​Mohammad Al-Mohammad – Backend Developer – ASP.NET Core Specialist.