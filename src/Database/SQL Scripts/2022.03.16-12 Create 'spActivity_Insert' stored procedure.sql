CREATE PROCEDURE [dbo].[spActivity_Insert]
	@UserId int,
	@PreferenceId int,
	@Place_Id nvarchar(255),
	@Name nvarchar(255),
	@DateAdded date,
	@Rating int
AS
BEGIN
	INSERT INTO dbo.[Activity]
		(UserId,
		PreferenceId,
		Place_Id,
		Name,
		DateAdded,
		Rating)
	VALUES
		(@UserId,
		@PreferenceId,
		@Place_Id,
		@Name,
		@DateAdded,
		@Rating);
END