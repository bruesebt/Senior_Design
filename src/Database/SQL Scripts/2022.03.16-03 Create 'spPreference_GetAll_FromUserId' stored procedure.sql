CREATE PROCEDURE [dbo].[spPreference_GetAll_FromUserId]
	@UserId INT
AS
BEGIN

	SELECT * 
	FROM dbo.[Preference]
	WHERE UserId = @UserId;

END