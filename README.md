# 📚 Library Management System – ASP.NET Core Web API

A **clean, structured, and production-oriented Library Management System API**
built with **ASP.NET Core Web API**.

This project focuses on **backend architecture, best practices, and real-world design decisions**, making it ideal as a **portfolio project**.

---

## 🎯 Project Objective

This project was built to demonstrate:

- Clean backend architecture with separation of concerns
- Service-based business logic
- Professional DTO design
- JWT Authentication & Role-based Authorization
- Entity Framework Core relationships
- Global Exception Handling with custom exceptions
- ASP.NET Identity integration

---

## 🧱 Architecture & Design Principles

The project follows a **Clean Architecture–inspired approach**:

- Controllers are **thin** — no business logic
- Business logic lives in **Services**
- **DTOs** are used for all API contracts
- Entities are never exposed directly
- EF Core used with async queries and `AsNoTracking`
- Global Exception Handling via custom Middleware

---

## 🛠 Technologies

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- JWT Bearer Authentication
- AutoMapper
- LINQ
- Global Exception Handling Middleware
- RESTful API Design

---

## 📦 Functional Scope

### 🔐 Authentication & Security
- User Registration with automatic **User** role assignment
- User Login returns a **JWT Token** with Claims
- All endpoints protected with `[Authorize]`
- Role-based access: **Admin** and **User**
- userId extracted from JWT Token Claims

---

### ✍ Author Management
- Create / Update / Delete authors
- Retrieve all authors or by ID

---

### 📘 Book Management
- Create / Update / Delete books
- Retrieve all books or by ID
- Books include author details

---

### 🔄 Borrowing System
- Borrow books
- Update borrow status (Borrowed / Returned / Overdue)
- Retrieve all borrows by user
- Includes Book, Author, and borrow date tracking

---

### ⭐ Reviews System
- Add reviews for books
- Update / Delete your own reviews
- Retrieve reviews by book
- Reviews linked to User, Book, and Author

---

## 🚨 Global Exception Handling

The API uses a custom **Exception Middleware** that intercepts all unhandled exceptions and returns a unified error response.

### Custom Exceptions

| Exception | HTTP Status | When Used |
|-----------|-------------|-----------|
| `NotFoundException` | 404 | Resource not found |
| `BadRequestException` | 400 | Invalid input or request |
| `UnauthorizedException` | 401 | Unauthorized access |

### Unified Error Response

```json
{
  "statusCode": 404,
  "message": "Author with ID 5 not found"
}
```

### Benefits
- Controllers are clean — no try-catch blocks
- Consistent error responses across all endpoints
- Centralized error logging

---

## 📑 DTO Strategy

Each operation uses **dedicated DTOs**:

- **Create DTOs** — for creating new records
- **Update DTOs** — for modifying existing records
- **Response DTOs** — for API responses

---

## 🔑 API Endpoints

### Auth
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| POST | /api/auth/register | Register new user | ❌ |
| POST | /api/auth/login | Login and get JWT Token | ❌ |
| POST | /api/auth/addrole | Assign role to user | ✅ Admin |

### Authors
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | /api/authors | Get all authors | ✅ |
| GET | /api/authors/{id} | Get author by ID | ✅ |
| POST | /api/authors | Create author | ✅ |
| PUT | /api/authors/{id} | Update author | ✅ |
| DELETE | /api/authors/{id} | Delete author | ✅ |

### Books
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | /api/books | Get all books | ✅ |
| GET | /api/books/{id} | Get book by ID | ✅ |
| POST | /api/books | Create book | ✅ |
| PUT | /api/books/{id} | Update book | ✅ |
| DELETE | /api/books/{id} | Delete book | ✅ |

### Borrowing
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | /api/borrow/user/{userId} | Get borrows by user | ✅ |
| POST | /api/borrow | Borrow a book | ✅ |
| PUT | /api/borrow/{id} | Update borrow status | ✅ |

### Reviews
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | /api/reviews/book/{bookId} | Get reviews by book | ✅ |
| POST | /api/reviews | Add review | ✅ |
| PUT | /api/reviews/{id} | Update review | ✅ |

---

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   ```

2. **Configure settings** using `appsettings.Example.json` as reference:
   ```json
   {
     "ConnectionStrings": {
       "MyCon": "YOUR_CONNECTION_STRING_HERE"
     },
     "JWT": {
       "Key": "YOUR_SECRET_KEY_MIN_32_CHARACTERS",
       "Issuer": "LibraryAPI",
       "Audience": "LibraryAPIUsers",
       "DurationInDays": 7
     }
   }
   ```

3. **Apply migrations**
   ```bash
   Update-Database
   ```

4. **Run the application** and open Swagger UI

5. **Test the API:**
   ```
   Register → Login → Copy Token → Authorize in Swagger → Test Endpoints
   ```

---

## 🔒 Security

- Secure password hashing via ASP.NET Identity
- JWT Token authentication
- All endpoints protected with `[Authorize]`
- Role-based access control
- Global Exception Handling prevents stack trace exposure

---

## 💼 Portfolio Note

This project is intentionally designed as a medium-scale backend system to showcase real-world API design, clean code, global exception handling, and architectural thinking.

---

## 🧑‍💻 Author

**Mohammad Al-Mohammad**
Backend Developer – ASP.NET Core
