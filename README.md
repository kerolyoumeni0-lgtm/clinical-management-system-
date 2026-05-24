SMILE CLINIC MANAGEMENT SYSTEM
A lightweight desktop application for managing clinic operations.
Includes secure login, user registration, and full management of doctors, patients, prescriptions, and receptionist tasks.

-Features
User Authentication (Login & Registration)
Doctor Management (Add, Update, Delete, Clear, View)
Patient Management (Add, Update, Delete, Clear, View)
Prescription Creation and Viewing
Receptionist Panel for managing appointments and patient flow
ecure Logout
Role‑based access for Admin, Doctor, and Receptionist

-Technologies
Programming Language: C#
GUI Framework: WinForms
Database: SQL Server (.mdf)
Data Access: ADO.NET

-Setup
Clone or download the project.
Ensure the included .mdf database file is attached in Visual Studio.
Update the database connection string in App.config if needed.
Build and run the application starting from the login screen.

-Project Structure
Code
/SmileClinic
  DASHBOARD.cs
  LOGIN.cs
  USERREGISTRATION.cs
  doctor.cs
  patient.cs
  prescription.cs
  receptionist.cs
  Database1.mdf
  Database1DataSet.xsd
  Program.cs
  App.config
Role Permissions
-All roles have full CRUD functionality:
Receptionist: Add, update, delete, clear patient records and manage appointments
Doctor: Add, update, delete, clear prescriptions and view patient details
Admin: Full access to all modules (users, doctors, patients, prescriptions)

Author
Youmeni  
Aspiring Software Tester & Developer
