/****** Object:  StoredProcedure [dbo].[spPreference_Update]    Script Date: 3/18/2022 12:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spPreference_Update]
	@Id INT,
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
	UPDATE dbo.[Preference]
	SET
		UserId = @UserId,
		ZipCode = @ZipCode,
		Distance = @Distance,
		GroupSize = @GroupSize,
		IsFoodRequested = @IsFoodRequested,
		IsDrinksRequested = @IsDrinksRequested,
		EnergyLevel = @EnergyLevel,
		Budget = @Budget,
		TimeOfDay = @TimeOfDay,
		DressCode = @DressCode,
		DateAdded = @DateAdded
	WHERE Id = @Id;
END