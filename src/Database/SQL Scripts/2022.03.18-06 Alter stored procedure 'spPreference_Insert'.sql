/****** Object:  StoredProcedure [dbo].[spPreference_Insert]    Script Date: 3/18/2022 12:57:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spPreference_Insert]
	@UserId INT,
	@ZipCode nvarchar(15),
	@Distance INT = NULL,
	@GroupSize INT = NULL,
	@IsFoodRequested BIT = NULL,
	@IsDrinksRequested BIT = NULL, 
	@EnergyLevel INT = NULL,
	@Budget INT = NULL,
	@TimeOfDay INT = NULL,
	@DressCode INT = NULL,
	@DateAdded date
AS
BEGIN
	INSERT INTO dbo.[Preference]
		(UserId,
		ZipCode,
		Distance,
		GroupSize,
		IsFoodRequested,
		IsDrinksRequested,
		EnergyLevel,
		Budget,
		TimeOfDay,
		DressCode,
		DateAdded)
	VALUES
		(@UserId,
		@ZipCode,
		@Distance,
		@GroupSize,
		@IsFoodRequested,
		@IsDrinksRequested,
		@EnergyLevel,
		@Budget,
		@TimeOfDay,
		@DressCode,
		@DateAdded);
END