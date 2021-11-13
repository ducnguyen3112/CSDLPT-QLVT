﻿using DevExpress.XtraEditors;
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
            if (FormMain.report == 1)
            {
                RP_DSNV report = new RP_DSNV();
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            else if (FormMain.report == 2)
            {
                RP_DSVT report = new RP_DSVT();
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string filename = "";
            XtraReport report = null;
            if (FormMain.report == 1)
            {
                report = new RP_DSNV();
                filename = "DanhSachNhanVien.pdf";
            }
            else if (FormMain.report == 2)
            {
                report = new RP_DSVT();
                filename = "DanhSachVatTu.pdf";
            }

            try
            {
                if (File.Exists(@"D:\" + filename))
                {
                    DialogResult dr = MessageBox.Show("File " + filename + " tại ổ D đã có!\nBạn có muốn ghi đè?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        report.ExportToPdf(@"D:\" + filename);
                        MessageBox.Show("File " + filename + "đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    report.ExportToPdf(@"D:\" + filename);
                    MessageBox.Show("File " + filename + "đã được ghi thành công tại ổ D",
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

        private void SupportReport_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Visible = lb.Visible = true;
                cbChiNhanh.Enabled = true;
            }
            else
            {
                cbChiNhanh.Visible = lb.Visible = false;

            }
            if (FormMain.report == 1)
            {
                lbtt.Text = "DANH SÁCH NHÂN VIÊN";
                this.get_SubscribesTableAdapter.Fill(this.DSPM.Get_Subscribes);

            }
            else if (FormMain.report == 2)
            {
                
                lbtt.Text = "DANH SÁCH VẬT TƯ";

                this.lb.Visible = this.cbChiNhanh.Visible = false;
            }

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