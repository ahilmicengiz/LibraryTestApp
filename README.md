# LibraryTestApp
A library application 
============

This is a C# library application powered by ASP.Net Core MVC and Dapper ORM that provides the main functions you'd expect from a CRUD application, such as adding book,
borrowing and listing books in the library etc.

---

## Technologies
- Dapper for ORM
- Bootstrap
- HTML
- ASP.Net Core MVC
- MSSQLServer
- T-SQL
- JavaScript(a little bit)
- log4net for logging

---

## Features
- Borrowing books
- Taking back books
- Listing books
- Other awesome features yet to be implemented

---

## Setup
Clone this repo to your desktop install all the dependencies.

---

## Dependencies
-XPagedList
-XPagedList.Mvc.Core
-Dapper
-log4net
-Microsoft.Extensions.Logging

---

## Usage
After you clone this repo to your desktop, create a file as "logs" under D: disk or create a path and edit FileValue section of 'log4net.config' file.You can find exception loggings under this path.
Before run the application, execute 'library_db.sql' file to generate scripts of database.
Then edit connection string value of SQLConnection method in Repository/BookRepository.cs with your connection information.
You can find images that you uploaded in 'wwwroot/Image'.

After you finish all, you can 'run' to start the application. You will then be able to access it at localhost:5001



---

Created by https://github.com/ahilmicengiz
