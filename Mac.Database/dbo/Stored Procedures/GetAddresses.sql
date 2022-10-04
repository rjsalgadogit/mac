-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAddresses]
(
	@Keyword nvarchar(max) = '', 
    @OffSet int,
    @PageSize int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @OffSet = (@OffSet - 1) * @PageSize

	IF (@PageSize > 0)
	BEGIN
		SELECT * FROM Addresses 
		WHERE ISNULL(@Keyword, '') = '' OR 
			  (ISNULL(@Keyword, '') != '' AND Description LIKE '%' + @Keyword + '%') OR 
			  (ISNULL(@Keyword, '') != '' AND Address LIKE '%' + @Keyword + '%') OR 
			  (ISNULL(@Keyword, '') != '' AND Id LIKE '%' + @Keyword + '%')
		ORDER BY Id
		OFFSET @OffSet ROWS 
		FETCH NEXT @PageSize ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT * FROM Addresses 
		WHERE ISNULL(@Keyword, '') = '' OR 
			  (ISNULL(@Keyword, '') != '' AND Description LIKE '%' + @Keyword + '%') OR 
			  (ISNULL(@Keyword, '') != '' AND Address LIKE '%' + @Keyword + '%') OR 
			  (ISNULL(@Keyword, '') != '' AND Id LIKE '%' + @Keyword + '%')
		ORDER BY Id
	END
END