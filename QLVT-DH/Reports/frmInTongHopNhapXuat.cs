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
    public partial class frmInTongHopNhapXuat : DevExpress.XtraEditors.XtraForm
    {
        public frmInTongHopNhapXuat()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (FormMain.report == 5)
            {
                String bd = dateEditFrom.Text;
                String kt = dateEditTo.Text;

                if (bd.CompareTo(kt) > 0)
                {
                    MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu", string.Empty, MessageBoxButtons.OK);
                    return;
                }

                RP_TONGHOPNHAPXUAT rp = new RP_TONGHOPNHAPXUAT(bd, kt);


                rp.label1.Text = "BẢNG TỔNG HỢP NHẬP XUẤT TỪ NGÀY " + bd + " ĐẾN NGÀY " + kt;

                ReportPrintTool print = new ReportPrintTool(rp);
                print.ShowPreviewDialog();
                Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string filename = "";
            String bd = dateEditFrom.Text;
            String kt = dateEditTo.Text;
            XtraReport report = null;
            if (FormMain.report == 5)
            {
                report = new RP_TONGHOPNHAPXUAT(bd,kt);
                filename = "TongHopNhapXuat.pdf ";
            }
            try
            {
                if (File.Exists(@"E:\" + filename))
                {
                    DialogResult dr = MessageBox.Show("File " + filename + " tại ổ E đã có!\nBạn có muốn ghi đè?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        report.ExportToPdf(@"E:\" + filename);
                        MessageBox.Show("File " + filename + "đã được ghi thành công tại ổ E",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    report.ExportToPdf(@"E:\" + filename);
                    MessageBox.Show("File " + filename + "đã được ghi thành công tại ổ E",
                 "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show("Vui lòng đóng file " + filename + ex.Message,
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}