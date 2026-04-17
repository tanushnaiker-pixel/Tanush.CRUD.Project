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
		,[idNo] varchar(13) NOT NULL
		,[firstName] varchar(50) NOT NULL
		,[lastName] varchar(50) NOT NULL
		,[email] varchar(50) NOT NULL
		,[phone] varchar(15) NOT NULL
		,[streetAddress] varchar(50) NOT NULL
		,[suburb] varchar(50) NOT NULL
		,[city] varchar(50) NOT NULL
		,[province] varchar(15) NOT NULL
	);
END;
GO
