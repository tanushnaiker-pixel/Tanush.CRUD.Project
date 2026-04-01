SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Creating a new User
-- =============================================
CREATE PROCEDURE AddUser
	@Id nchar(13),
	@FirstName nchar(50),
	@LastName nchar(50),
	@Email nvarchar(50),
	@Phone nchar(10),
	@StreetAddress nchar(50),
	@Suburb nchar(50),
	@City nchar(50),
	@Province nchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Users](id, firstName, lastName, email, phone, streetAddress, suburb, city, province) 
	VALUES (@Id, @FirstName, @LastName, @Email, @Phone, @StreetAddress, @Suburb, @City, @Province)
END
GO
