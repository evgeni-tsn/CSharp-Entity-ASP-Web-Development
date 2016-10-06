-------------------------------------------------------
--SoftUni Databases Basics MSSQL - Built-in Functions--
--Solutions for all exercises                        --
-------------------------------------------------------

--PART I: SoftUni Database Queries
USE SoftUni;

--Problem 1. Find Names of All employees by First name
SELECT [FirstName], [LastName]
FROM Employees
WHERE FirstName LIKE 'SA%'

--Problem 2. Find Names of All employees by Last name
SELECT [FirstName], [LastName]
FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 3. Find First Names of All Employess
SELECT [FirstName]
FROM Employees
WHERE (DepartmentId = 3 OR DepartmentId = 10) 
	AND (YEAR(HireDate) BETWEEN 1995 AND 2005);

--Problem 4. Find All employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

--Problem 5. Find towns with name Length
SELECT Name
FROM Towns
WHERE Name LIKE '_____' OR name LIKE '______'
ORDER BY Name;

--Problem 6. Find towns Starting With
SELECT * FROM Towns
WHERE 
	name LIKE 'M%' OR 
	name LIKE 'K%' OR 
	name LIKE 'B%' OR 
	name LIKE 'E%'
ORDER BY Name ASC;

--Problem 7. Find towns Not Starting With
SELECT * FROM Towns
WHERE 
	Name NOT LIKE 'R%' AND 
	Name NOT LIKE 'B%' AND 
	Name NOT LIKE 'D%'
ORDER BY Name ASC;


--Problem 8. Create View employees Hired After 2000
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE YEAR(HireDate) > 2000;

-- DO NOT SUBMIT THIS LINE V
SELECT * FROM V_EmployeesHiredAfter2000

--Problem 9. Length of Last name
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5;


--PART II: Geography Database Queries
USE Geography;

-- Problem 10. countries Holding 'A' 3 or More Times
SELECT 
  CountryName AS "Country Name", IsoCode AS "ISO Code"
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode;

-- Problem 11. Mix of Peak and River Names
SELECT 
  p.PeakName, 
  r.RiverName, 
  LOWER(
	CONCAT(
		p.PeakName, SUBSTRING(
			r.RiverName, 2, LEN(r.RiverName)))) AS mix
FROM Peaks AS p, Rivers AS r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY mix;


--PART III: Diablo Database Queries
USE Diablo;

--Problem 12. Games From 2001 and 2012 Year
SELECT TOP 50 G.Name AS "Game", CONVERT(VARCHAR(10), G.Start, 126) as "Start" 
FROM Games AS G
WHERE G.Start BETWEEN '20110101' AND '20121231'
ORDER BY G.Start, G.Name

--Problem 13. User Email Providers
SELECT
	Username, 
	SUBSTRING(email, CHARINDEX('@', email) + 1, LEN(email) - CHARINDEX('@', email)) AS "Email Provider" 
FROM users
ORDER BY 2 ASC, Username;

--Problem 14. Get Users with IPAddress Like Pattern
SELECT Username, IpAddress AS "IP Address" FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username;

--Problem 15. Show All Games with Duration and Part of the Day
SELECT G.Name AS "Game", 
CASE 
	WHEN DATEPART(hh, G.Start) >= 0 AND DATEPART(hh, G.Start) < 12 THEN 'Morning'
	WHEN DATEPART(hh, G.Start) >= 12 AND DATEPART(hh, G.Start) < 18 THEN 'Afternoon'
	WHEN DATEPART(hh, G.Start) >= 18 AND DATEPART(hh, G.Start) < 24 THEN 'Evening'
END AS "Part of the Day",
CASE
	WHEN G.Duration <= 3 THEN 'Extra Short'
	WHEN G.Duration >= 4 AND G.Duration <= 6 THEN 'Short'
	WHEN G.Duration > 6 THEN 'Long'
	WHEN G.Duration IS NULL THEN 'Extra Long'
END AS "Duration"
FROM [dbo].Games AS G
ORDER BY G.Name ASC, [Duration] ASC, [Part of the Day] ASC


--Problem 16. orders table
SELECT O.ProductName, O.OrderDate,
DATEADD(DAY, 3, O.OrderDate) AS "Pay Due",
DATEADD(MONTH, 1, O.OrderDate) AS "Delivery Due"
FROM [dbo].Orders AS O
