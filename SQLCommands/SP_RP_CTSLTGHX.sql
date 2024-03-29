ALTER PROCEDURE [dbo].[SP_RP_CTSLTGHX] 
@date1 date, @date2 date,@group nvarchar(10)
AS
IF(@group!='CONGTY')
	BEGIN
		SELECT MONTHYEAR,TENVT,TONGSL, TONGGT FROM
(select MONTHYEAR,MAVT,SUM(SOLUONG) as TONGSL,SUM(TONGGT) AS TONGGT
FROM  
(select CONCAT(MONTH(NGAY),'/',YEAR(NGAY)) as MONTHYEAR,MAPX from PhieuXuat where NGAY BETWEEN @date1 and @date2) R1,
(select MAVT,MAPX,SOLUONG,DONGIA*SOLUONG as TONGGT from CTPX) R2
WHERE R1.MAPX=R2.MAPX
GROUP BY MONTHYEAR,MAVT ) R3
left join
(select TENVT,MAVT from Vattu) R4
on (R3.MAVT=R4.MAVT)
ORDER BY MONTHYEAR DESC
	END
ELSE
	BEGIN
		SELECT MONTHYEAR,TENVT,TONGSL, TONGGT FROM
(select MONTHYEAR,MAVT,SUM(SOLUONG) as TONGSL,SUM(TONGGT) AS TONGGT
FROM  
(select CONCAT(MONTH(NGAY),'/',YEAR(NGAY)) as MONTHYEAR,MAPX from PhieuXuat where NGAY BETWEEN @date1 and @date2) R1,
(select MAVT,MAPX,SOLUONG,DONGIA*SOLUONG as TONGGT from CTPX) R2
WHERE R1.MAPX=R2.MAPX
GROUP BY MONTHYEAR,MAVT) R3
left join
(select TENVT,MAVT from Vattu) R4
on (R3.MAVT=R4.MAVT)
UNION
SELECT MONTHYEAR,TENVT,TONGSL, TONGGT FROM
(select MONTHYEAR,MAVT,SUM(SOLUONG) as TONGSL,SUM(TONGGT) AS TONGGT
FROM  
(select CONCAT(MONTH(NGAY),'/',YEAR(NGAY)) as MONTHYEAR,MAPX from LINK1.QLVT.dbo.PhieuXuat where NGAY BETWEEN @date1 and @date2) R1,
(select MAVT,MAPX,SOLUONG,DONGIA*SOLUONG as TONGGT from LINK1.QLVT.dbo.CTPX) R2
WHERE R1.MAPX=R2.MAPX
GROUP BY MONTHYEAR,MAVT) R3
left join
(select TENVT,MAVT from Vattu) R4
on (R3.MAVT=R4.MAVT)
ORDER BY MONTHYEAR DESC

	END
