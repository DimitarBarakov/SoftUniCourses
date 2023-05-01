CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @VolunteersCount INT
	SET @VolunteersCount = (
		SELECT COUNT(V.Name) FROM Volunteers AS V
		JOIN VolunteersDepartments AS VD ON V.DepartmentId = VD.Id
		WHERE VD.DepartmentName = @VolunteersDepartment
		GROUP BY VD.DepartmentName
	)
	RETURN @VolunteersCount
END
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')