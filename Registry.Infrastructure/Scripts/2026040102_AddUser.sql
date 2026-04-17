SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Creating a new User
-- =============================================
CREATE OR ALTER PROCEDURE AddUser
	@IdNo varchar(13)
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
