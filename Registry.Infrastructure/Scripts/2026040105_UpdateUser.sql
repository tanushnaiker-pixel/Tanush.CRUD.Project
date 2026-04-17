SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Updating a specific user's 
--				information
-- =============================================
CREATE OR ALTER PROCEDURE UpdateUser
	@Id UNIQUEIDENTIFIER
	,@IdNo varchar(13)
	,@FirstName varchar(50)
	,@LastName varchar(50)
	,@Email varchar(50)
	,@Phone varchar(15)
	,@StreetAddress varchar(50)
	,@Suburb varchar(50)
	,@City varchar(50)
	,@Province varchar(15)
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
