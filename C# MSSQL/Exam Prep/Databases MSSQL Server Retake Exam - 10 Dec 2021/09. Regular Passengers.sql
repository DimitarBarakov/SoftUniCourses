SELECT P.FullName, COUNT(A.Id) AS CountOfAircraft, SUM(FD.TicketPrice) AS TotalPayed FROM Passengers AS P 
JOIN FlightDestinations AS FD ON P.Id = FD.PassengerId
JOIN Aircraft AS A ON FD.AirportId = A.Id
WHERE P.FullName LIKE ('_a%')
GROUP BY P.FullName
HAVING COUNT(A.Id) > 1
ORDER BY P.FullName 
