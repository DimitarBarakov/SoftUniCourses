DELETE FROM Publishers
WHERE Id = 1

DELETE FROM Addresses
WHERE Town LIKE 'L%'

SELECT A.Town, P.Id FROM Publishers AS P
JOIN Addresses AS A ON A.Id = P.AddressId
WHERE Town LIKE 'L%'