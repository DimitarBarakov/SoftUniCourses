--1
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'Sa%'

--2
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName FROM Employees
WHERE DepartmentID IN (3,10)
AND (YEAR(HireDate) >= 1995 AND YEAR(HireDate) <= 2005)

--4
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT Name FROM Towns
WHERE LEN(Name) IN (5,6)
ORDER BY Name

--6
SELECT * FROM Towns
WHERE [Name] LIKE ('M%') or [Name] LIKE ('B%') or [Name] LIKE ('K%') or [Name] LIKE ('E%') 
ORDER BY [Name]

--7
SELECT * FROM Towns
WHERE [Name] NOT LIKE ('R%') AND [Name] NOT LIKE ('B%') AND [Name] NOT LIKE ('D%')
ORDER BY [Name]

--8
SELECT FirstName, LastName FROM Employees
WHERE YEAR(HireDate) > 2000

--9
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

--10
SELECT 
	EmployeeID,
	FirstName,
	LastName,
	Salary, 
	DENSE_RANK() OVER (PARTITION BY SALARY ORDER BY EmployeeID) AS [RANK]  
FROM Employees
WHERE (Salary > 10000 AND Salary < 50000) AND [RANK] = 2
ORDER BY Salary DESC
