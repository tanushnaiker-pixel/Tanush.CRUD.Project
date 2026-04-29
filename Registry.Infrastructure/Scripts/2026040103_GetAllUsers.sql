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
	SELECT [idNo], [firstName], [lastName], [email], [phone], [streetAddress], [suburb], [city], [province]
	FROM [dbo].[Users] (NOLOCK)
END
GO
