CREATE PROCEDURE [dbo].[spActivity_Delete] 
	@Id INT
AS
BEGIN
	DELETE
	FROM dbo.[Activity]
	WHERE Id = @Id;
END