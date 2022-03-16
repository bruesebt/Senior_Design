CREATE PROCEDURE [dbo].[spPreference_Delete] 
	@Id INT
AS
BEGIN
	DELETE
	FROM dbo.[Preference]
	WHERE Id = @Id;
END