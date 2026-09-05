# ITFlow 🖥️

### Enterprise IT Request & Dashboard System

![C#](https://img.shields.io/badge/C%23-ASP.NET-512BD4?style=for-the-badge\&logo=dotnet)
![VB.NET](https://img.shields.io/badge/VB.NET-WinForms-512BD4?style=for-the-badge\&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge\&logo=microsoftsqlserver)
![JavaScript](https://img.shields.io/badge/JavaScript-Frontend-F7DF1E?style=for-the-badge\&logo=javascript)
![HTML5](https://img.shields.io/badge/HTML5-Web-E34F26?style=for-the-badge\&logo=html5)
![CSS3](https://img.shields.io/badge/CSS3-Responsive-1572B6?style=for-the-badge\&logo=css3)

> End-to-end **Enterprise IT Ticketing & Workflow Management System** developed as an internship project for **National Steel Fabrication (NSF – Orascom Construction)**, combining a C# ASP.NET Web API, VB.NET WinForms desktop client, SQL Server database, and responsive web dashboard.

---

# 📌 Project Overview

**ITFlow** is an enterprise IT request and workflow management platform designed to centralize how employees submit, track, and manage internal IT support requests.

The system combines a **desktop application** and **web dashboard** with a centralized **C# ASP.NET Web API** and **SQL Server database**.

The platform supports the complete request lifecycle:

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

The project focuses on:

* 🎫 Centralized IT request management
* 🔄 Structured request workflows
* 👤 Employee and requester management
* 👥 On-behalf-of request submission
* 🧑‍💼 Dynamic manager lookup
* 🕒 Request and audit tracking
* 🖥️ Desktop application support
* 🌐 Web-based request management
* 🔌 REST API architecture
* 🗄️ Relational database management

---

# ✨ Core Features

| Feature                     | Description                                               |
| --------------------------- | --------------------------------------------------------- |
| 🎫 **IT Request Creation**  | Employees can submit IT support requests                  |
| 📊 **Management Dashboard** | Centralized interface for viewing and managing requests   |
| 🔄 **Status Workflow**      | Requests move through Pending, In Progress, and Completed |
| 👤 **Personal Requests**    | Employees can submit requests for themselves              |
| 👥 **On Behalf Of**         | Requests can be created for another employee              |
| 🧑‍💼 **Manager Lookup**    | Dynamically retrieves the appropriate manager             |
| 🕒 **Audit Tracking**       | Stores creator and timestamp information                  |
| 🔢 **Ticket IDs**           | Generates sequential identifiers for requests             |
| 🖥️ **Desktop Client**      | VB.NET WinForms application                               |
| 🌐 **Web Dashboard**        | Responsive HTML/CSS/JavaScript interface                  |
| 🔌 **REST API**             | Centralized ASP.NET API communication                     |
| 🗄️ **SQL Database**        | Structured SQL Server relational storage                  |

---

# 🏗️ System Architecture

ITFlow uses a multi-tier client-server architecture.

Both the desktop application and web dashboard communicate with the same centralized backend.

```text
                ┌──────────────────────┐
                │        ITFlow        │
                │ Enterprise IT System │
                └──────────┬───────────┘
                           │
             ┌─────────────┴─────────────┐
             │                           │
             ▼                           ▼
    ┌─────────────────┐        ┌─────────────────┐
    │ VB.NET WinForms │        │  Web Dashboard  │
    │ Desktop Client  │        │ HTML / CSS / JS │
    └────────┬────────┘        └────────┬────────┘
             │                          │
             └────────────┬─────────────┘
                          │
                          ▼
                 ┌─────────────────┐
                 │ ASP.NET Web API │
                 │       C#        │
                 └────────┬────────┘
                          │
                          ▼
                 ┌─────────────────┐
                 │   SQL Server    │
                 │    Database     │
                 └─────────────────┘
```

This architecture allows multiple interfaces to access the same request data while keeping business logic centralized in the API.

---

# 🔄 Request Workflow

Each IT request follows a structured lifecycle.

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
| 🔵 **In Progress** | IT team is currently handling the request            |
| 🟢 **Completed**   | Request has been resolved                            |

Status transitions are handled through the backend to keep request information synchronized between the desktop and web interfaces.

---

# 👥 Requester System

ITFlow supports multiple request scenarios.

## 👤 Personal Request

Employees can create IT requests for themselves.

```text
Logged-In Employee
        ↓
Create Request
        ↓
Requester = Employee
        ↓
Submit to API
```

---

## 👥 On Behalf Of

The system also supports submitting requests on behalf of another employee.

```text
Logged-In User
       ↓
Select Employee
       ↓
Retrieve Employee Details
       ↓
Dynamic Manager Lookup
       ↓
Create Request
       ↓
Submit to API
```

This allows the system to distinguish between the person **creating the request** and the employee the request is **actually for**.

---

# 🎫 Request Management

The platform manages the complete lifecycle of an IT request.

Each request can contain information related to:

* Requester
* Request creator
* Request details
* Current status
* Creation timestamp
* Manager information
* Ticket identifier
* Audit information

The backend handles the business logic required to create, retrieve, and update requests.

---

# 🔌 ASP.NET Web API

The backend is implemented using **C# and ASP.NET Web API**.

It acts as the communication layer between the user interfaces and SQL Server database.

```text
Desktop / Web Client
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
Desktop / Web Client
```

### Backend Responsibilities

* Create IT requests
* Retrieve request information
* Update request statuses
* Process requester information
* Handle on-behalf-of requests
* Perform manager lookups
* Generate ticket information
* Maintain audit information
* Communicate with SQL Server
* Return structured responses to clients

---

# 🗄️ SQL Server Database

ITFlow uses **Microsoft SQL Server** as its centralized relational database.

The database is responsible for storing and managing information used by the system.

### Database Responsibilities

* Employee information
* IT requests
* Request statuses
* Employee-manager relationships
* Request creator information
* Creation timestamps
* Ticket identifiers
* Relational data integrity

The database design focuses on maintaining structured and consistent enterprise data.

---

# 🔢 Ticket Tracking

Each request receives an identifier that can be used to track it throughout its lifecycle.

```text
New Request
     ↓
Generate Ticket ID
     ↓
Store Request
     ↓
Return Ticket
     ↓
Track Through Workflow
```

This provides a consistent reference for each IT support request.

---

# 🖥️ Desktop Application

The desktop client is built using **VB.NET WinForms**.

It provides a native Windows interface for interacting with the IT request platform.

### Desktop Stack

| Technology       | Usage                       |
| ---------------- | --------------------------- |
| **VB.NET**       | Application logic           |
| **WinForms**     | Desktop UI                  |
| **MaterialSkin** | Modern interface components |
| **RestSharp**    | REST API communication      |

The desktop client communicates with the ASP.NET backend instead of directly managing application data independently.

---

# 🌐 Web Dashboard

The project also includes a responsive browser-based dashboard.

The web interface is built using:

* HTML5
* CSS3
* JavaScript

It provides another way to interact with the centralized IT request system through the API.

### Web Components

```text
WebDashboard/
│
├── dashboard.html
├── employee.html
├── employee.js
├── index.html
├── nsf.png
├── request.html
├── script.js
└── styles.css
```

---

# ⚙️ Tech Stack

| Technology          | Usage                        |
| ------------------- | ---------------------------- |
| **C#**              | Backend development          |
| **ASP.NET Web API** | REST API and business logic  |
| **VB.NET**          | Desktop application          |
| **WinForms**        | Desktop interface            |
| **MaterialSkin**    | Desktop UI design            |
| **RestSharp**       | API communication            |
| **SQL Server**      | Relational database          |
| **JavaScript**      | Web application logic        |
| **HTML5**           | Web interface                |
| **CSS3**            | Responsive styling           |
| **Visual Studio**   | .NET development environment |
| **VS Code**         | Project and web development  |

---

# 📂 Project Structure

```text
Enterprise-IT-Request-Dashboard/
│
├── API/
│   │
│   ├── MartinTest/
│   │   └── ...
│   │
│   └── MartinTest.sln
│
├── Database/
│   └── SQLQuery1.sql
│
├── Desktop/
│   │
│   ├── TEST/
│   │   └── ...
│   │
│   └── TEST.sln
│
├── WebDashboard/
│   │
│   ├── nsf design web/
│   │
│   ├── dashboard.html
│   ├── employee.html
│   ├── employee.js
│   ├── index.html
│   ├── nsf.png
│   ├── request.html
│   ├── script.js
│   └── styles.css
│
├── .gitignore
└── README.md
```

### Components

| Directory       | Purpose                             |
| --------------- | ----------------------------------- |
| `API/`          | C# ASP.NET Web API backend          |
| `Database/`     | SQL Server database scripts         |
| `Desktop/`      | VB.NET WinForms desktop application |
| `WebDashboard/` | HTML/CSS/JavaScript web dashboard   |

> Visual Studio generated directories such as `.vs`, `bin`, `obj`, and NuGet `packages` should be excluded from the repository using `.gitignore`.

---

# 🚀 Getting Started

## 1️⃣ Clone Repository

```bash
git clone https://github.com/yourusername/Enterprise-IT-Request-Dashboard.git
```

Enter the project directory:

```bash
cd Enterprise-IT-Request-Dashboard
```

---

## 2️⃣ Configure Database

The database script is located at:

```text
Database/SQLQuery1.sql
```

Open the script using **SQL Server Management Studio (SSMS)** and execute the required database setup.

Configure your local development connection string to point to your SQL Server instance.

> ⚠️ Do not commit real production credentials or company database connection strings.

---

## 3️⃣ Run ASP.NET API

Open:

```text
API/MartinTest.sln
```

using **Visual Studio**.

Restore required NuGet packages, build the solution, and run the API.

```text
Build → Build Solution
```

Then:

```text
Debug → Start Debugging
```

---

## 4️⃣ Run Desktop Application

Open:

```text
Desktop/TEST.sln
```

in Visual Studio.

Restore the required dependencies and run the WinForms application.

```text
Build → Build Solution
```

Then start the project:

```text
Debug → Start Debugging
```

---

## 5️⃣ Open Web Dashboard

The web interface is located inside:

```text
WebDashboard/
```

Start with:

```text
WebDashboard/index.html
```

The web client should be configured to communicate with the running ASP.NET Web API.

---

# 🔐 Security & Privacy

This project was developed in an enterprise environment.

Before publishing or deploying the repository, sensitive information must be removed.

### ❌ Do Not Commit

* Database passwords
* Production connection strings
* API credentials
* Internal server IP addresses
* Employee personal information
* Private company URLs
* Authentication secrets
* Production database files
* Internal business data

Use placeholder configuration values when publishing examples:

```text
Server=YOUR_SERVER;
Database=YOUR_DATABASE;
User Id=YOUR_USERNAME;
Password=YOUR_PASSWORD;
```

---

# 🧹 Git Ignore

Generated Visual Studio and NuGet files should not be stored in the repository.

Recommended `.gitignore` rules:

```gitignore
# Visual Studio
.vs/
**/.vs/

# Build Output
bin/
obj/
**/bin/
**/obj/

# NuGet
packages/
**/packages/

# Visual Studio User Files
*.user
*.suo
*.userosscache
*.sln.docstates

# Build Configurations
[Dd]ebug/
[Rr]elease/
x64/
x86/

# Logs
*.log

# Operating System
Thumbs.db
Desktop.ini
.DS_Store
```

---

# 📈 System Benefits

| Benefit                       | Description                                           |
| ----------------------------- | ----------------------------------------------------- |
| 🎯 **Centralized Management** | IT requests are managed through one system            |
| ⚡ **Efficiency**              | Reduces manual request handling                       |
| 🔄 **Workflow Control**       | Requests follow a defined lifecycle                   |
| 🔍 **Traceability**           | Request status and creator information can be tracked |
| 👥 **Flexible Submission**    | Supports personal and on-behalf-of requests           |
| 🖥️ **Multi-Interface**       | Desktop and web clients use the same backend          |
| 🔌 **API Architecture**       | Separates clients from backend business logic         |
| 🗄️ **Data Integrity**        | Relational database provides structured data storage  |

---

# 🎯 Real-World Applications

The system architecture can be adapted for:

* Enterprise IT help desks
* Internal support systems
* Employee service portals
* Maintenance request systems
* Facility management
* Technical support workflows
* Internal ticketing platforms
* Service request management

---

# 🔮 Future Improvements

* [ ] User authentication
* [ ] Role-based authorization
* [ ] Email notifications
* [ ] Automatic IT ticket assignment
* [ ] Priority levels
* [ ] SLA tracking
* [ ] Request search and filtering
* [ ] Advanced dashboard analytics
* [ ] File attachments
* [ ] Real-time status notifications
* [ ] Admin management portal
* [ ] Reporting and export functionality
* [ ] Mobile-responsive improvements

---

# 🏢 Internship Project

This system was developed as part of an internship project for:

### National Steel Fabrication (NSF)

**Orascom Construction**

The project provided practical experience with:

* Enterprise software architecture
* Backend API development
* RESTful services
* Desktop application development
* SQL database design
* Frontend web development
* Client-server communication
* Business workflow implementation
* Multi-interface system integration

---

# 📚 Project Type

**Enterprise Software • Full-Stack Development • IT Workflow Management**

> ITFlow demonstrates an end-to-end enterprise architecture combining a **C# ASP.NET Web API**, **VB.NET WinForms desktop client**, **SQL Server database**, and **responsive JavaScript web dashboard** within a centralized IT request management platform.

---

# 👨‍💻 Developer

Developed as an **Enterprise IT Internship Project**.

---

# ⭐ Support

If you found this project useful or interesting, consider giving the repository a **⭐ Star**.

---

<p align="center">
  <b>Built with C# 💜 · ASP.NET ⚙️ · VB.NET 🖥️ · SQL Server 🗄️ · JavaScript 🌐</b>
</p>
