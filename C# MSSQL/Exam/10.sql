SELECT C.LastName, CEILING(AVG(B.Rating)) AS AverageRating, P.Name AS PublisherName FROM Creators AS C
JOIN CreatorsBoardgames AS CB ON CB.CreatorId = C.Id
JOIN Boardgames AS B ON B.Id = CB.BoardgameId
JOIN Publishers AS P ON P.Id = B.PublisherId
WHERE P.Name = 'Stonemaier Games'
GROUP BY P.Name,C.LastName
ORDER BY AverageRating DESC
