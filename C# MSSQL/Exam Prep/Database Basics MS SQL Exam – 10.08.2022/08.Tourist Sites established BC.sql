SELECT S.Name AS Site, L.Name AS Location, L.Municipality, L.Province, S.Establishment FROM Sites AS S
JOIN Locations AS L ON L.Id = S.LocationId
WHERE (L.Name NOT LIKE 'B%' AND L.Name NOT LIKE 'M%' AND L.Name NOT LIKE 'D%') AND S.Establishment LIKE '%BC%'
ORDER BY S.Name 