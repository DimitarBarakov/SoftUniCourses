--1
CREATE PROC usp_GetEmployeesSalaryAbove3500
AS
BEGIN
	SELECT FirstName,LastName FROM Employees
	WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove3500

--2
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@SalaryParam DECIMAL(18,4) )
AS
BEGIN
	SELECT FirstName,LastName FROM Employees
	WHERE Salary > @SalaryParam
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3
CREATE PROC usp_GetTownsStartingWith (@StartWith NVARCHAR(20))
AS
BEGIN
	SELECT Name FROM Towns
	WHERE Name LIKE @StartWith + '%'
END

EXEC usp_GetTownsStartingWith 'B'

--4
CREATE PROC usp_GetEmployeesFromTown (@TownName NVARCHAR(20))
AS 
BEGIN
	SELECT FirstName, LastName FROM Employees AS E
	JOIN Addresses AS A ON E.AddressID = A.AddressID
	JOIN Towns AS T ON A.TownID = T.TownID
	WHERE T.Name = @TownName
END

EXEC usp_GetEmployeesFromTown 'Sofia'
DROP PROC usp_GetEmployeesFromTown

--5
CREATE FUNCTION udf_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @level NVARCHAR(20) = 'AVERAGE'
	IF(@salary < 30000)
	BEGIN
		SET @level = 'LOW'
	END
	ELSE IF(@salary > 50000)
	BEGIN
		SET @level = 'HIGH'
	END
	RETURN @level
END

SELECT Salary, dbo.udf_GetSalaryLevel(Salary) AS 'SALARY LEVEL' FROM Employees

--6
CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(20))
AS
BEGIN
	SELECT FirstName,LastName FROM Employees
	WHERE dbo.udf_GetSalaryLevel(Salary) = @salaryLevel
END

EXEC usp_EmployeesBySalaryLevel 'HIGH'

--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@HIGHER DECIMAL(18,4))
AS
BEGIN
	SELECT AH.FirstName,SUM(A.Balance) AS BALANCE FROM AccountHolders AS AH
	JOIN Accounts AS A ON AH.Id = A.AccountHolderId
	WHERE BALANCE >= @HIGHER
	GROUP BY AH.FirstName
END

EXEC usp_GetHoldersWithBalanceHigherThan 50000
