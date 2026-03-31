SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tanush Naiker
-- Create date: 30/03/2026
-- Description:	Updating a specific user's 
--				information
-- =============================================
CREATE PROCEDURE UpdateUser
	@Id int,
	@FirstName nchar(50),
	@LastName nchar(50),
	@Email nvarchar(MAX),
	@Phone nchar(10),
	@StreetAddress nchar(50),
	@Suburb nchar(50),
	@City nchar(50),
	@Province nchar(50)
AS
BEGIN
	UPDATE [dbo].[Users]
	SET firstName = @FirstName,
		lastName = @LastName,
		email = @Email,
		phone = @Phone,
		streetAddress = @StreetAddress,
		suburb = @Suburb,
		city = @City,
		province = @Province
	WHERE id = @Id
END
GO
