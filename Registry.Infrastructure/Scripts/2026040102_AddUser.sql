SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Creating a new User only if
--				the user does not already exist
-- =============================================

CREATE OR ALTER PROCEDURE AddUser
	@IdNo VARCHAR(13) 
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
	IF NOT EXISTS
	(
	SELECT 1
	FROM Users
	WHERE [idNo] = @IdNo
	)
	BEGIN
		INSERT INTO [dbo].[Users]([idNo], [firstName], [lastName], [email], [phone], [streetAddress], [suburb], [city], [province]) 
		VALUES (@IdNo, @FirstName, @LastName, @Email, @Phone, @StreetAddress, @Suburb, @City, @Province)
	END
	ELSE
	BEGIN
		SET @ErrorCode = 101 -- User already exists
		RETURN
	END
END
GO
