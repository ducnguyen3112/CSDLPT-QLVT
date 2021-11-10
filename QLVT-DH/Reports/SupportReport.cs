using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH.Reports
{
    public partial class SupportReport : DevExpress.XtraEditors.XtraForm
    {
        public SupportReport()
        {
            InitializeComponent();

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            RP_DSNV report = new RP_DSNV();
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            RP_DSNV report = new RP_DSNV();
            try
            {
                if (File.Exists(@"D:\DanhSachNhanVien.pdf"))
                {
                    DialogResult dr = MessageBox.Show("File DanhSachNhanVien.pdf tại ổ D đã có!\nBạn có muốn ghi đè?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        report.ExportToPdf(@"D:\DanhSachNhanVien.pdf");
                        MessageBox.Show("File DanhSachNhanVien.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    report.ExportToPdf(@"D:\DanhSachNhanVien.pdf");
                    MessageBox.Show("File DanhSachNhanVien.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show("Vui lòng đóng file DanhSachNhanVien.pdf\n" + ex.Message,
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        private void SupportReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSPM.Get_Subscribes' table. You can move, or remove it, as needed.
            this.get_SubscribesTableAdapter.Fill(this.DSPM.Get_Subscribes);

        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;

            Program.serverName = cbChiNhanh.SelectedValue.ToString();

            if (cbChiNhanh.SelectedIndex != Program.mChiNhanh)
            {
                Program.mLogin = Program.remoteLogin;
                Program.passwd = Program.remotePasswd;
            }
            else
            {
                Program.mLogin = Program.mloginDN;
                Program.passwd = Program.passwdDN;
            }

            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối", "", MessageBoxButtons.OK);
        }
    }
}