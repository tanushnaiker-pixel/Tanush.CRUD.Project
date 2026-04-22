SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Getting a specific user's 
--				information
-- =============================================

CREATE OR ALTER PROCEDURE  GetUser
	@Id INT
AS
BEGIN
	SELECT *
	FROM [dbo].[Users] (NOLOCK)
	WHERE [id] = @Id;
END
GO
