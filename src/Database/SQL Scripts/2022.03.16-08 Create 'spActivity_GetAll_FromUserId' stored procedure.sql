CREATE PROCEDURE [dbo].[spActivity_GetAll_FromUserId] 
	@UserId INT
AS
BEGIN
	SELECT * 
	FROM [dbo].[Activity]
	WHERE UserId = @UserId;
END