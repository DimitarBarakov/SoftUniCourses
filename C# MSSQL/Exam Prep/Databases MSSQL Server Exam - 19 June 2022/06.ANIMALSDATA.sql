SELECT A.Name,T.AnimalType,FORMAT(A.BirthDate, 'dd.MM.yyyy') AS BirthDate FROM Animals AS A
JOIN AnimalTypes AS T ON A.AnimalTypeId = T.Id
ORDER BY A.Name 