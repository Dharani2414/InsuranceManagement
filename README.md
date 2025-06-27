# 🛡️ Insurance Management System - C# Coding Challenge

## 📌 Overview

The **Insurance Management System** is a console-based application developed in **C# (.NET Core)**. It showcases a hybrid data-access strategy using:

- **ADO.NET** for **User-related operations**
- **Entity Framework Core (EF Core)** and **ADO.NET** for **Policy-related operations**

This solution demonstrates a modular structure and combines raw SQL access with modern ORM approaches.

---

## 🗂️ Project Structure

```plaintext
InsuranceManagement/
│
├── DAO/                # Data access layer using ADO.NET and EF Core
│
├── Entity/             # EF Core entity classes (e.g., Policy, PolicyType)
│
├── InsuranceManagement/ # Main application logic (Program.cs, Menu, Services)
│
├── MyExceptions/       # Custom exception handling
│
├── Util/               # Utility classes (e.g., DB connection, config reader)
│
├── packages/           # NuGet packages (auto-managed)
│
└── InsuranceManagement.sln  # Visual Studio solution file
---
## ✅ Features

### 👤 User Module (ADO.NET)
- User Registration  
- User Login  
- View All Users  

### 📄 Policy Module (Hybrid)
- Create Policy (EF Core)  
- View Policies (ADO.NET)  
- Assign Policy to User  
- Filter/Sort Policies 
