CREATE FUNCTION	udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100)) 
RETURNS INT 
AS 
BEGIN
	DECLARE @COUNTER INT
	SET @COUNTER = (
	SELECT COUNT(T.Id) FROM Sites AS S
JOIN SitesTourists AS ST ON ST.SiteId = S.Id
JOIN Tourists AS T ON T.Id = ST.TouristId
WHERE S.Name = @Site
GROUP BY S.Name)
RETURN @COUNTER
					
END
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')


