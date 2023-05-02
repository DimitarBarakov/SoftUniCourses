CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @flightsCount INT
	SET @flightsCount = (
		SELECT COUNT(FD.PassengerId) FROM Passengers AS P
		LEFT JOIN FlightDestinations AS FD ON P.Id = FD.PassengerId
		WHERE P.Email = @email
		GROUP BY P.FullName)
	RETURN @flightsCount
END

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')