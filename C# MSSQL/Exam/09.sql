SELECT CONCAT(C.FirstName,' ',C.LastName) AS FullName, C.Email, MAX(B.Rating) AS Rating FROM Creators AS C
JOIN CreatorsBoardgames AS CB ON CB.CreatorId = C.Id
JOIN Boardgames AS B ON B.Id = CB.BoardgameId
WHERE C.Email LIKE '%.com'
GROUP BY CONCAT(C.FirstName,' ',C.LastName), C.Email
ORDER BY FullName 