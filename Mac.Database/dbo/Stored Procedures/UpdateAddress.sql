-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateAddress]
	@Id int,
	@Address nvarchar(12),
	@Description nvarchar(120)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF @Id > 0
	BEGIN
		UPDATE Addresses
		SET
			Address = @Address,
			Description = @Description
		WHERE Id = @Id
	END
	ELSE
	BEGIN
		INSERT INTO Addresses (Address, Description)
		SELECT @Address, @Description
	END
END