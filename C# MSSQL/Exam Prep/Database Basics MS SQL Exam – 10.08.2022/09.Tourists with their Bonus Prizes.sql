SELECT T.Name, T.Age, T.PhoneNumber, T.Nationality, ISNULL(B.Name,'(no bonus prize)') AS REWARD FROM Tourists AS T 
LEFT JOIN TouristsBonusPrizes AS TB ON T.Id = TB.TouristId
LEFT JOIN BonusPrizes AS B ON B.Id = TB.BonusPrizeId
ORDER BY T.Name