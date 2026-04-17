SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Deleting a User from the database
-- =============================================
CREATE PROCEDURE DeleteUser
	@Id UNIQUEIDENTIFIER
	,@ErrorCode INT NULL OUTPUT
AS
BEGIN
	IF EXISTS
	(
	SELECT 1
	FROM Users
	WHERE [id] = @Id
	)
	BEGIN
		DELETE
		FROM [dbo].[Users]
		WHERE [id] = @Id
	END
	ELSE
	BEGIN
		SET @ErrorCode = 100 -- User does not exist
		RETURN
	END
END
GO
