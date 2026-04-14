SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Getting a specific user's 
--				information
-- =============================================
CREATE PROCEDURE  GetUser
	@Id nchar(13)
AS
BEGIN
	SELECT *
	FROM [dbo].[Users] (NOLOCK)
	WHERE [id] = @Id;
END
GO
