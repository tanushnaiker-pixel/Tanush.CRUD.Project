SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tanush Naiker
-- Create date: 01/04/2026
-- Description:	Creating User table only if it
--				does not exist
-- =============================================
IF NOT EXISTS
(
	SELECT *
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Users'
	AND TABLE_SCHEMA = 'dbo'
)
BEGIN
	CREATE TABLE [dbo].[Users]
	(
		[id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY
		,[idNo] nchar(13) NOT NULL
		,[firstName] nchar(50) NOT NULL
		,[lastName] nchar(50) NOT NULL
		,[email] nvarchar(50) NOT NULL
		,[phone] nchar(50) NOT NULL
		,[streetAddress] nchar(50) NOT NULL
		,[suburb] nchar(50) NOT NULL
		,[city] nchar(50) NOT NULL
		,[province] nchar(50) NOT NULL
	);
END;
GO
