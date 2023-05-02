CREATE PROC usp_SearchByAirportName (@airportName VARCHAR(70))
AS
BEGIN
SELECT A.AirportName, P.FullName,
CASE 
	WHEN FD.TicketPrice <= 400 THEN 'Low'
	WHEN FD.TicketPrice > 1500 THEN 'High'
	ELSE 'Medium'
END
AS PRICE,
AC.Manufacturer, AC.Condition, ATT.TypeName FROM Airports AS A
JOIN FlightDestinations AS FD ON A.Id = FD.AirportId
JOIN Passengers AS P ON FD.PassengerId = P.Id
JOIN Aircraft AS AC ON AC.Id = FD.AircraftId
JOIN AircraftTypes AS ATT ON ATT.Id = AC.TypeId 
WHERE A.AirportName = @airportName
ORDER BY AC.Manufacturer, P.FullName
END 
DROP PROC usp_SearchByAirportName
EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'