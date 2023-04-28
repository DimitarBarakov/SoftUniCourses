--1
SELECT COUNT(*) AS Count FROM WizzardDeposits 

--2
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits 

--3
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
GROUP BY DepositGroup

--4
SELECT TOP 2 DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) 

--5
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
GROUP BY DepositGroup

--6
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--7
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--13
SELECT DepartmentID, SUM(Salary) FROM Employees
GROUP BY DepartmentID

--14
SELECT DepartmentID, MIN(Salary) FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

--15
SELECT DepartmentID, MAX(Salary) FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

--16
SELECT COUNT(Salary) FROM Employees
WHERE ManagerID IS NULL