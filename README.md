# 📚 Library Management System – ASP.NET Core Web API

A **clean, structured, and production-oriented Library Management System API**
built with **ASP.NET Core Web API**.

---

## 🎯 Project Objective

This project was built to demonstrate:

- Clean backend architecture with separation of concerns
- Service-based business logic
- Professional DTO design
- JWT Authentication & Role-based Authorization
- Entity Framework Core relationships
- Pagination with filtering and search
- Global Exception Handling Middleware
- ASP.NET Identity integration

---

## 🧱 Architecture & Design Principles

- Controllers are **thin** — no business logic
- Business logic lives in **Services**
- **DTOs** are used for all API contracts
- Entities are never exposed directly
- EF Core used with async queries and `AsNoTracking`
- Global Exception Handling via custom Middleware
- userId extracted from JWT Token Claims

---

## 🛠 Technologies

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- JWT Bearer Authentication
- AutoMapper
- LINQ & async/await
- Pagination with Filtering and Search
- Global Exception Handling Middleware
- RESTful API Design
- Git & GitHub

---

## 📦 Functional Scope

### 🔐 Authentication & Security
- User Registration with automatic **User** role assignment
- User Login returns a **JWT Token** with Claims
- All endpoints protected with `[Authorize]`
- Role-based access: **Admin** and **User**
- userId extracted from JWT Token Claims

### ✍ Author Management
- Create / Update / Delete authors
- Retrieve all authors with **Pagination and Search**
- Retrieve author by ID

### 📘 Book Management
- Create / Update / Delete books
- Retrieve all books with **Pagination and Search**
- Retrieve book by ID with author details

### 🔄 Borrowing System
- Borrow books
- Update borrow status (Borrowed / Returned / Overdue)
- Retrieve borrows by user with **Pagination**

### ⭐ Reviews System
- Add / Update / Delete reviews
- Retrieve reviews by book with **Pagination**
- Reviews linked to User and Book

---

## 🚨 Global Exception Handling

Custom **Exception Middleware** returns unified error responses.

| Exception | HTTP Status | When Used |
|-----------|-------------|-----------|
| `NotFoundException` | 404 | Resource not found |
| `BadRequestException` | 400 | Invalid input |
| `UnauthorizedException` | 401 | Unauthorized access |

```json
{
  "statusCode": 404,
  "message": "Author with ID 5 not found"
}
```

---

## 📄 Pagination

All list endpoints support pagination with filtering and search.

```
GET /api/authors?pageNumber=1&pageSize=10&search=john
GET /api/books?pageNumber=1&pageSize=10&search=clean+code
```

**Response structure:**
```json
{
  "data": [...],
  "pageNumber": 1,
  "pageSize": 10,
  "totalCount": 50,
  "totalPages": 5,
  "hasPreviousPage": false,
  "hasNextPage": true
}
```

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
| GET | /api/authors | Get all authors (paginated) | ✅ |
| GET | /api/authors/{id} | Get author by ID | ✅ |
| POST | /api/authors | Create author | ✅ |
| PUT | /api/authors/{id} | Update author | ✅ |
| DELETE | /api/authors/{id} | Delete author | ✅ |

### Books
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | /api/books | Get all books (paginated) | ✅ |
| GET | /api/books/{id} | Get book by ID | ✅ |
| POST | /api/books | Create book | ✅ |
| PUT | /api/books/{id} | Update book | ✅ |
| DELETE | /api/books/{id} | Delete book | ✅ |

### Borrowing
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | /api/borrow | Get borrows by user (paginated) | ✅ |
| POST | /api/borrow | Borrow a book | ✅ |
| PUT | /api/borrow/{id} | Update borrow status | ✅ |

### Reviews
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | /api/reviews/book/{bookId} | Get reviews by book (paginated) | ✅ |
| POST | /api/reviews | Add review | ✅ |
| PUT | /api/reviews/{id} | Update review | ✅ |

---

## 🚀 Getting Started

1. Clone the repository
2. Configure `appsettings.json` using `appsettings.Example.json` as reference
3. Apply migrations: `Update-Database`
4. Run and open Swagger UI
5. Register → Login → Authorize → Test Endpoints

---

## 🔒 Security

- JWT Token authentication
- Role-based access control
- userId from JWT Claims — never from QueryString
- Global Exception Handling prevents stack trace exposure

---

## 🧑‍💻 Author

**Mohammad Al-Mohammad**
Backend Developer – ASP.NET Core
