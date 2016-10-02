------------------------------------------------------
-- SoftUni Databases Basics MySQL - Basic CRUD      --
-- Solutions for all exercises                      --
-- https://judge.softuni.bg/Contests/289/Basic-CRUD --
------------------------------------------------------

--PART I: SoftUni Database Queries
USE SoftUni;

--Problem 2. Find All Information About All Departments
SELECT * FROM Departments;

--Problem 3. Find All Information About All Departments
SELECT Name FROM Departments;

--Problem 4. Find salary of Each Employee
SELECT FirstName, LastName, Salary 
FROM Employees;

--Problem 5. Find Full Name of Each Employee
SELECT FirstName, MiddleName, LastName
FROM Employees;

--Problem 6. Find Email Address of Each Employee
SELECT CONCAT(e.FirstName, '.', e.LastName, '@softuni.bg')
FROM [dbo].[Employees] AS e

--Problem 7. Find All Different Employee's Salaries
SELECT DISTINCT e.Salary
FROM [dbo].[Employees] AS e

--Problem 8. Find All Information About employees
SELECT * FROM [dbo].[Employees]
	WHERE JobTitle = 'Sales Representative'

--Problem 9. Find Names of All employees by salary in Range
SELECT e.FirstName, e.LastName, e.JobTitle 
FROM [dbo].[Employees] AS e
	WHERE Salary BETWEEN 20000 AND 30000

--Problem 10. Find Names of All employees
SELECT e.FirstName+ ' '+e.MiddleName+ ' '+ e.LastName AS 'Full Name'
FROM [dbo].[Employees] AS e
WHERE salary = 25000 OR salary = 14000 OR salary = 12500 OR salary = 23600;

--Problem 11. Find All employees Without Manager
SELECT FirstName, LastName FROM Employees
WHERE ManagerId IS NULL;

--Problem 12. Find All employees with salary More Than 50000
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary>50000
ORDER BY Salary DESC

--Problem 13. Find 5 Best Paid employees
SELECT TOP 5 FirstName, LastName
FROM Employees
ORDER BY Salary DESC

--Problem 14. Find All employees Except Marketing
SELECT FirstName, LastName
FROM Employees
WHERE DepartmentId != 4

--Problem 15. Sort employees Table
SELECT * FROM Employees
ORDER BY Salary DESC,
		 FirstName ASC,
		 LastName DESC,
		 MiddleName ASC
		 
--Problem 16. Create View employees with Salaries
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees

SELECT * FROM V_EmployeesSalaries;

--Problem 17. Create View employees with Job Titles
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT 
CONCAT(FirstName, ' ', (case when MiddleName IS NULL THEN '' ELSE MiddleName END), ' ', LastName) AS "Full Name",
JobTitle
FROM Employees;


--Problem 18. Distinct Job Titles
SELECT DISTINCT JobTitle FROM Employees;

--Problem 19. Find First 10 Started Projects
SELECT TOP 10 * FROM Projects
ORDER BY StartDate ASC, Name ASC

--Problem 20. Last 7 Hired employees
SELECT TOP 7 FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC

--Problem 21. Increase Salaries
UPDATE Employees
SET Salary = Salary + Salary * 0.12
WHERE DepartmentId IN (1, 2, 4, 11);

SELECT Salary FROM Employees;


--Part II: Geography Database Queries
USE Geography;

--Problem 22. All Mountain peaks
SELECT PeakName 
FROM [dbo].[Peaks]
ORDER BY PeakName

--Problem 23. Biggest Countries by population
SELECT TOP 30 CountryName, Population
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC, CountryName

--Problem 24. countries and Currency (Euro / Not Euro)
SELECT CountryName, CountryCode,
	(CASE WHEN CurrencyCode='EUR' THEN 'Euro' ELSE 'Not Euro' END) AS Currency
FROM Countries
ORDER BY CountryName
--PART II: Diablo Database Queries
USE Diablo;

--Problem 25. All Diablo characters
SELECT Name
FROM Characters
ORDER BY Name;
