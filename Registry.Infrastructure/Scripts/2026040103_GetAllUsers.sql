SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetAllUsers
AS

-- =============================================
-- Author:		Tanush Naiker
-- Create date: 13/03/2026
-- Description:	Getting all users who have registered
--				for an account.
-- =============================================

BEGIN
	SELECT * 
	FROM [dbo].[Users] (NOLOCK)
	-- Could add pagination with LIMIT = 10;
END
GO
