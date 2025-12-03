# 🏢 IKEACompany | HR Management System

![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%209.0-blue)
![Architecture](https://img.shields.io/badge/Architecture-N--Tier-green)
![License](https://img.shields.io/badge/License-MIT-orange)

A full-stack **Human Resources Management System** built with **ASP.NET Core MVC (.NET 9)**. The project implements the **N-Tier Architecture** to ensure clean separation of concerns, scalability, and maintainability. It simulates a real-world scenario for managing employees, departments, and administrative tasks.

---

## 🏗️ Architecture Overview

The solution is structured into three main independent layers (**N-Tier**):

| Layer | Project Name | Responsibilities |
| :--- | :--- | :--- |
| **Presentation (PL)** | `MVC04.PL` | Contains Controllers, Razor Views, ViewModels, and UI logic (Bootstrap/jQuery). |
| **Business Logic (BLL)** | `MVC04.BLL` | Handles business rules, Services, Interfaces, and AutoMapper profiles. |
| **Data Access (DAL)** | `MVC04.DAL` | Manages `DbContext`, Database Migrations, Entities, and Repositories. |

---

## ✨ Key Features

### 👥 Employee Management
* **CRUD Operations:** Create, Read, Update, and Delete employees.
* **Soft Delete:** Implemented to preserve data integrity (Archive instead of permanent delete).
* **Search & Filtering:** Dynamic search by name or email.
* **Image Handling:** Upload and manage employee profile pictures.

### 🏢 Department Management
* Organize company structure by creating and modifying departments.
* View employees assigned to specific departments.

### 🔐 Security & Authentication
* **ASP.NET Core Identity:** Secure Login and Registration system.
* **Role-Based Access Control (RBAC):**
    * `Admin`: Full access to create/edit/delete data.
    * `User`: Read-only access to view lists and details.

---

## 🛠️ Technology Stack

* **Framework:** ASP.NET Core MVC (.NET 9)
* **Database:** SQL Server
* **ORM:** Entity Framework Core 9.0 (Code-First)
* **Mapping:** AutoMapper
* **Dependency Injection:** Built-in .NET Container
* **Frontend:** HTML5, CSS3, Bootstrap 5, Razor Syntax

---

## 🚀 Getting Started

Follow these steps to set up the project locally:

### 1. Clone the Repository
```bash
git clone [https://github.com/TopKing74/IKEACompany.git](https://github.com/TopKing74/IKEACompany.git)
````

### 2\. Configure Database

Open `appsettings.json` in the **PL** project and check the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=.;database=IKEACompanyDB;Trusted_Connection=true;TrustServerCertificate=true"
}
```

*(Note: Change `server=.` to `server=.\\SQLEXPRESS` if you are using SQL Express)*

### 3\. Apply Migrations

Open **Package Manager Console** in Visual Studio:

1.  Set **Default Project** to `MVC04.DAL`.
2.  Run the command:
    ```powershell
    Update-Database
    ```

### 4\. Run the Application

  * Set **MVC04.PL** as the Startup Project.
  * Press `Ctrl + F5` to run.
  * Register a new user to access the dashboard.

> **⚠️ Admin Notice:** By default, new users have "User" role. To enable "Create/Edit" buttons, you must manually assign the `Admin` role to your user via Database or SQL Script.

-----

## 🤝 Contributing

Contributions are welcome\!

1.  Fork the project.
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`).
3.  Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4.  Push to the Branch (`git push origin feature/AmazingFeature`).
5.  Open a Pull Request.

-----

**Developed with ❤️ by Adham Samaan**

```
