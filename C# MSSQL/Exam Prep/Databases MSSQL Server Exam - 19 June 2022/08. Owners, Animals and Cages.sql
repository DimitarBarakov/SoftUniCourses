SELECT CONCAT(O.Name, '-', A.Name),O.PhoneNumber,  C.Id FROM Owners AS O
JOIN Animals AS A ON O.Id = A.OwnerId
JOIN AnimalsCages AS AC ON A.Id = AC.AnimalId
JOIN Cages AS C ON AC.CageId = C.Id
JOIN AnimalTypes AS T ON A.AnimalTypeId = T.Id
WHERE T.AnimalType = 'Mammals'
ORDER BY O.Name, A.Name DESC 