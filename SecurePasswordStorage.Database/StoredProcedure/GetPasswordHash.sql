CREATE PROCEDURE [dbo].[GetPasswordHash]
	@Username VARCHAR(64)
AS
	SELECT Users.PasswordHash FROM Users WHERE Users.Username = @Username;
