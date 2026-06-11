# 🎓 University Management API

A RESTful backend API for managing university operations — students, courses, faculty, and enrollments — built with **ASP.NET Core** and **Clean Architecture** principles.

---

## 🚀 Tech Stack

* **Framework:** ASP.NET Core Web API (C#)
* **Database:** SQL Server & Entity Framework Core
* **Architecture:** Generic Repository Pattern `<T>`
* **API Docs:** Swagger / OpenAPI

---

## ⚙️ Key Features

* **Student Management:** Full CRUD operations for student records.
* **Course Management:** Create, update, and manage course listings.
* **Faculty Management:** Handle faculty profiles and assignments.
* **Enrollment System:** Manage student-course enrollments with ease.
* **Attendance Tracking:** Record and manage student attendance.
* **Mark Management:** Handle student marks and grades.
* **Generic Repository:** A single `Repository<T>` pattern eliminates code duplication across all entities.
* **EF Core Migrations:** Database schema managed entirely through code-first migrations.
* **RESTful Design:** Proper HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`) with correct status codes.
* **API Documentation:** Interactive Swagger UI for easy testing and exploration.

---

## 💻 How to Run Locally

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or later)
* SQL Server or LocalDB (comes with Visual Studio)

### Steps

1. **Clone this repository** to your local machine.

2. **Update the connection string** in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversityManagement;Integrated Security=True;"
  }
}
```

3. **Apply database migrations** to create the schema.

In **Package Manager Console (PMC)**:
```powershell
Update-Database
```

4. **Run the project:**
```powershell
dotnet run
```

5. Swagger UI will open automatically at:
```
https://localhost:{PORT}/swagger
```

---

## 📁 Project Structure

```
UniversityAPI/
├── Controllers/        # API endpoints (Students, Courses, Staff, Enrollments, Marks, Attendance)
├── Models/             # Entity classes
├── Repositories/       # Generic Repository<T> and entity-specific implementations
├── Services/           # Business logic layer
├── Data/               # DbContext and EF Core configuration
├── Middleware/         # Global exception handling
└── Migrations/         # Auto-generated EF Core migration files
```

---

## 📡 API Endpoints

### 👨‍🎓 Students
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/student` | Get all students |
| `GET` | `/api/student/{id}` | Get a student by ID |
| `POST` | `/api/student` | Create a new student |
| `PUT` | `/api/student/{id}` | Update a student |
| `DELETE` | `/api/student/{id}` | Delete a student |

### 📚 Courses
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/course` | Get all courses |
| `GET` | `/api/course/{id}` | Get a course by ID |
| `POST` | `/api/course` | Create a new course |
| `PUT` | `/api/course/{id}` | Update a course |
| `DELETE` | `/api/course/{id}` | Delete a course |

### 👨‍🏫 Staff
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/staff` | Get all staff members |
| `GET` | `/api/staff/{id}` | Get a staff member by ID |
| `POST` | `/api/staff` | Add a new staff member |
| `PUT` | `/api/staff/{id}` | Update a staff member |
| `DELETE` | `/api/staff/{id}` | Delete a staff member |

### 📝 Enrollments
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/enrollment` | Get all enrollments |
| `GET` | `/api/enrollment/{id}` | Get an enrollment by ID |
| `POST` | `/api/enrollment` | Enroll a student in a course |
| `DELETE` | `/api/enrollment/{id}` | Remove an enrollment |

### 📊 Marks
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/mark` | Get all marks |
| `POST` | `/api/mark` | Add a mark |
| `PUT` | `/api/mark/{id}` | Update a mark |
| `DELETE` | `/api/mark/{id}` | Delete a mark |

### 🗓️ Attendance
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/attendance` | Get all attendance records |
| `POST` | `/api/attendance` | Add an attendance record |
| `PUT` | `/api/attendance/{id}` | Update attendance |
| `DELETE` | `/api/attendance/{id}` | Delete attendance record |

---

## 🏛️ Design Decisions

* **Generic Repository `<T>`:** Instead of writing a separate repository for every entity, a single generic `Repository<T>` handles all common CRUD operations — eliminating code duplication and keeping the codebase clean.
* **Service Layer:** Business logic is separated into dedicated service classes, keeping controllers thin and clean.
* **Global Exception Middleware:** A custom `ExceptionMiddleware` handles all unhandled errors in one place, returning consistent error responses.
* **Code-First Migrations:** The entire database schema is defined in C# model classes and managed through EF Core migrations, making it easy to version-control and reproduce anywhere.

---

## 👤 Author

**Khuzaima Salman** — BS Computer Science
