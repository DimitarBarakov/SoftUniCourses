SELECT TOP 20 FD.Id AS DestinationId,FD.Start, P.FullName, A.AirportName, FD.TicketPrice FROM Passengers AS P
JOIN FlightDestinations AS FD ON P.Id = FD.PassengerId
JOIN Airports AS A ON FD.AirportId = A.Id
WHERE DAY(FD.Start) % 2 = 0 
ORDER BY FD.TicketPrice DESC, A.AirportName

SELECT DAY(FD.Start) FROM FlightDestinations AS FD