CREATE PROCEDURE [dbo].[spActivity_Get] 
	@Id INT
AS
BEGIN
	SELECT * 
	FROM dbo.[Activity]
	WHERE Id = @Id;
END