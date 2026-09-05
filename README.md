# ITFlow 🖥️

### Enterprise IT Request & Dashboard System

![C#](https://img.shields.io/badge/C%23-ASP.NET-512BD4?style=for-the-badge\&logo=dotnet)
![VB.NET](https://img.shields.io/badge/VB.NET-WinForms-512BD4?style=for-the-badge\&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge\&logo=microsoftsqlserver)
![JavaScript](https://img.shields.io/badge/JavaScript-Frontend-F7DF1E?style=for-the-badge\&logo=javascript)
![HTML5](https://img.shields.io/badge/HTML5-Web-E34F26?style=for-the-badge\&logo=html5)
![CSS3](https://img.shields.io/badge/CSS3-Responsive-1572B6?style=for-the-badge\&logo=css3)

> An end-to-end **Enterprise IT Ticketing & Workflow Management System** built during an internship project for **National Steel Fabrication (NSF – Orascom Construction)**, featuring a C# REST API, SQL Server database, VB.NET desktop application, and responsive web dashboard.

---

# 📌 Project Overview

**ITFlow** is an enterprise IT request and workflow management platform designed to simplify how employees submit, track, manage, and resolve internal IT requests.

The system provides both **desktop and web interfaces**, connected to a centralized **ASP.NET Web API** and **SQL Server database**.

The platform supports the complete IT request lifecycle:

```text
Employee Request
       ↓
Request Submission
       ↓
ASP.NET Web API
       ↓
SQL Server Database
       ↓
IT Dashboard
       ↓
Pending
       ↓
In Progress
       ↓
Completed
```

The project was developed with a focus on **enterprise workflow automation, centralized request management, data integrity, and usability**.

---

# ✨ Core Features

* 🎫 Create and manage IT support requests
* 📊 Centralized IT management dashboard
* 🔄 Request status workflow
* 👤 Personal request submissions
* 👥 Submit requests on behalf of another employee
* 🧑‍💼 Dynamic manager lookup
* 🕒 Request timestamp tracking
* 🔍 Request history and audit information
* 🖥️ VB.NET WinForms desktop interface
* 🌐 Responsive web dashboard
* 🔌 REST API communication
* 🗄️ Centralized SQL Server database
* 🔢 Sequential ticket ID generation
* 📱 Responsive web interface

---

# 🏗️ System Architecture

ITFlow follows a multi-tier architecture where desktop and web clients communicate with a centralized API.

```text
              ┌─────────────────────────┐
              │       ITFlow System     │
              └────────────┬────────────┘
                           │
              ┌────────────┴────────────┐
              │                         │
              ▼                         ▼
    ┌──────────────────┐      ┌──────────────────┐
    │ VB.NET WinForms  │      │  Web Dashboard   │
    │ Desktop Client   │      │ HTML / CSS / JS  │
    └────────┬─────────┘      └────────┬─────────┘
             │                         │
             └────────────┬────────────┘
                          │
                          ▼
                ┌───────────────────┐
                │ ASP.NET Web API   │
                │        C#         │
                └─────────┬─────────┘
                          │
                          ▼
                ┌───────────────────┐
                │    SQL Server     │
                │     Database      │
                └───────────────────┘
```

---

# 🔄 Request Workflow

Every IT request moves through a structured workflow.

```text
┌─────────────┐
│   Pending   │
└──────┬──────┘
       │
       ▼
┌─────────────┐
│ In Progress │
└──────┬──────┘
       │
       ▼
┌─────────────┐
│  Completed  │
└─────────────┘
```

| Status             | Description                                          |
| ------------------ | ---------------------------------------------------- |
| 🟡 **Pending**     | Request has been submitted and is waiting for action |
| 🔵 **In Progress** | IT team is currently working on the request          |
| 🟢 **Completed**   | Request has been successfully resolved               |

Status changes are handled through the centralized backend to keep request information synchronized across the system.

---

# 🎫 IT Request Management

The platform allows employees to create IT requests containing the information required by the IT team.

The backend manages:

* Request creation
* Request routing
* Request status
* Request ownership
* Creation timestamps
* `Created_By` audit information
* Ticket identification
* Request history

This provides a centralized workflow instead of relying on manually managed requests.

---

# 👥 Requester Logic

ITFlow supports two request scenarios.

### 👤 Personal Request

An employee can submit an IT request directly for themselves.

```text
Logged-In Employee
        ↓
Create Request
        ↓
Requester = Employee
```

### 👥 On Behalf Of

Users can also create a request on behalf of another employee.

```text
Logged-In User
       ↓
Select Employee
       ↓
Employee Information
       ↓
Dynamic Manager Lookup
       ↓
Submit Request
```

This allows IT requests to accurately represent both the **request creator** and the **actual requester**.

---

# 🔌 REST API

The system uses a **C# ASP.NET Web API** as the communication layer between the user interfaces and database.

```text
Client
   ↓
HTTP Request
   ↓
ASP.NET Web API
   ↓
Business Logic
   ↓
SQL Server
   ↓
JSON Response
   ↓
Client
```

The API is responsible for:

* Request creation
* Request retrieval
* Status transitions
* Request routing
* Employee/requester logic
* Manager lookups
* Database communication
* Audit information

---

# 🗄️ Database Design

The backend uses **Microsoft SQL Server** with a normalized relational structure.

The database handles:

* Employee information
* IT requests
* Request statuses
* Request relationships
* Manager relationships
* Audit information
* Creation timestamps
* Sequential ticket IDs

The database design focuses on **data consistency, relational integrity, and reliable transaction processing**.

---

# 🔢 Ticket ID Generation

Each IT request receives a sequential identifier that can be used throughout the system for tracking.

```text
Request Submitted
       ↓
Generate Ticket ID
       ↓
Store Request
       ↓
Return Ticket Information
```

This provides each request with a consistent reference throughout its lifecycle.

---

# 🖥️ Desktop Application

The desktop client was developed using **VB.NET WinForms**.

### Desktop Technologies

| Technology   | Usage                       |
| ------------ | --------------------------- |
| VB.NET       | Desktop application logic   |
| WinForms     | Desktop UI framework        |
| MaterialSkin | Modern interface components |
| RestSharp    | REST API communication      |

The desktop application communicates with the same centralized backend used by the web dashboard.

---

# 🌐 Web Dashboard

The responsive web dashboard provides another interface for interacting with the IT request system.

Built using:

* HTML5
* CSS3
* JavaScript
* REST API integration

The dashboard provides access to request information and workflow management without requiring the desktop application.

---

# ⚙️ Tech Stack

| Technology          | Usage                 |
| ------------------- | --------------------- |
| **C#**              | Backend development   |
| **ASP.NET Web API** | REST API              |
| **VB.NET**          | Desktop client        |
| **WinForms**        | Desktop interface     |
| **MaterialSkin**    | Desktop UI components |
| **RestSharp**       | API communication     |
| **SQL Server**      | Relational database   |
| **JavaScript**      | Web dashboard logic   |
| **HTML5**           | Web interface         |
| **CSS3**            | Responsive styling    |

---

# 📂 Project Structure

```bash
ITFlow/

├── API/
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   └── Web.config
│
├── Desktop/
│   ├── Forms/
│   ├── Models/
│   └── Services/
│
├── WebDashboard/
│   ├── index.html
│   ├── css/
│   ├── js/
│   └── assets/
│
├── Database/
│   └── schema.sql
│
├── README.md
└── .gitignore
```

> The exact folder structure may differ depending on the development environment and deployment configuration.

---

# 🚀 Getting Started

## 1️⃣ Clone Repository

```bash
git clone https://github.com/yourusername/ITFlow.git
cd ITFlow
```

---

## 2️⃣ Configure SQL Server

Create the required SQL Server database and configure the application's database connection.

> ⚠️ Never commit production database credentials or private connection strings to GitHub.

---

## 3️⃣ Configure ASP.NET Web API

Update your local development configuration with the appropriate SQL Server connection.

Then open the API project in **Visual Studio** and run it.

---

## 4️⃣ Run Desktop Client

Open the VB.NET WinForms project in Visual Studio.

Build and run the application:

```text
Build → Build Solution
Debug → Start Debugging
```

The desktop application communicates with the ASP.NET API using **RestSharp**.

---

## 5️⃣ Open Web Dashboard

Start the web dashboard and configure its API endpoint to point to the running ASP.NET backend.

```text
Web Dashboard
      ↓
ASP.NET Web API
      ↓
SQL Server
```

---

# 🔐 Security & Data Handling

Because this project was developed in an enterprise environment, sensitive information should **not** be included in the public repository.

Before publishing, remove or replace:

* Database passwords
* Production connection strings
* Internal server addresses
* Employee personal information
* Internal company credentials
* API secrets
* Confidential business data

Example configuration values should use placeholders instead:

```text
Server=YOUR_SERVER;
Database=YOUR_DATABASE;
User Id=YOUR_USERNAME;
Password=YOUR_PASSWORD;
```

---

# 📈 System Benefits

ITFlow provides several advantages for enterprise IT operations:

| Benefit            | Description                                       |
| ------------------ | ------------------------------------------------- |
| 🎯 Centralization  | IT requests are managed through one system        |
| ⚡ Efficiency       | Reduces manual request handling                   |
| 🔍 Traceability    | Requests include status and audit information     |
| 🔄 Workflow        | Requests follow a structured lifecycle            |
| 👥 Flexibility     | Supports personal and on-behalf-of requests       |
| 🖥️ Multi-Platform | Desktop and web interfaces share one backend      |
| 🗄️ Data Integrity | SQL Server provides structured relational storage |

---

# 🔮 Future Improvements

* [ ] Role-based authentication & authorization
* [ ] Email notifications
* [ ] Automatic ticket assignment
* [ ] Priority-based request handling
* [ ] SLA tracking
* [ ] Advanced dashboard analytics
* [ ] Request search and filtering
* [ ] File attachments
* [ ] Real-time status notifications
* [ ] Admin management portal
* [ ] Mobile-friendly interface
* [ ] Reporting and export functionality

---

# 🏢 Internship Project

This project was developed as part of an internship project for:

**National Steel Fabrication (NSF) – Orascom Construction**

The project demonstrates practical experience in:

* Enterprise software development
* REST API architecture
* Desktop application development
* Relational database design
* Frontend development
* Client-server communication
* Business workflow implementation

---

# 📚 Project Type

**Enterprise Software • Full-Stack Development • IT Workflow Management**

> Built as an end-to-end enterprise system combining a **C# ASP.NET REST API**, **VB.NET desktop application**, **SQL Server database**, and **responsive web dashboard**.

---

# ⭐ Support

If you found this project useful or interesting, consider giving the repository a **⭐ Star**.

---

<p align="center">
  <b>Built with C# 💜 · ASP.NET ⚙️ · SQL Server 🗄️ · VB.NET 🖥️</b>
</p>
