SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Deleting a User from the database
-- =============================================
CREATE PROCEDURE DeleteUser
	@Id nchar(13)
AS
BEGIN
	DELETE
	FROM [dbo].[Users]
	WHERE id = @Id
END
GO
