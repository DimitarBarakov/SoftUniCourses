SELECT TOP 5 B.Name, B.Rating, C.Name FROM Boardgames AS B
JOIN Categories AS C ON C.Id = B.CategoryId
JOIN PlayersRanges AS PR ON PR.Id = B.PlayersRangeId
WHERE (B.Rating > 7.00 AND B.Name LIKE '%a%') OR (B.Rating > 7.50 AND (PR.PlayersMin>=2 AND PR.PlayersMax<=5))
ORDER BY B.Name, B.Rating DESC