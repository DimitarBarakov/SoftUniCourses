SELECT V.Name, V.PhoneNumber, TRIM(SUBSTRING(TRIM(V.Address), 8, LEN(TRIM(V.Address))-7)) AS Address FROM Volunteers AS V
JOIN VolunteersDepartments AS D ON V.DepartmentId = D.Id
WHERE LEFT(TRIM(Address),5) = 'Sofia' AND D.DepartmentName = 'Education program assistant'
ORDER BY V.Name