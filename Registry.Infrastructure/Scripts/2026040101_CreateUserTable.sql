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
		[id] INT IDENTITY(1,1) PRIMARY KEY
		,[idNo] VARCHAR(13) NOT NULL
		,[firstName] VARCHAR(50) NOT NULL
		,[lastName] VARCHAR(50) NOT NULL
		,[email] VARCHAR(50) NOT NULL
		,[phone] VARCHAR(15) NOT NULL
		,[streetAddress] VARCHAR(50) NOT NULL
		,[suburb] VARCHAR(50) NOT NULL
		,[city] VARCHAR(50) NOT NULL
		,[province] VARCHAR(15) NOT NULL
	);
END;
GO
