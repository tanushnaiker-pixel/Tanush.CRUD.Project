SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tanush Naiker
-- Create date: 13/03/2026
-- Description:	Getting all users who have registered
--				for an account.
-- =============================================

CREATE OR ALTER PROCEDURE GetAllUsers
AS
BEGIN
	SELECT * 
	FROM [dbo].[Users] (NOLOCK)
	-- Could add pagination with LIMIT = 10;
END
GO
