
CREATE TABLE Cards(
    Id int PRIMARY KEY IDENTITY(1, 1),
    Number nvarchar(16),
    Year int,
    Month int,
    Type nvarchar(30)
)

GO

CREATE PROCEDURE [SP_CardsExists] @cardNumber nvarchar(16) 
AS
BEGIN
    SELECT * FROM [Cards] WHERE [Number] = @cardNumber
END