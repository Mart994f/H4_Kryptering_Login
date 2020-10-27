﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Username] VARCHAR(64) NOT NULL,
	[Salt] VARCHAR(64) NOT NULL,
	[PasswordHash] VARCHAR(64) NOT NULL,
	CONSTRAINT PK_User
	PRIMARY KEY (Id),
	CONSTRAINT UN_Username
	UNIQUE (Id)

)
