SELECT L.Province, L.Municipality, L.Name AS Location, COUNT(S.Id) AS CountOfSites FROM Locations AS L
JOIN Sites AS S ON S.LocationId = L.Id
WHERE L.Province = 'Sofia'
GROUP BY L.Province, L.Municipality, L.Name
ORDER BY CountOfSites DESC, L.Name