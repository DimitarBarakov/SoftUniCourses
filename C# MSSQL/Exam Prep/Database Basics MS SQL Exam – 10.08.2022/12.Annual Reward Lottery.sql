CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(100))
AS
BEGIN
	SELECT T.Name,
CASE
    WHEN COUNT(S.Id)>=100 THEN 'Gold badge'
    WHEN COUNT(S.Id) >= 50 THEN  'Silver badge'
    ELSE 'Bronze  badge'
END
FROM Tourists AS T
JOIN SitesTourists AS ST ON ST.TouristId = T.Id
JOIN Sites AS S ON S.Id = ST.SiteId
WHERE T.Name = @TouristName
GROUP BY T.Name
END
EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'

