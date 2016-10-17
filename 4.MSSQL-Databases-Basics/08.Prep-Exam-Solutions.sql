--Solutions
----Section 1. DDL

CREATE TABLE DepositTypes(
DepositTypeID INT,
DepositName VARCHAR(50) NOT NULL,
CONSTRAINT PK_DepositTypes PRIMARY KEY(DepositTypeID)
)

CREATE TABLE Deposits(
DepositID INT IDENTITY,
Amount DECIMAL(8,2),
StartDate DATE,
EndDate DATE,
DepositTypeID INT,
CustomerID INT,
CONSTRAINT PK_Deposit PRIMARY KEY(DepositID),
CONSTRAINT FK_Deposits_DepositTypes FOREIGN KEY(DepositTypeID) REFERENCES DepositTypes(DepositTypeID),
CONSTRAINT FK_Deposits_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE EmployeesDeposits(
EmployeeID INT,
DepositID INT,
CONSTRAINT PK_EmployeesDeposits PRIMARY KEY(EmployeeID, DepositID),
CONSTRAINT FK_EmployeesDeposits_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EmployeesDeposits_DepositID FOREIGN KEY(DepositID) REFERENCES Deposits(DepositID)
)

CREATE TABLE CreditHistory(
CreditHistoryID	INT,
Mark CHAR(1),
StartDate DATE,
EndDate DATE,
CustomerID INT,
CONSTRAINT PK_CreditHistory PRIMARY KEY(CreditHistoryID),
CONSTRAINT FK_CreditHistory_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE Payments(
PaymentID INT,
PaymentDate DATE,
Amount DECIMAL(8,2),
LoanID INT,
CONSTRAINT PK_Payments PRIMARY KEY(PaymentID),
CONSTRAINT FK_Payments_Loans FOREIGN KEY(LoanID) REFERENCES Loans(LoanID)
)

CREATE TABLE Users(
UserID INT,
UserName VARCHAR(30),
Password VARCHAR(50),
CustomerID INT UNIQUE,
CONSTRAINT PK_Users PRIMARY KEY(UserID),
CONSTRAINT FK_Payments_Users FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

ALTER TABLE Employees
ADD ManagerID INT NULL

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Employees FOREIGN KEY(ManagerID) REFERENCES Employees(EmployeeID)

--Judge Tests
--Tables
SELECT COUNT(*)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME IN ('Users', 'Payments', 'EmployeesDeposits', 'Deposits','DepositTypes', 'CreditHistory')

--PK
SELECT ku.TABLE_NAME, COUNT(*) AS PKCount
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
INNER JOIN
INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU
ON TC.CONSTRAINT_TYPE = 'PRIMARY KEY' AND
TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
and ku.TABLE_NAME IN ('Users', 'Payments', 'EmployeesDeposits', 'Deposits','DepositTypes', 'CreditHistory')
GROUP BY ku.TABLE_NAME
ORDER BY ku.TABLE_NAME

--FK
SELECT ku.TABLE_NAME, ku.COLUMN_NAME, COUNT(*) AS FKCount
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
INNER JOIN
INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU
ON TC.CONSTRAINT_TYPE = 'FOREIGN KEY' AND
TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
and ku.TABLE_NAME IN ('Users', 'Payments', 'EmployeesDeposits', 'Deposits','DepositTypes', 'CreditHistory')
GROUP BY ku.TABLE_NAME, ku.COLUMN_NAME
ORDER BY ku.TABLE_NAME, ku.COLUMN_NAME

--Self-join
SELECT COUNT(*)
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
INNER JOIN
INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU
ON TC.CONSTRAINT_TYPE = 'FOREIGN KEY' AND
TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
and ku.TABLE_NAME = 'Employees'
and ku.COLUMN_NAME = 'ManagerID'

--Data Types
SELECT DATA_TYPE, COUNT(*)
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME IN ('Users', 'Payments', 'EmployeesDeposits', 'Deposits','DepositTypes', 'CreditHistory')
GROUP BY DATA_TYPE




----Section 2. DML
--1. Inserts
INSERT INTO DepositTypes(DepositTypeID, DepositName)
VALUES
(1, 'Time Deposit'),
(2, 'Call Deposit'),
(3,	'Free Deposit')


INSERT INTO Deposits(Amount, StartDate, EndDate, DepositTypeID, CustomerID)
SELECT CASE WHEN DateOfBirth >= '19800101' THEN 1000 ELSE 1500 END
	   +
	   CASE WHEN Gender = 'M' THEN 100 ELSE 200 END AS Amount
	  ,GETDATE() AS StartDate
	  ,NULL AS EndDate
	  ,CASE 
			WHEN CustomerID > 15 THEN 3 ELSE
				CASE
					WHEN CustomerID % 2 = 1 THEN 1
					WHEN CustomerID % 1 = 0 THEN 2
				END
	   END
      ,[CustomerID] 
  FROM [Bank].[dbo].[Customers]
 WHERE CustomerID < 20

 INSERT INTO EmployeesDeposits(EmployeeID, DepositID)
VALUES
(15,4),
(20,15),
(8,7),
(4,8),
(3,13),
(3,8),
(4,10),
(10,1),
(13,4),
(14,9)


--Update
UPDATE Employees
SET ManagerID = CASE
					WHEN EmployeeID BETWEEN 2 AND 10 THEN 1
					WHEN EmployeeID BETWEEN 12 AND 20 THEN 11
					WHEN EmployeeID BETWEEN 22 AND 30 THEN 21
					WHEN EmployeeID IN (11,21) THEN 1
					END
--Delete
DELETE FROM EmployeesDeposits
 WHERE EmployeeID = 3
    OR DepositID = 9

----Section 3. Querying 
--1. Employees Salary
SELECT [EmployeeID]
      ,[HireDate]
      ,[Salary]
      ,[BranchID]
  FROM [Bank].[dbo].[Employees]
 WHERE [Salary] > 2000
   AND [HireDate] > '20090615'

--2. Customer Age
SELECT [FirstName]
      ,[DateOfBirth]
	  ,DATEDIFF(YYYY,[DateOfBirth], '20161001') AS Age
  FROM [Bank].[dbo].[Customers]
 WHERE DATEDIFF(YYYY,[DateOfBirth], '20161001') BETWEEN 40 AND 50

--3. Customer City
SELECT [CustomerID]
      ,[FirstName]
      ,[LastName]
      ,[Gender]
      ,[CityName]
  FROM [Bank].[dbo].[Customers] AS cu
 INNER JOIN [Bank].[dbo].[Cities] AS ci
    ON cu.[CityID] = ci.[CityID]
 WHERE ([LastName] LIKE 'Bu%'
    OR RIGHT([FirstName],1) = 'a')
   AND LEN([CityName]) > 7
 ORDER BY [CustomerID] ASC

--4. Employee Accounts
SELECT TOP 5
       e.[EmployeeID]
      ,e.[FirstName]
      ,a.[AccountNumber]
  FROM [Bank].[dbo].[Employees] AS e
 INNER JOIN [Bank].[dbo].[EmployeesAccounts] AS ea
    ON e.EmployeeID = ea.EmployeeID
 INNER JOIN [Bank].[dbo].[Accounts] AS a
    ON a.AccountID = ea.AccountID
 WHERE a.StartDate > '20121231'
 ORDER BY e.[FirstName] DESC
 
--5. Count Cities
SELECT c.[CityName]
      ,b.[Name]
	  ,COUNT(*) AS EmployeesCount
  FROM [Bank].[dbo].[Employees] AS e
 INNER JOIN [Bank].[dbo].[Branches] AS b
    ON b.BranchID = e.BranchID
 INNER JOIN [Bank].[dbo].[Cities] AS c
    ON c.CityID = b.CityID
 WHERE c.CityID NOT IN (4,5)
 GROUP BY c.[CityName]
         ,b.[Name]
HAVING COUNT(*) > 2

--6. Loan Statistics
SELECT SUM(l.[Amount]) AS TotalAmounts
      ,MAX(l.[Interest]) AS MaxInterest
	  ,MIN(e.[Salary]) AS MinSalary
  FROM [Bank].[dbo].[Employees] AS e
 INNER JOIN [Bank].[dbo].[EmployeesLoans] AS el
    ON e.EmployeeID = el.EmployeeID
 INNER JOIN [Bank].[dbo].[Loans] AS l
    ON l.LoanID = el.LoanID

--7. Union People
SELECT TOP 3
       e.FirstName
      ,c.CityName
  FROM [Bank].[dbo].[Employees] AS e
 INNER JOIN [Bank].[dbo].[Branches] AS b
    ON b.BranchID = e.BranchID
 INNER JOIN [Bank].[dbo].[Cities] AS c
    ON c.CityID = b.CityID
 UNION ALL
SELECT TOP 3
	   cu.FirstName
      ,ci.CityName
  FROM [Bank].[dbo].[Customers] AS cu
 INNER JOIN [Bank].[dbo].[Cities] AS ci
    ON cu.CityID = ci.CityID

--8. Customers without Accounts
SELECT c.CustomerID
      ,c.Height
  FROM [Bank].[dbo].[Customers] AS c
  LEFT OUTER JOIN [Bank].[dbo].[Accounts] AS a
    ON a.CustomerID = c.CustomerID
 WHERE a.AccountID IS NULL
   AND c.Height BETWEEN 1.75 AND 2.04

--9. Customers Average Loans
SELECT TOP 5
       c.CustomerID
	  ,l.Amount
  FROM [Bank].[dbo].[Customers] AS c
 INNER JOIN [Bank].[dbo].[Loans] AS l
    ON l.CustomerID = c.CustomerID
 WHERE L.Amount > (SELECT AVG(Amount) 
					 FROM [Bank].[dbo].[Customers] AS c
			   INNER JOIN [Bank].[dbo].[Loans] AS l
					   ON l.CustomerID = c.CustomerID
				    WHERE c.Gender = 'M')
 ORDER BY LastName ASC

--10. Person with oldest accounts
SELECT c.CustomerID
	  ,c.FirstName
	  ,a.StartDate
  FROM [Bank].[dbo].[Customers] AS c
 INNER JOIN [Bank].[dbo].[Accounts] AS a
    ON a.CustomerID = c.CustomerID
 INNER JOIN (
 SELECT MIN(a.StartDate) AS MinStartDate
  FROM [Bank].[dbo].[Customers] AS c
 INNER JOIN [Bank].[dbo].[Accounts] AS a
    ON a.CustomerID = c.CustomerID) AS m
    ON m.MinStartDate = a.StartDate

----Section 4. Programmability
--1 Function concatanates two string
CREATE FUNCTION udf_ConcatString (@StringOne VARCHAR(50), @StringTwo VARCHAR(50))
RETURNS VARCHAR(100)
AS
BEGIN
	RETURN Concat(REVERSE(@StringOne), REVERSE(@StringTwo));
END

SELECT dbo.udf_ConcatString('Soft','Uni')

--2. Inexpired Loans
CREATE PROCEDURE usp_CustomersWithUnexpiredLoans @CustomerID INT
AS
BEGIN
SELECT c.CustomerID
      ,c.FirstName
	  ,l.LoanID
  FROM [Bank].[dbo].[Customers] AS c
 INNER JOIN [Bank].[dbo].[Loans] AS l
    ON l.CustomerID = c.CustomerID
 WHERE l.ExpirationDate IS NULL
   AND c.CustomerID = @CustomerID
END

EXEC usp_CustomersWithUnexpiredLoans @CustomerID = 9

--3 Procedure Take Loan
CREATE PROCEDURE usp_TakeLoan @CustomerID INT, @LoanAmount DECIMAL(10,2), @Interest DECIMAL(4,2), @StartDate DATE
AS
BEGIN
DECLARE @CustomersCount INT;
	BEGIN TRAN
		INSERT INTO [Bank].[dbo].[Loans](Amount, Interest, StartDate, CustomerID)
		VALUES(@LoanAmount, @Interest, @StartDate, @CustomerID)
		IF @LoanAmount NOT BETWEEN 0.01 AND 100000
		BEGIN
			ROLLBACK
			RAISERROR('Invalid Loan Amount.',16,1)
			RETURN
		END
		COMMIT
END

EXEC usp_TakeLoan @CustomerID = 1, @LoanAmount = 500, @Interest = 1, @StartDate='20160915'
 


--4 Trigger New Employee
CREATE TRIGGER tr_NewEmployees ON Employees
AFTER INSERT
AS
BEGIN
    DECLARE @EmployeeID INT
	DECLARE CR CURSOR FOR SELECT inserted.EmployeeID FROM inserted
	OPEN CR
	FETCH NEXT FROM CR INTO @EmployeeID
    WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE EmployeesLoans
		SET EmployeeID = @EmployeeID
		WHERE EmployeeID = @EmployeeID-1
		FETCH NEXT FROM CR INTO @EmployeeID
		END
    CLOSE CR
    DEALLOCATE CR
END

INSERT INTO Employees VALUES (31, 'A', '20161212', 500, 2)

----Section 5. Bonus
--Trigger Log Accounts
CREATE TABLE [dbo].[AccountLogs](
	[AccountID] [int] NOT NULL,
	[AccountNumber] [char](12) NOT NULL,
	[StartDate] [date] NOT NULL,
	[CustomerID] [int] NOT NULL)

CREATE TRIGGER tr_DeleteAccounts ON [dbo].[Accounts]
INSTEAD OF DELETE
AS
BEGIN
	INSERT INTO [dbo].[AccountLogs]([AccountID], [AccountNumber], [StartDate], [CustomerID])
	SELECT [AccountID], [AccountNumber], [StartDate], [CustomerID]
	FROM deleted
	DELETE FROM EmployeesAccounts
	WHERE AccountID IN (SELECT [AccountID] FROM deleted)
	DELETE FROM Accounts
	WHERE AccountID IN (SELECT [AccountID] FROM deleted)
END 

DELETE FROM [dbo].[Accounts] WHERE AccountID = 4