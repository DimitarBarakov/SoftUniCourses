SELECT B.Id, B.Name, B.YearPublished, C.Name FROM Boardgames AS B
JOIN Categories AS C ON C.Id = B.CategoryId
WHERE C.Name = 'Strategy Games' OR C.Name = 'Wargames'
ORDER BY B.YearPublished DESC