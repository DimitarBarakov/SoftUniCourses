SELECT FirstName, LastName, A.Manufacturer, A.Model, A.FlightHours FROM Pilots AS P
JOIN PilotsAircraft AS PA ON P.Id = PA.PilotId
JOIN Aircraft AS A ON A.Id = PA.AircraftId
WHERE FlightHours < 304
ORDER BY A.FlightHours DESC, P.FirstName 
