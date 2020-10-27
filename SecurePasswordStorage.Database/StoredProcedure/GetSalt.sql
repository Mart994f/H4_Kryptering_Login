CREATE PROCEDURE [dbo].[GetSalt]
	@Username VARCHAR(64)
AS
	SELECT Users.Salt FROM Users WHERE Users.Username = @Username;

