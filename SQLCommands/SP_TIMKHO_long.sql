CREATE PROC [dbo].[SP_TIMKHO]
@MAKHO NCHAR(4)
AS
BEGIN
	IF EXISTS (SELECT MAKHO FROM DBO.KHO WHERE MAKHO = @MAKHO)
		RETURN 1;
	ELSE
		IF EXISTS (SELECT MAKHO FROM LINK1.QLVT_DATHANG.DBO.KHO WHERE MAKHO = @MAKHO)
			RETURN 1;
		ELSE
			RAISERROR(N'Kho bạn tìm không tồn tại!',16,1)
END
