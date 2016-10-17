
-- 1
CREATE TABLE Flights(
	FlightID INT PRIMARY KEY,
	DepartureTime DATETIME NOT NULL,
	ArrivalTime DATETIME NOT NULL,
	Status VARCHAR(9),
	OriginAirportID INT,
	DestinationAirportID INT,
	AirlineID INT
	--CONSTRAINT chk_Status CHECK (Status IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
	CONSTRAINT FK_Flights_OAirports FOREIGN KEY(OriginAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_Flights_DAirports FOREIGN KEY(DestinationAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_Flights_AAirports FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets(
	TicketID INT PRIMARY KEY,
	Price DECIMAL(8,2) NOT NULL,
	Class VARCHAR(6),
	Seat VARCHAR(5) NOT NULL,
	CustomerID INT,
	FlightID INT,
	--CONSTRAINT chk_Class CHECK (Class IN ('First', 'Second', 'Third')),
	CONSTRAINT FK_Tickets_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
	CONSTRAINT FK_Tickets_Flights FOREIGN KEY(FlightID) REFERENCES Flights(FlightID)
)

ALTER TABLE dbo.Flights ADD CONSTRAINT CK_Flights_Status
    CHECK ([Status] IN ('Departing', 'Delayed', 'Arrived', 'Cancelled'))

	
ALTER TABLE dbo.Tickets ADD CONSTRAINT CK_Tickets_Class
    CHECK (Class IN ('First', 'Second', 'Third'))



-- 2.1

INSERT INTO Flights(FlightID, DepartureTime, ArrivalTime, [Status], OriginAirportID, DestinationAirportID, AirlineID)
VALUES
(1,	'2016-10-13 06:00 AM',	'2016-10-13 10:00 AM',	'Delayed',1   ,4 , 1  ),
(2,	'2016-10-12 12:00 PM',	'2016-10-12 12:01 PM',	'Departing',1	,3	,2	),
(3,	'2016-10-14 03:00 PM',	'2016-10-20 04:00 AM',	'Delayed', 4	,2	,4  ),
(4,	'2016-10-12 01:24 PM',	'2016-10-12 4:31 PM' ,  'Departing',3	,1	,3	),
(5,	'2016-10-12 08:11 AM',	'2016-10-12 11:22 PM',	'Departing',4	,1	,1	),
(6,	'1995-06-21 12:30 PM',	'1995-06-22 08:30 PM',	'Arrived', 2	,3	,5  ),
(7,	'2016-10-12 11:34 PM',	'2016-10-13 03:00 AM',	'Departing',2	,4	,2  ),
(8,	'2016-11-11 01:00 PM',	'2016-11-12 10:00 PM',	'Delayed', 4	,3	,1	),
(9,	'2015-10-01 12:00 PM',	'2015-12-01 01:00 AM',	'Arrived', 1	,2  ,1  ),
(10,'2016-10-12 07:30 PM',	'2016-10-13 12:30 PM',	'Departing',2	,1	,7	)

INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID)
VALUES
(1,	3000.00, 'First', '233-A' ,3, 8),
(2,	1799.90,'Second', '123-D' ,1, 1),
(3,	1200.50,'Second', '12-Z' ,2, 5),
(4,	410.68,  'Third', '45-Q' ,2, 8),
(5,	560.00,  'Third', '201-R' ,4, 6),
(6,	2100.00,'Second', '13-T' ,1, 9),
(7,	5500.00, 'First', '98-O' ,2, 7)



-- 2 . 2

UPDATE Flights
SET AirlineID = 1
WHERE [Status] LIKE 'Arrived'



-- 2 . 3
--Highest rated

UPDATE Tickets 
SET Price *=1.5
WHERE TicketID IN  (
			SELECT t.TicketID FROM Tickets as t
			JOIN Flights fl
			ON t.FlightID = fl.FlightID
			JOIN Airlines al
			ON fl.AirlineID = al.AirlineID
			AND al.Rating = (SELECT MAX(air.Rating) FROM Airlines as air)
			)




-- 2.4

CREATE TABLE CustomerReviews(
	ReviewID INT PRIMARY KEY,
	ReviewContent VARCHAR(255) NOT NULL,
	ReviewGrade INT,
	AirlineID INT,
	CustomerID INT,
	CONSTRAINT FK_CustomerReviews_Airlines FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID),
	CONSTRAINT FK_CustomerReviews_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
)

CREATE TABLE CustomerBankAccounts(
	AccountID INT PRIMARY KEY,
	AccountNumber VARCHAR(10) NOT NULL UNIQUE,
	Balance DECIMAL(10,2) NOT NULL,
	CustomerID INT
	CONSTRAINT FK_CustomerBankAccount_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
	
)

ALTER TABLE dbo.CustomerReviews ADD CONSTRAINT CK_CustomerReviews_Rev
    CHECK (ReviewGrade BETWEEN 0 AND 10)



-- 2 . 5

INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
VALUES
(1,	'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
(2,	'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
(3,	'Meh...', 5, 4, 3),
(4,	'Well I''ve seen better, but I''ve certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts(AccountID, AccountNumber, Balance, CustomerID)
VALUES
(1, '123456790',  2569.23,     1),
(2, '18ABC23672', 14004568.23, 2),
(3, 'F0RG0100N3', 19345.20,    5)




-- 3.1 -- DONE

SELECT
	t.TicketID,
	t.Price,
	t.Class,
	t.Seat
FROM Tickets as t
ORDER BY t.TicketID ASC




-- 3.2 -- DONE

SELECT
	c.CustomerID,
	CONCAT(c.FirstName, ' ', c.LastName) as FullName,
	c.Gender

FROM Customers as c
ORDER BY FullName ASC, c.CustomerID ASC




-- 3.3 --Done
SELECT
	f.FlightID,
	f.DepartureTime,
	f.ArrivalTime
FROM Flights as f
WHERE f.Status = 'Delayed'
ORDER BY f.FlightID ASC





-- 3.4-- Done
SELECT TOP 5
	a.AirlineID,
	a.AirlineName,
	a.Nationality,
	a.Rating
FROM Airlines as a
ORDER BY a.Rating DESC, a.AirlineID





--3.5 -- Done

SELECT
	t.TicketID,
	air.AirportName as Destination,
	CONCAT(c.FirstName,' ', c.LastName) as CustomerName
FROM Tickets AS t
JOIN Flights as f
ON t.FlightID = f.FlightID
JOIN Airports as air
ON air.AirportID = f.DestinationAirportID
JOIN Customers as c
ON c.CustomerID = t.CustomerID
WHERE t.Price < 5000 AND t.Class = 'First'
ORDER BY t.TicketID ASC




--3.6 -- DONE

SELECT
	c.CustomerID,
	CONCAT(c.FirstName, ' ', c.LastName) as FullName,
	t.TownName as HomeTown	 
FROM Customers as c
JOIN Tickets as tic
ON tic.CustomerID = c.CustomerID
JOIN Flights as fl
ON tic.FlightID = fl.FlightID AND fl.[Status] LIKE 'Departing'
JOIN Towns as t
ON fl.OriginAirportID = t.TownID
WHERE t.TownID = c.HomeTownID
ORDER BY c.CustomerID ASC




--3.7 -- DONE
SELECT DISTINCT
	c.CustomerID,
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	DATEDIFF(YEAR,c.DateOfBirth, GETDATE()) AS Age
	FROM Customers AS c
	JOIN Tickets AS t
	ON c.CustomerID = t.CustomerID
	JOIN Flights AS fl
	ON t.FlightID = fl.FlightID
	WHERE t.CustomerID IS NOT NULL
		  AND fl.Status = 'Departing'



--3.8

SELECT TOP 3
	c.CustomerID,
	CONCAT(c.FirstName, ' ', LastName) AS FullName,
	t.Price as TicketPrice,
	airp.AirportName as Destination
FROM Customers as c
JOIN Tickets as t
ON t.CustomerID = c.CustomerID
JOIN Flights as fl
ON fl.FlightID = t.FlightID
JOIN Airports as airp
ON airp.AirportID = fl.DestinationAirportID
WHERE fl.Status = 'Delayed'
ORDER BY t.Price DESC, CustomerID ASC 

--3.9 -- DONE
SELECT TOP 5
	f.FlightID,
	f.DepartureTime,
	f.ArrivalTime,
	airo.AirportName as Origin,
	aird.AirportName as Destination
FROM Flights as f
JOIN Airports as aird
ON f.DestinationAirportID = aird.AirportID
JOIN Airports as airo
ON f.OriginAirportID = airo.AirportID
WHERE f.Status = 'Departing'
ORDER BY f.DepartureTime ASC, f.FlightID ASC

--3.10 -- DONE
SELECT c.CustomerID,
CONCAT(c.FirstName,' ',c.LastName) AS FullName,
DATEDIFF(YEAR,c.DateOfBirth, GETDATE()) AS Age
FROM Customers as c
JOIN Tickets as t
ON t.CustomerID = c.CustomerID 
JOIN Flights fl
ON t.FlightID = fl.FlightID AND fl.[Status] = 'Arrived'
WHERE DATEDIFF(YEAR, c.DateOfBirth, GETDATE()) < 21
ORDER BY Age DESC, c.CustomerID ASC
 
--3.11 -- DONE
WITH [Data] AS
(SELECT air.AirportID,
 air.AirportName,
	(SELECT COUNT(1) AS 'Count' FROM Customers c
	 INNER JOIN Tickets as t
	    ON c.CustomerID = t.CustomerID 
		AND t.FlightID = f.FlightID) AS 'Passengers'
	  FROM Airports as air
	 INNER JOIN Flights f
	    ON air.AirportID = f.OriginAirportID 
		AND f.[Status] = 'Departing'
	)
SELECT * 
FROM [Data] as s 
WHERE s.[Passengers] > 0
ORDER BY s.AirportID ASC

--4.0
--4.1

CREATE PROCEDURE usp_SubmitReview @CustomerID INT, @ReviewContent VARCHAR(100), @ReviewGrade INT, @AirlineName VARCHAR(100)
AS
BEGIN
	DECLARE @Airline INT = (select 1 from Airlines as a
							where a.AirlineName = @AirlineName)
	DECLARE @Id INT = (SELECT TOP 1 ReviewID FROM CustomerReviews ORDER BY ReviewID DESC)
	IF @Airline IS NULL
	BEGIN
		RAISERROR('Airline does not exist.',16,1)
	END
	INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
							VALUES( @Id, @ReviewContent, @ReviewGrade, @Airline, @CustomerID)
END
GO

usp_SubmitReview 5,'seen better,',6,'nqmatakava'


--4.2

CREATE PROCEDURE usp_PurchaseTicket @CustomerID INT, @FlightID INT, @TicketPrice DECIMAL(8,2), @Class VARCHAR(6), @Seat VARCHAR(5)
AS
BEGIN
	IF((SELECT Balance FROM CustomerBankAccounts WHERE CustomerID = @CustomerID) > @TicketPrice)
	BEGIN
		INSERT INTO Tickets (CustomerID, FlightID, Price, Class, Seat)
		VALUES (@CustomerID, @FlightID, @TicketPrice, @Class, @Seat)
		UPDATE CustomerBankAccounts
		SET Balance = @TicketPrice
		WHERE CustomerID = @CustomerID
	END
	ELSE
	BEGIN
		RAISERROR('Insufficient bank account balance for ticket purchase.',16,1)
	END
END