using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH.Reports
{
    public partial class frmInHoatDongNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public static int maNV;
        public static String tenNV;
        public static String ngaySinh;
        public static String diaChi;
        public static int luong;
        public static String maCN;
        public frmInHoatDongNhanVien()
        {
            InitializeComponent();
        }

        private void sp_DSNhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sp_DSNhanVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmInHoatDongNhanVien_Load(object sender, EventArgs e)
        {

            this.dS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.DSNhanVienCoHD' table. You can move, or remove it, as needed.
            this.dSNhanVienCoHDTableAdapter.Connection.ConnectionString = Program.constr;
            this.dSNhanVienCoHDTableAdapter.Fill(this.dS.DSNhanVienCoHD);
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String type = (rbNhap.Checked) ? "N" : "X";

            RP_HOATDONGNHANVIEN rpt = new RP_HOATDONGNHANVIEN(maNV, deFrom.DateTime, deTo.DateTime, type);
            rpt.xrlMaNV.Text = maNV.ToString().Trim();
            rpt.xrlHoTen.Text = tenNV;
            rpt.xrlNgaySinh.Text = ngaySinh;
            rpt.xrlDiaChi.Text = diaChi;
            rpt.xrlLuong.Text = luong.ToString().Trim();
            rpt.xrlCN.Text = maCN;
            rpt.xrTitle.Text = "BẢNG KÊ CHỨNG TỪ PHIẾU ";
            rpt.xrTitle.Text += (type == "N") ? "NHẬP" : "XUẤT";

            ReportPrintTool print = new ReportPrintTool(rpt);
            rpt.ShowPreviewDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMaNV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String query = "EXEC SP_ThongTinNhanVien @p1";
            SqlCommand sqlCommand = new SqlCommand(query, Program.con);
            sqlCommand.Parameters.AddWithValue("@p1", cbMaNV.Text);
            SqlDataReader dataReader = null;

            try
            {
                dataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi Database!\n" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                dataReader.Close();
                return;
            }

            dataReader.Read();

            // Gán giá trị cho các label bên report
            maNV = int.Parse(dataReader.GetValue(0).ToString());
            tenNV = dataReader.GetValue(1).ToString();
            ngaySinh = dataReader.GetValue(2).ToString();
            diaChi = dataReader.GetValue(3).ToString();
            luong = int.Parse(dataReader.GetValue(4).ToString());
            maCN = dataReader.GetValue(5).ToString();
            txtTenNV.Text = tenNV;
            dataReader.Close();
        }
    }
}
