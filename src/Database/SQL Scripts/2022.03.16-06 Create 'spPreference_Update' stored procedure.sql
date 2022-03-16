CREATE PROCEDURE [dbo].[spPreference_Update]
	@Id INT,
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
	UPDATE dbo.[Preference]
	SET
		UserId = @UserId,
		GroupSize = @GroupSize,
		IsFoodRequested = @IsFoodRequested,
		IsDrinksRequested = @IsDrinksRequested,
		EnergyLevel = @EnergyLevel,
		Budget = @Budget,
		TimeOfDay = @TimeOfDay,
		DressCode = @DressCode
	WHERE Id = @Id;
END