SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Updating a specific user's 
--				information only if the user exists
-- =============================================

CREATE OR ALTER PROCEDURE UpdateUser
	@Id INT
	,@IdNo VARCHAR(13)
	,@FirstName VARCHAR(50)
	,@LastName VARCHAR(50)
	,@Email VARCHAR(50)
	,@Phone VARCHAR(15)
	,@StreetAddress VARCHAR(50)
	,@Suburb VARCHAR(50)
	,@City VARCHAR(50)
	,@Province VARCHAR(15)
	,@ErrorCode INT NULL OUTPUT
AS
BEGIN
	IF EXISTS
	(
	SELECT 1
	FROM Users
	WHERE [idNo] = @IdNo
	)
	BEGIN
		UPDATE [dbo].[Users]
		SET [firstName] = @FirstName
			,[lastName] = @LastName
			,[email] = @Email
			,[phone] = @Phone
			,[streetAddress] = @StreetAddress
			,[suburb] = @Suburb
			,[city] = @City
			,[province] = @Province
		WHERE [id] = @Id
	END
	ELSE
	BEGIN
		SET @ErrorCode = 100 -- User does not exist
		RETURN
	END
END
GO
