ALTER PROCEDURE [dbo].[SP_KTTrungNV]
@MANV NVARCHAR(15)
AS
BEGIN
		IF EXISTS(SELECT * FROM dbo.NhanVien AS NV WHERE NV.MANV = @MANV)
			RETURN 1;
		IF EXISTS(SELECT * FROM LINK2.QLVT.dbo.NhanVien AS NV WHERE NV.MANV = @MANV)
			RETURN 1; 
	RETURN 0;
END