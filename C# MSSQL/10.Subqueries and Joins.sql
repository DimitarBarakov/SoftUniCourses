--1
SELECT TOP 5 e.EmployeeID, e.JobTitle,a.AddressID,a.AddressText  FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY A.AddressID

--2
SELECT TOP 50 e.FirstName, e.LastName, T.[Name], a.AddressText  FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY E.FirstName, E.LastName

--3
SELECT TOP 50 e.EmployeeID, e.FirstName, e.LastName, d.[Name]  FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

--4
SELECT TOP 50 e.EmployeeID, e.FirstName, e.Salary, d.[Name]  FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE E.Salary > 15000
ORDER BY D.DepartmentID

--5
SELECT e.EmployeeID, e.FirstName, EP.ProjectID FROM Employees AS e
JOIN EmployeesProjects AS ep ON E.EmployeeID = EP.EmployeeID

--6
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '1999-01-01'
AND d.[Name]  = 'Sales' OR d.[Name]  =  'Finance'
ORDER BY E.HireDate

--7
SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name FROM Employees AS e
JOIN EmployeesProjects AS ep ON E.EmployeeID = EP.EmployeeID
JOIN Projects AS p ON P.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13'
AND p.EndDate IS NULL
ORDER BY E.EmployeeID

--8
