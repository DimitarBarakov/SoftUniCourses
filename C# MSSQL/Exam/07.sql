SELECT C.Id,CONCAT(C.FirstName, ' ', C.LastName) AS CreatorName, C.Email FROM Creators AS C
LEFT JOIN CreatorsBoardgames AS CB ON CB.CreatorId = C.Id
LEFT JOIN Boardgames AS B ON B.Id = CB.BoardgameId
WHERE B.Id IS NULL
ORDER BY CreatorName  