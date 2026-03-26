📚 Library Management System – ASP.NET Core Web API
A clean, structured, and production-oriented Library Management System
built with ASP.NET Core Web API.
This project focuses on backend architecture, best practices, and real-world design decisions, making it ideal as a portfolio project.
🎯 Project Objective
This project was built to demonstrate:
Clean backend architecture
Proper separation of concerns
Service-based business logic
Professional DTO design
Entity Framework Core relationships
ASP.NET Identity using UserId (not username)
JWT Authentication & Role-based Authorization
The goal is clarity, scalability, and maintainability, not UI complexity.
🧱 Architecture & Design Principles
The project follows a Clean Architecture–inspired approach:
Core Rules:
Controllers are thin
Business logic lives in Services
DTOs are used for all API contracts
No direct DbContext usage inside Controllers
Entities are never exposed directly
🛠 Technologies
ASP.NET Core Web API
Entity Framework Core
SQL Server
ASP.NET Identity
JWT Bearer Authentication
AutoMapper
RESTful API principles
📦 Functional Scope
🔐 Authentication & Security
User registration with automatic User role assignment
User login returns a JWT Token with Claims (userId, email, roles)
All endpoints protected with [Authorize]
Role-based access: Admin and User
Token validation: Issuer, Audience, Lifetime, Signing Key
👤 User Accounts
User registration
User login
ASP.NET Identity integration
All relations depend on UserId
✍ Author Management
Create / Update / Delete authors
Retrieve authors (list & details)
📘 Book Management
Create / Update / Delete books
Retrieve books with author details
🔄 Borrowing System
Borrow books
Update borrow status
Retrieve all borrows by user
Includes:
Book information
Author information
Borrow dates and status tracking
⭐ Reviews System
Add reviews for books
Update reviews
Retrieve reviews by book
Reviews are linked to:
User
Book
Author
📑 DTO Strategy
Each operation uses dedicated DTOs:
Create DTOs
Update DTOs
Response DTOs
This prevents:
Over-posting
Under-posting
Tight coupling between layers
🚀 Getting Started
Clone the repository
Configure connection string in appsettings.json:
Use appsettings.Example.json as a reference
Configure JWT settings in appsettings.json:
"JWT": {
  "Key": "YOUR_SECRET_KEY_MIN_32_CHARACTERS",
  "Issuer": "LibraryAPI",
  "Audience": "LibraryAPIUsers",
  "DurationInDays": 7
}
Apply migrations:
Update-Database
Run the application and open Swagger
Register → Login → Copy Token → Click Authorize in Swagger → Paste Token
🔑 API Endpoints
Auth
Method
Endpoint
Description
Auth Required
POST
/api/auth/register
Register new user
❌
POST
/api/auth/login
Login and get JWT Token
❌
POST
/api/auth/addrole
Assign role to user
✅ Admin only
Authors
Method
Endpoint
Description
Auth Required
GET
/api/authors
Get all authors
✅
GET
/api/authors/{id}
Get author by ID
✅
POST
/api/authors
Create author
✅
PUT
/api/authors/{id}
Update author
✅
DELETE
/api/authors/{id}
Delete author
✅
Books
Method
Endpoint
Description
Auth Required
GET
/api/books
Get all books
✅
GET
/api/books/{id}
Get book by ID
✅
POST
/api/books
Create book
✅
PUT
/api/books/{id}
Update book
✅
DELETE
/api/books/{id}
Delete book
✅
Borrowing
Method
Endpoint
Description
Auth Required
GET
/api/borrow/user/{userId}
Get borrows by user
✅
POST
/api/borrow
Borrow a book
✅
PUT
/api/borrow/{id}
Update borrow status
✅
Reviews
Method
Endpoint
Description
Auth Required
GET
/api/reviews/book/{bookId}
Get reviews by book
✅
POST
/api/reviews
Add review
✅
PUT
/api/reviews/{id}
Update review
✅
💼 Portfolio Note
This project is intentionally designed as a medium-scale backend system to showcase real-world API design, clean code, and architectural thinking.
