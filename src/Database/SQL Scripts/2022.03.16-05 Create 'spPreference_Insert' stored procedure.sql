CREATE PROCEDURE [dbo].[spPreference_Insert]
	@UserId INT,
	@GroupSize INT,
	@IsFoodRequested BIT,
	@IsDrinksRequested BIT, 
	@EnergyLevel INT,
	@Budget INT,
	@TimeOfDay INT,
	@DressCode INT
AS
BEGIN
	INSERT INTO dbo.[Preference]
		(UserId,
		GroupSize,
		IsFoodRequested,
		IsDrinksRequested,
		EnergyLevel,
		Budget,
		TimeOfDay,
		DressCode)
	VALUES
		(@UserId,
		@GroupSize,
		@IsFoodRequested,
		@IsDrinksRequested,
		@EnergyLevel,
		@Budget,
		@TimeOfDay,
		@DressCode);
END