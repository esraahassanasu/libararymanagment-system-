# Library Management System

## Overview

The **Library Management System** is a C# Console Application developed using Object-Oriented Programming (OOP) principles. It allows librarians to manage books, members, and borrowing records through a simple menu-driven interface.

The project demonstrates the use of abstraction, inheritance, polymorphism, interfaces, encapsulation, collections, exception handling, and basic file organization.

---

## Features

* Add new books
* Register regular and premium members
* Borrow books
* Return books
* Search books
* Search members
* View all books
* View all members
* View borrowing history
* Generate late return reports
* Seed sample data for testing

---

## Technologies Used

* C#
* .NET Console Application
* Object-Oriented Programming (OOP)

---

## Project Structure

```
LibraryManagementSystem/
│
├── Models/
│   ├── LibraryItem.cs
│   ├── Book.cs
│   ├── Member.cs
│   ├── PremiumMember.cs
│   └── BorrowRecord.cs
│
├── Interfaces/
│   └── ISearchable.cs
│
├── Services/
│   └── Library.cs
│
├── Program.cs
└── README.md
```

---

## OOP Concepts Implemented

### Abstraction

* `LibraryItem` is implemented as an abstract base class.

### Inheritance

* `Book` inherits from `LibraryItem`.
* `PremiumMember` inherits from `Member`.

### Interface

* `ISearchable` is implemented by searchable classes.

### Polymorphism

* `GetInfo()` is overridden in derived classes.
* `MatchesQuery()` provides different search behavior for each class.

### Encapsulation

* Data and operations are organized inside classes with appropriate properties and methods.

---

## Main Functions

### Book Management

* Add books
* Search books
* View all books

### Member Management

* Register members
* Register premium members
* Search members
* View all members

### Borrowing Management

* Borrow books
* Return books
* View borrowing history
* View late return records

---

## Sample Menu

```
========== Library Management System ==========
1. Add Book
2. Register Member
3. Borrow Book
4. Return Book
5. Search Books
6. Search Members
7. View All Books
8. View All Members
9. Member Borrow History
10. Late Return Report
11. View All Borrow Records
0. Exit
```

---

## How to Run

1. Clone the repository

```bash
git clone https://github.com/your-username/LibraryManagementSystem.git
```

2. Open the project in Visual Studio or Visual Studio Code.

3. Restore packages (if needed):

```bash
dotnet restore
```

4. Run the application:

```bash
dotnet run
```

---

## Sample Data

The project includes sample books and members through the `seed_data()` method to make testing easier.

Example books:

* Sherlock Holmes
* The Great Gatsby

Example members:

* John Doe
* Jane Smith

