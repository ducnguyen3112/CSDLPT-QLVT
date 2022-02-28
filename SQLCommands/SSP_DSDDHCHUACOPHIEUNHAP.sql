*Mục đích: lấy những đơn đặt hàng mà chưa có phiếu nhập tương ứng với đơn hàng đó. Yêu cầu phải xuất ra những trường dữ liệu sau:
1.Mã số đơn hàng
2.Ngày
3.Nhà cung cấp
4.Họ tên nhân viên( txtHO + txtTEN)
5.Tên vật tư
6.Số lượng 
7.Đơn giá

Chú ý: đơn đặt hàng ko có chi tiết đơn đặt hàng thì cũng ko hiện lên được. Đơn đặt hàng phải có chi tiết đơn đặt hàng và chưa có phiếu nhập thì mới hiển thị được

CREATE PROCEDURE [dbo].[SP_DSDDHCHUACOPHIEUNHAP]
 AS
BEGIN
  SELECT DH.MasoDDH AS 'Mã số DDH', DH.NGAY AS 'Ngày Đặt', DH.NhaCC AS 'Nhà Cung Cấp',
      NV.HO + ' ' + NV.TEN AS 'Họ và Tên', VT.TENVT AS 'Tên vật tư', CT.SOLUONG as 'Số lượng', CT.DONGIA as 'Đơn giá'
  FROM
  (
    SELECT * FROM DatHang
  ) DH
  LEFT JOIN DBO.PhieuNhap PN ON PN.MasoDDH = DH.MasoDDH
  INNER JOIN DBO.NhanVien NV ON NV.MANV = DH.MANV
  INNER JOIN DBO.CTDDH CT ON DH.MasoDDH = CT.MasoDDH
  INNER JOIN DBO.Vattu VT ON CT.MAVT = VT.MAVT
  WHERE PN.MAPN IS NULL
END
