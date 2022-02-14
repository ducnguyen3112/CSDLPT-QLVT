*Mục đích: lấy tổng số tiền nhập và xuất của một ngày, tính tỉ lệ số tiền nhập | xuât trong 1 ngày với tổng số tiền từ ngày X tới ngày Y
ALTER PROC [dbo].[SP_RP_TONGHOPNHAPXUAT]
	@NGAYBD date, @NGAYKT date
AS
BEGIN
   *Đọc thêm lý do sử dụng if 1 = 0 set FTMonly off:https://www.sqlservercentral.com/forums/topic/if-10-begin-set-fmtonly-off-end#post-1207481
    - Ngắn gọn là nếu FTMonly = Off thì phải chạy hết STORED PROCEDURE này mới xuất ra tên các cột. 
    Điều này là ko hợp lý nếu cả hàng nghìn cột phải tính toán thì thời gian để quét hết các kết quả có thể quá thời gian Visual Studio chờ để lấy tên cột-> báo lỗi
- Đặt là FTMonly= On thì sẽ bỏ qua hết các câu lênh tính toán để trả ngay về tên cột trước.
	SET NOCOUNT ON;
		IF (1=0) 
		BEGIN
			SET FMTONLY OFF
		END
		--------------------phieu nhap--------------------------
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
		--------------------phieu xuat--------------------------
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
		-----------------------TONG HOP--------------------------------------
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
