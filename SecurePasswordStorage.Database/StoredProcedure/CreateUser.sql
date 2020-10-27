CREATE PROCEDURE [dbo].[CreateUser]
	@Username VARCHAR(64),
	@Salt VARCHAR(64),
	@PasswordHash VARCHAR(64)
AS
	INSERT INTO Users(Username, Salt, PasswordHash) VALUES(@Username, @Salt, @PasswordHash);