SELECT AP.AirportName ,FD.Start, FD.TicketPrice, P.FullName, A.Manufacturer, A.Model FROM FlightDestinations AS FD 
JOIN Aircraft AS A ON A.Id = FD.AircraftId
JOIN Passengers AS P ON P.Id = FD.PassengerId
JOIN Airports AS AP ON AP.Id = FD.AirportId
WHERE (DATEPART(HOUR,FD.Start) >= 6 AND DATEPART(HOUR,FD.Start) <= 20) AND FD.TicketPrice > 2500
ORDER BY A.Model
