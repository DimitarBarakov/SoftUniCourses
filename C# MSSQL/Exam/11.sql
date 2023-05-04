SELECT COUNT(B.Name) FROM Boardgames AS B
JOIN CreatorsBoardgames AS CB ON CB.BoardgameId = B.Id
JOIN Creators AS C ON C.Id = CB.CreatorId
WHERE C.FirstName = 'Bruno'

CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(50))
RETURNS INT
AS 
BEGIN
	DECLARE @COUNT INT
	SET @COUNT = (
	SELECT COUNT(B.Name) FROM Boardgames AS B
JOIN CreatorsBoardgames AS CB ON CB.BoardgameId = B.Id
JOIN Creators AS C ON C.Id = CB.CreatorId
WHERE C.FirstName = @name
	)
	RETURN @COUNT
END
SELECT dbo.udf_CreatorWithBoardgames('Bruno')