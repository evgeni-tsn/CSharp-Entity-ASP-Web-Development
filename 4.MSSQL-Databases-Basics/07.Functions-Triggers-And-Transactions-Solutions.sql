--PART I: SoftUni Database Queries
USE SoftUni
GO

--Problem 1. Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary > 35000

--Problem 2. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @number MONEY
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary >= @number

--Problem 3. Towns Starting With
CREATE PROCEDURE usp_GetTownsStartingWith @prefix VARCHAR(MAX)
AS
SELECT [Name] FROM Towns
WHERE Name LIKE CONCAT(@prefix, '%')

--Problem 4. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
	SELECT FirstName, LastName FROM Employees
	JOIN Addresses ON Employees.AddressID = Addresses.AddressID
	JOIN Towns ON Addresses.TownID = Towns.TownID
	WHERE Towns.Name = @townName

--Problem 5. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary INT)
RETURNS NVARCHAR(10)
AS
BEGIN
DECLARE @salaryLevel VARCHAR(10);
	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low';
	END;
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
	BEGIN
		SET @salaryLevel = 'Average';
	END;
	ELSE
	BEGIN
		SET @salaryLevel = 'High';
	END;
	RETURN @salaryLevel;
END;

--Problem 7. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT 
AS
BEGIN
	DECLARE @lettersSet AS VARCHAR(50)
	DECLARE @givenWord AS VARCHAR(50)
	DECLARE @result BIT

	SET @lettersSet = @setOfLetters
	SET @givenWord = @word
	SET @result = 1

	DECLARE @cnt INT = 0;
	WHILE @cnt < LEN(@givenWord)
	BEGIN
		DECLARE @innerCnt INT = 0;
		DECLARE @letterFound BIT = 0
		WHILE @innerCnt < LEN(@lettersSet)
		BEGIN
			IF SUBSTRING(@lettersSet, @innerCnt + 1, 1) = SUBSTRING(@givenWord, @cnt + 1, 1)
			BEGIN
				SET @letterFound = 1;
			END
			SET @innerCnt += 1
		END
		IF @letterFound = 0
		BEGIN
			SET @result = 0
		END
		SET @cnt += 1;
	END
	RETURN @result
END

--PART II: Bank Database Queries
DROP DATABASE Bank
GO
CREATE DATABASE Bank
GO
USE Bank
GO
CREATE TABLE AccountHolders
(
Id INT NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
SSN CHAR(10) NOT NULL
CONSTRAINT PK_AccountHolders PRIMARY KEY (Id)
)

CREATE TABLE Accounts
(
Id INT NOT NULL,
AccountHolderId INT NOT NULL,
Balance MONEY DEFAULT 0
CONSTRAINT PK_Accounts PRIMARY KEY (Id)
CONSTRAINT FK_Accounts_AccountHolders FOREIGN KEY (AccountHolderId) REFERENCES AccountHolders(Id)
)

INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (1, 'Susan', 'Cane', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (2, 'Kim', 'Novac', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (3, 'Jimmy', 'Henderson', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (4, 'Steve', 'Stevenson', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (5, 'Bjorn', 'Sweden', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (6, 'Kiril', 'Petrov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (7, 'Petar', 'Kirilov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (8, 'Michka', 'Tsekova', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (9, 'Zlatina', 'Pateva', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (10, 'Monika', 'Miteva', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (11, 'Zlatko', 'Zlatyov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (12, 'Petko', 'Petkov Junior', '1234567890');

INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (1, 1, 123.12);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (2, 3, 4354.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (3, 12, 6546543.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (4, 9, 15345.64);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (5, 11, 36521.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (6, 8, 5436.34);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (7, 10, 565649.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (8, 11, 999453.50);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (9, 1, 5349758.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (10, 2, 543.30);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (11, 3, 10.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (12, 7, 245656.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (13, 5, 5435.32);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (14, 4, 1.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (15, 6, 0.19);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (16, 2, 5345.34);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (17, 11, 76653.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (18, 1, 235469.89);

--Problem 9. Find Full Name
CREATE PROCEDURE usp_GetHoldersFullName 
AS
	SELECT FirstName + ' ' + LastName FROM AccountHolders

--Problem 10. People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @balance MONEY
AS
	SELECT FirstName, LastName FROM AccountHolders
	JOIN Accounts ON Accounts.AccountHolderId = AccountHolders.Id
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @balance

--Problem 11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@sum MONEY, @rate FLOAT, @years FLOAT)
RETURNS MONEY
AS
BEGIN
	DECLARE @fv MONEY = @sum * POWER((1 + @rate), @years)
	RETURN @fv
END

--Problem 13. Deposit Money Procedure
CREATE PROCEDURE usp_DepositMoney @account INT, @moneyAmount MONEY
AS
BEGIN
	BEGIN TRANSACTION;
	
	UPDATE Accounts SET Balance = Balance + @moneyAmount
	WHERE Id = @account;
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK;
		RAISERROR('Invalid account!', 16, 1);
		RETURN;
	END;  

	COMMIT;
END

--Problem 14. Withdraw Money Procedures
CREATE PROCEDURE usp_WithdrawMoney @account INT, @moneyAmount MONEY
AS
BEGIN
	BEGIN TRANSACTION;
	
	UPDATE Accounts SET Balance = Balance - @moneyAmount
	WHERE Id = @account;
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK;
		RAISERROR('Invalid account!', 16, 1);
		RETURN;
	END;  

	COMMIT;
END

--Problem 18. Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(max))
RETURNS TABLE
AS RETURN
WITH prices AS (
	SELECT Cash, (ROW_NUMBER() OVER(ORDER BY ug.Cash desc)) as RowNum from UsersGames ug
	join Games g on ug.GameId = g.Id
	WHERE g.Name = @gameName
)
select SUM(Cash) [SumCash] FROM prices WHERE RowNum % 2 = 1

--Problem 20. Massive Shopping
SET XACT_ABORT ON 
BEGIN TRANSACTION [Tran1]

BEGIN TRY
	UPDATE 
		UsersGames 
	SET 
		Cash = Cash - (
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12
		) 
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id FROM Items WHERE MinLevel BETWEEN 11 AND 12

COMMIT TRANSACTION [Tran1]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
END CATCH 

BEGIN TRANSACTION [Tran2]

BEGIN TRY
	UPDATE 
		UsersGames 
	SET 
		Cash = Cash - (
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21
		) 
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id FROM Items WHERE MinLevel BETWEEN 19 AND 21

COMMIT TRANSACTION [Tran2]
END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran2]
END CATCH

SELECT Items.Name [Item Name] 
FROM Items 
INNER JOIN UserGameItems ON Items.Id = UserGameItems.ItemId 
WHERE UserGameId = 110 
ORDER BY [Item Name]

--Problem 21. Number of Users for Email Provider
SELECT 
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider],
	COUNT(Username) [Number Of Users]
FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email))
ORDER BY COUNT(Username) DESC, [Email Provider]

--Problem 22. All Users in Games
SELECT 
	g.Name as Game, 
	gt.Name as [Game Type], 
	u.Username, 
	ug.Level, 
	ug.Cash, 
	c.Name as Character FROM Games g
		JOIN GameTypes gt on gt.Id = g.GameTypeId
		JOIN UsersGames ug on ug.GameId = g.Id
		JOIN Users u on ug.UserId = u.Id
		JOIN Characters c on c.Id = ug.CharacterId
	ORDER BY 
	Level DESC, 
	Username, 
	Game

--Problem 23. Users in Games with Their Items
SELECT 
	u.Username, 
	g.Name AS Game, 
	COUNT(i.Id) AS [Items Count], 
	SUM(i.Price) AS [Items Price] 
FROM Users u
	JOIN UsersGames ug 
		ON ug.UserId = u.Id
	JOIN Games g 
		ON ug.GameId = g.Id
	JOIN Characters c 
		ON ug.CharacterId = c.Id
	JOIN UserGameItems ugi 
		ON ugi.UserGameId = ug.Id
	JOIN Items i 
		ON i.Id = ugi.ItemId
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY 
	[Items Count] DESC, 
	[Items Price] DESC, 
	Username

--Problem 24. * User in Games with Their Statistics
SELECT 
	u.Username, 
	g.Name AS Game, 
	MAX(c.Name) Character,
	SUM(its.Strength) + MAX(gts.Strength) + MAX(cs.Strength) AS Strength,
	SUM(its.Defence) + MAX(gts.Defence) + MAX(cs.Defence) AS Defence,
	SUM(its.Speed) + MAX(gts.Speed) + MAX(cs.Speed) AS Speed,
	SUM(its.Mind) + MAX(gts.Mind) + MAX(cs.Mind) AS Mind,
	SUM(its.Luck) + MAX(gts.Luck) + MAX(cs.Luck) AS Luck
FROM Users u
	JOIN UsersGames ug ON ug.UserId = u.Id
	JOIN Games g ON ug.GameId = g.Id
	JOIN GameTypes gt ON gt.Id = g.GameTypeId
	JOIN [Statistics] gts ON gts.Id = gt.BonusStatsId
	JOIN Characters c ON ug.CharacterId = c.Id
	JOIN [Statistics] cs ON cs.Id = c.StatisticId
	JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
	JOIN Items i ON i.Id = ugi.ItemId
	JOIN [Statistics] its ON its.Id = i.StatisticId
GROUP BY 
	u.Username, 
	g.Name
ORDER BY 
	Strength DESC, 
	Defence DESC, 
	Speed DESC, 
	Mind DESC, 
	Luck DESC

--Problem 25. All Items with Greater than Average Statistics
SELECT 
	i.Name, 
	i.Price, 
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck,
	s.Mind
FROM Items i
JOIN [Statistics] s ON s.Id = i.StatisticId
WHERE s.Mind > (
	SELECT AVG(s.Mind) FROM Items i 
	JOIN [Statistics] s ON s.Id = i.StatisticId
) AND s.Luck > (
	SELECT AVG(s.Luck) FROM Items i 
	JOIN [Statistics] s ON s.Id = i.StatisticId
) AND s.Speed > (
	SELECT AVG(s.Speed) FROM Items i 
	JOIN [Statistics] s ON s.Id = i.StatisticId
) 
ORDER BY i.Name

--Problem 26. Display All Items with information about Forbidden Game Type
SELECT 
	i.Name AS Item, 
	Price, 
	MinLevel, 
	gt.Name AS [Forbidden Game Type] FROM Items i
LEFT JOIN GameTypeForbiddenItems gtf ON gtf.ItemId = i.Id
LEFT JOIN GameTypes gt ON gt.Id = gtf.GameTypeId
ORDER BY [Forbidden Game Type] DESC, Item 

--Problem 27. Buy Items for User in Game
INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES 
	(
		(SELECT Id FROM Items WHERE Name = 'Blackguard'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Blackguard')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
VALUES 
	(
		(SELECT Id FROM Items WHERE Name = 'Bottomless PotiON of AmplificatiON'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Bottomless PotiON of AmplificatiON')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
VALUES (
		(SELECT Id FROM Items WHERE Name = 'Eye of Etlich (Diablo III)'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Eye of Etlich (Diablo III)')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
VALUES (
		(SELECT Id FROM Items WHERE Name = 'Gem of Efficacious Toxin'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Gem of Efficacious Toxin')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
VALUES (
		(SELECT Id FROM Items WHERE Name = 'Golden Gorget of Leoric'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Golden Gorget of Leoric')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

	
insert into UserGameItems(ItemId, UserGameId)
VALUES (
		(SELECT Id FROM Items WHERE Name = 'Hellfire Amulet'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Hellfire Amulet')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

SELECT u.Username, g.Name, ug.Cash, i.Name [Item Name] FROM UsersGames ug
JOIN Games g ON ug.GameId = g.Id
JOIN Users u ON ug.UserId = u.Id
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
WHERE g.Name = 'Edinburgh'
order by i.Name

--PART IV – Queries for Geography Database
USE [Geography]
GO
--Problem 28. Peaks and Mountains
SELECT 
  PeakName, MountainRange as Mountain, Elevation
FROM 
  Peaks p 
  JOIN Mountains m ON p.MountainId = m.Id
ORDER BY Elevation DESC, PeakName

--Problem 29. Peaks with Their Mountain, Country and Continent
SELECT 
  PeakName, MountainRange as Mountain, c.CountryName, cn.ContinentName
FROM 
  Peaks p
  JOIN Mountains m ON p.MountainId = m.Id
  JOIN MountainsCountries mc ON m.Id = mc.MountainId
  JOIN Countries c ON c.CountryCode = mc.CountryCode
  JOIN Continents cn ON cn.ContinentCode = c.ContinentCode
ORDER BY PeakName, CountryName

--Problem 30. Rivers by Country
SELECT
  c.CountryName, ct.ContinentName,
  COUNT(r.RiverName) AS RiversCount,
  ISNULL(SUM(r.Length), 0) AS TotalLength
FROM
  Countries c
  LEFT JOIN Continents ct ON ct.ContinentCode = c.ContinentCode
  LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY c.CountryName, ct.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, CountryName

--Problem 31. Count of Countries by Currency
SELECT
  cur.CurrencyCode,
  MIN(cur.Description) AS Currency,
  COUNT(c.CountryName) AS NumberOfCountries
FROM
  Currencies cur
  LEFT JOIN Countries c ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode
ORDER BY NumberOfCountries DESC, Currency ASC

--Problem 32. Population and Area by Continent
SELECT
  ct.ContinentName,
  SUM(CONVERT(numeric, c.AreaInSqKm)) AS CountriesArea,
  SUM(CONVERT(numeric, c.Population)) AS CountriesPopulation
FROM
  Countries c
  LEFT JOIN Continents ct ON ct.ContinentCode = c.ContinentCode
GROUP BY ct.ContinentName
ORDER BY CountriesPopulation DESC

--Problem 33. Monasteries by Country
CREATE TABLE Monasteries(
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(50),
  CountryCode CHAR(2),
  IsDeleted BIT NOT NULL
DEFAULT 0
  CONSTRAINT FK_Monasteries_Countries FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')


UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (
	SELECT c.CountryCode
	FROM Countries c
	  JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	  JOIN Rivers r ON r.Id = cr.RiverId
	GROUP BY c.CountryCode
	HAVING COUNT(r.Id) > 3
)

SELECT 
  m.Name AS Monastery, c.CountryName AS Country
FROM 
  Countries c
  JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name

--Problem 34. Monasteries by Continents and Countries
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Maynmar'))

SELECT ct.ContinentName, c.CountryName, COUNT(m.Id) AS MonasteriesCount
FROM Continents ct
  LEFT JOIN Countries c ON ct.ContinentCode = c.ContinentCode
  LEFT JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY ct.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName