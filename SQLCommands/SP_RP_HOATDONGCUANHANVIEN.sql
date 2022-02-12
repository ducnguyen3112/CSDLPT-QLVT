*Mục đích : lấy chi tiết phiếu nhập | xuất do một nhân viên X lập từ ngày Y tới ngày Z với mã nhân viên.
ALTER PROC [dbo].[SP_RP_HOATDONGCUANHANVIEN]
@MANV INT, @FROM DATE, @TO DATE, @LOAI CHAR
AS
BEGIN
	IF (@LOAI = 'N')
		BEGIN
			SELECT FORMAT(PN.NGAY,'MMMM yyyy') AS THANGNAM, -- Group theo mẫu
				   PN.NGAY, PN.MAPN AS MAPHIEU, N'Không có' AS HOTENKH, TENVT, TENKHO, CTPN.SOLUONG, CTPN.DONGIA, THANHTIEN = SOLUONG * DONGIA
			FROM (SELECT MAPN, NGAY, TENKHO = (SELECT TENKHO FROM KHO WHERE KHO.MAKHO = PNP.MAKHO) FROM dbo.PhieuNhap as PNP WHERE MANV = @MANV AND NGAY BETWEEN @FROM AND @TO) PN,
				 CTPN,
				 (SELECT TENVT, MAVT FROM Vattu) VT
			WHERE VT.MAVT = CTPN.MAVT AND CTPN.MAPN = PN.MAPN
		END
	ELSE
		BEGIN
			SELECT FORMAT(PX.NGAY,'MMMM yyyy') AS THANGNAM, -- Group theo mẫu
					PX.NGAY, PX.MAPX AS MAPHIEU, PX.HOTENKH, TENVT, TENKHO, CTPX.SOLUONG, CTPX.DONGIA, THANHTIEN = SOLUONG * DONGIA
			FROM (SELECT MAPX, NGAY, HOTENKH, TENKHO = (SELECT TENKHO FROM KHO WHERE KHO.MAKHO = PXT.MAKHO) FROM dbo.PhieuXuat as PXT WHERE MANV = @MANV AND NGAY BETWEEN @FROM AND @TO) PX,
				 CTPX,
				 (SELECT TENVT, MAVT FROM Vattu) VT
			WHERE VT.MAVT = CTPX.MAVT AND CTPX.MAPX = PX.MAPX
		END
END
