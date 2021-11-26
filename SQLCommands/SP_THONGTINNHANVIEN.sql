ALTER PROC [dbo].[SP_THONGTINNHANVIEN]
@MANV INT
AS
BEGIN
	SELECT MANV, HO + ' ' + TEN AS HOTEN, NGAYSINH, DIACHI, LUONG, MACN
	FROM dbo.NhanVien 
	WHERE MANV = @MANV
END