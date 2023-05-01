SELECT TOP 5 O.Name, COUNT(A.Name) AS CountOfAnimals FROM Owners AS O
JOIN Animals AS A ON O.Id = A.OwnerId
GROUP BY O.Name
ORDER BY CountOfAnimals DESC, O.Name 