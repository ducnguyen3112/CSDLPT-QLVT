ALTER PROC [dbo].[SP_RP_TONGHOPNHAPXUAT]
	@NGAYBD date, @NGAYKT date
AS
BEGIN
	--SET NOCOUNT ON là một dòng mã được sử dụng trong SQL để không trả về giá trị cho một 
	--số lượng hàng nào đó trong khi thực hiện truy vấn.Nó có nghĩa là không được tính toán.
    --Và khi bạn SET NOCOUNT OFF thì các câu truy vấn sẽ ảnh hưởng đến giá trị của tất cả các hàng.
	SET NOCOUNT ON;
		IF 1=0 BEGIN
			SET FMTONLY OFF
		END
		SELECT	PN.NGAY,
				NHAP = SUM(CTPN.SOLUONG * CTPN.DONGIA), -- tổng 1 ngày
				-- tổng 1 ngày chia cho tổng nhập trong khoảng thời gian đưa vào
				TYLENHAP = (SUM(CTPN.SOLUONG * CTPN.DONGIA) / (SELECT SUM(SOLUONG*DONGIA) -- tổng 1 khoảng thời gian
				FROM CTPN INNER JOIN PhieuNhap ON CTPN.MAPN=PhieuNhap.MAPN 
				WHERE NGAY BETWEEN @NGAYBD AND @NGAYKT)) INTO #PhieuNhapTam
		FROM PhieuNhap AS PN
			INNER JOIN (SELECT * FROM CTPN) AS CTPN 
			ON PN.MAPN = CTPN.MAPN
		WHERE NGAY BETWEEN @NGAYBD AND @NGAYKT
		GROUP BY PN.NGAY

		SELECT	PX.NGAY,
				XUAT = SUM(CTPX.SOLUONG * CTPX.DONGIA),
				TYLEXUAT = (SUM(CTPX.SOLUONG * CTPX.DONGIA) / (SELECT SUM(SOLUONG*DONGIA) 
				FROM CTPX INNER JOIN PhieuXuat ON CTPX.MAPX=PhieuXuat.MAPX 
				WHERE NGAY BETWEEN @NGAYBD AND @NGAYKT))  INTO #PhieuXuatTam
		FROM PhieuXuat AS PX
			INNER JOIN (SELECT * FROM CTPX) AS CTPX 
			ON PX.MAPX = CTPX.MAPX
		WHERE NGAY BETWEEN @NGAYBD AND @NGAYKT
		GROUP BY PX.NGAY				
		-- isnull lấy 1 giá trị cụ thể để thay thế giá trị bị null
		SELECT 
		ISNULL(PN.NGAY, PX.NGAY) AS NGAY, --
		ISNULL(PN.NHAP, 0) AS NHAP,
		ISNULL(PN.TYLENHAP, 0) AS TYLENHAP,
		ISNULL(PX.XUAT, 0) AS XUAT,
		ISNULL(PX.TYLEXUAT, 0) AS TYLEXUAT
		FROM #PhieuNhapTam AS PN
		FULL JOIN #PhieuXuatTam AS PX
		ON PN.NGAY = PX.NGAY
		ORDER BY NGAY
END
