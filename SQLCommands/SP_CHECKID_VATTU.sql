CREATE PROCEDURE [dbo].[SP_CHECKID_VATTU]
@Code NVARCHAR(15), @Type NVARCHAR(15)
AS
BEGIN
	
	-- Vật tư, chỉ cần check ở site hiện tại
	IF(@Type = 'MAVT')
	BEGIN
		IF EXISTS(SELECT * FROM dbo.Vattu WHERE MAVT = @Code)
		RETURN 1;
	END

	RETURN 0 -- Không bị trùng
END
