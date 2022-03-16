CREATE PROCEDURE [dbo].[spActivity_Update]
	@Id INT,
	@UserId int,
	@PreferenceId int,
	@Place_Id nvarchar(255),
	@Name nvarchar(255),
	@DateAdded date,
	@Rating int
AS
BEGIN
	UPDATE dbo.[Activity]
	SET
		UserId = @UserId,
		PreferenceId = @PreferenceId,
		Place_Id = @Place_Id,
		Name = @Name,
		DateAdded = @DateAdded,
		Rating = @Rating
	WHERE Id = @Id;
END