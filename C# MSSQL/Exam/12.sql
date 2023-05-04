

CREATE PROC usp_SearchByCategory(@category VARCHAR(50)) 
AS 
BEGIN 
	SELECT B.Name, B.YearPublished, B.Rating, C.Name AS CategoryName,P.Name AS PublisherName, CONCAT(CAST(PR.PlayersMin AS VARCHAR),' people') AS MinPlayers, CONCAT(CAST(PR.PlayersMax AS VARCHAR),' people') AS MaxPlayers FROM Boardgames AS B
JOIN Categories AS C ON C.Id = B.CategoryId
JOIN Publishers AS P ON P.Id = B.PublisherId
JOIN PlayersRanges AS PR ON PR.Id = B.PlayersRangeId
WHERE C.Name = @category
ORDER BY PublisherName,  B.YearPublished DESC
END

drop proc usp_SearchByCategory

EXEC usp_SearchByCategory 'Wargames'
