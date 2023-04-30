SELECT SUBSTRING(T.Name, CHARINDEX(' ', T.Name) + 1, LEN(T.Name)) AS LastName, T.Nationality, T.Age, T.PhoneNumber FROM Tourists AS T
JOIN SitesTourists AS ST ON T.Id = ST.TouristId
JOIN Sites AS S ON S.ID = ST.SiteId
JOIN Categories AS C ON C.Id = S.CategoryId
WHERE C.Name = 'History and archaeology'
GROUP BY SUBSTRING(T.Name, CHARINDEX(' ', T.Name) + 1, LEN(T.Name)), T.Nationality, T.Age, T.PhoneNumber
ORDER BY LastName