--Problem 1. Records’ Count
SELECT COUNT(*) FROM WizzardDeposits

--Problem 2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand 
FROM WizzardDeposits

--Problem 3. Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
  FROM WizzardDeposits AS w
 GROUP BY DepositGroup

--Problem 4. Smallest Deposit Group per Magic Wand Size
 SELECT DepositGroup, AVG(MagicWandSize) AS AverageMagicWandSize
  INTO WizzardDepositsAverageSize
  FROM WizzardDeposits
 GROUP BY DepositGroup

 SELECT wdas.DepositGroup 
   FROM WizzardDepositsAverageSize AS wdas
  WHERE wdas.AverageMagicWandSize =
		(SELECT MIN(AverageMagicWandSize)
		FROM WizzardDepositsAverageSize AS wdas)

 DROP TABLE WizzardDepositsAverageSize

 --Problem 5. Deposits Sum
 SELECT w.DepositGroup, SUM(DepositAmount) AS TotalDepositAmount 
   FROM WizzardDeposits AS w
  GROUP BY w.DepositGroup

 --Problem 6. Deposits Sum for Ollivander Family
   SELECT w.DepositGroup, SUM(DepositAmount) AS TotalDepositAmount 
   FROM WizzardDeposits AS w
   WHERE w.MagicWandCreator = 'Ollivander family'
  GROUP BY w.DepositGroup

 --Problem 7. Deposits Filter
 SELECT w.DepositGroup, SUM(DepositAmount) AS TotalDepositAmount 
   FROM WizzardDeposits AS w
   WHERE w.MagicWandCreator = 'Ollivander family'
  GROUP BY w.DepositGroup
  HAVING SUM(DepositAmount) < 150000
  ORDER BY TotalDepositAmount DESC

 --Problem 8. Deposit Charge
  SELECT w.DepositGroup, w.MagicWandCreator, MIN(w.DepositCharge) AS MinDepositCharge 
   FROM WizzardDeposits AS w
  GROUP BY w.DepositGroup, w.MagicWandCreator
  ORDER BY w.MagicWandCreator ASC, w.DepositGroup ASC

--Problem 9. Age Groups
  SELECT CASE
			WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN w.Age >= 61 THEN '[61+]'
		END AS 'SizeGroup'
		,COUNT(*) as WizzardsCount
  FROM WizzardDeposits AS w
 GROUP BY
		CASE
			WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN w.Age >= 61 THEN '[61+]'
		END

--Problem 10. Magic Size Groups
SELECT SUBSTRING(w.FirstName,1,1) AS FirstLetter
  FROM WizzardDeposits AS w
 WHERE DepositGroup = 'Troll Chest'
 GROUP BY SUBSTRING(w.FirstName,1,1)
ORDER BY FirstLetter ASC
  
--Problem 11. Average Interest 1
SELECT w.DepositGroup, IsDepositExpired, AVG(w.DepositInterest) AS AverageInterest
  FROM WizzardDeposits AS w
 WHERE w.DepositStartDate > '19850101'
 GROUP BY w.DepositGroup, IsDepositExpired
 ORDER BY w.DepositGroup DESC, w.IsDepositExpired ASC

--Problem 12. Rich Wizard, Poor Wizard
SELECT w.FirstName AS HostWizard
	  ,w.DepositAmount AS HostDeposit
	  ,LEAD(w.FirstName) OVER (ORDER BY w.ID) AS GuestWizard
	  ,LEAD(w.DepositAmount) OVER (ORDER BY w.ID) AS GuestDeposit
  INTO RichWizardPoorWizard
  FROM WizzardDeposits AS w

SELECT SUM(r.HostDeposit-r.GuestDeposit) AS SumDifference FROM RichWizardPoorWizard AS r

  DROP TABLE RichWizardPoorWizard

--Problem 13. Employees Minimum Salaries
SELECT [DepartmentID]
      ,MIN(Salary) AS MinSalary
  FROM [SoftUni].[dbo].[Employees] AS e
 WHERE e.DepartmentID IN (2,5,7)
   AND e.HireDate > '20000101'
 GROUP BY [DepartmentID]

--Problem 14. Employees Average Salaries
SELECT * INTO NewEmployees
FROM Employees AS e
WHERE e.Salary > 30000

DELETE FROM NewEmployees 
 WHERE ManagerID = 42

UPDATE NewEmployees
   SET Salary = Salary + 5000
 WHERE DepartmentID = 1

SELECT [DepartmentID]
      ,AVG(Salary) AS AverageSalary
  FROM NewEmployees AS e
 GROUP BY [DepartmentID]

DROP TABLE NewEmployees

--Problem 15. Employees Maximum Salaries
SELECT DepartmentID
      ,MAX(Salary) AS MaxSalary
  FROM Employees AS e
 GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 16. Employees Count Salaries
SELECT COUNT(*) AS EmployeeCount
  FROM Employees AS e
 WHERE e.ManagerID IS NULL

--Problem 17. 3rd Highest Salary
SELECT DISTINCT
	   DepartmentID
	  ,Salary
      ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
  INTO SalaryRanks
  FROM [SoftUni].[dbo].[Employees] AS e

  SELECT DepartmentID, Salary FROM SalaryRanks AS s
   WHERE s.SalaryRank = 3

  DROP TABLE SalaryRanks

--Problem 18. Salary Challenge
SELECT TOP 10 e.FirstName ,e.LastName ,e.DepartmentID
  FROM Employees AS e
  INNER JOIN (SELECT DepartmentID ,AVG(Salary) AS AverageSalary
			   FROM Employees
			   GROUP BY DepartmentID) AS d
	ON d.DepartmentID = e.DepartmentID
 WHERE e.Salary > d.AverageSalary
 ORDER BY e.DepartmentID