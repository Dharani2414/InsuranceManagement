# 🛡️ Insurance Management System - C# Coding Challenge

## 📌 Overview

The **Insurance Management System** is a **console-based application** built using **C# (.NET Core)**.  
It showcases a **hybrid data-access strategy** using:

- **ADO.NET** for **User-related operations**
- **Entity Framework Core (EF Core)** for **Policy creation**
- **ADO.NET** for **Policy viewing and assignments**

This approach provides both low-level control and high-level ORM benefits within a modular design.

---

## ✅ Features

### 👤 User Module (ADO.NET)
- User Registration  
- User Login  
- View All Users  

### 📄 Policy Module (Hybrid)
- Create Policy (**EF Core**)  
- View Policies (**ADO.NET**)  
- Assign Policy to User  
- Filter/Sort Policies  

---

## 🗂️ Project Structure 

InsuranceManagement/
│
├── DAO/                    # ADO.NET and EF Core Repositories
├── Entity/                 # Entity Framework Core models (Policy, PolicyType, etc.)
├── InsuranceManagement/    # Main console application logic
├── MyExceptions/           # Custom exception classes
├── Util/                   # Utility and config classes (e.g., DB connection)
├── packages/               # NuGet packages folder (auto-managed)
└── InsuranceManagement.sln # Visual Studio solution file
