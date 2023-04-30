SELECT S.Name, L.Name, S.Establishment, C.Name FROM Sites AS S 
JOIN Categories AS C ON C.Id = S.CategoryId
JOIN Locations AS L ON L.Id = S.LocationId
ORDER BY C.Name DESC, L.Name, S.Name 