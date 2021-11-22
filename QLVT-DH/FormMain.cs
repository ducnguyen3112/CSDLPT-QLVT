using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using QLVT_DH.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static int report = 0;
        public FormMain()
        {
            InitializeComponent();
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lbUserinfo.Text = "Mã NV:" + Program.userName + " | Họ tên:" + Program.mHoTen + " | Nhóm:" + Program.mGroup;
            FormNV fNV = new FormNV();
            fNV.MdiParent = this;
            fNV.Show();
            Cursor = Cursors.Default;
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormKho));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                FormKho fKho = new FormKho();
                fKho.MdiParent = this;
                fKho.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormNV));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                FormNV fNV = new FormNV();
                fNV.MdiParent = this;
                fNV.Show();
            }

        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {

            this.Close();


        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.mGroup.Equals("USER"))
            {
                MessageBox.Show("Bạn không có quyền tạo login.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormTaoLogin fTaoLogin = new FormTaoLogin();
            fTaoLogin.ShowDialog();
        }


        private void btnDDH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FormDDH));
            if (form != null) form.Activate();
            else
            {
                Program.ddhForm = new FormDDH();
                Program.ddhForm.MdiParent = this;
                Program.ddhForm.Show();
            }
        }

        private void btnPN_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FormPhieuNhap));
            if (form != null) form.Activate();
            else
            {
                FormPhieuNhap frmPN = new FormPhieuNhap();
                frmPN.MdiParent = this;
                frmPN.Show();
            }
        }

        private void btnPX_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FormPhieuXuat));
            if (form != null) form.Activate();
            else
            {
                Program.pxForm = new FormPhieuXuat();
                Program.pxForm.MdiParent = this;
                Program.pxForm.Show();
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(SupportReport));
            if (form != null) form.Activate();
            else
            {
                SupportReport f = new SupportReport();
                f.ShowDialog();
            }

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FormVatTu));
            if (form != null) form.Activate();
            else
            {
                FormVatTu frmVT = new FormVatTu();
                frmVT.MdiParent = this;
                frmVT.Show();
            }
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            report = 1;
            Form form = this.CheckExists(typeof(SupportReport));
            if (form != null) form.Activate();
            else
            {
                SupportReport f = new SupportReport();
                //Program.formMain.Enabled = false;
                f.ShowDialog();
            }
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            report = 2;
            Form form = this.CheckExists(typeof(SupportReport));
            if (form != null) form.Activate();
            else
            {
                SupportReport f = new SupportReport();
                //Program.formMain.Enabled = false;
                f.ShowDialog();
            }
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            report = 4;
            Form form = this.CheckExists(typeof(SupportReport));
            if (form != null) form.Activate();
            else
            {
                SupportReport f = new SupportReport();
                //Program.formMain.Enabled = false;
                f.ShowDialog();
            }
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmInHoatDongNhanVien));
            if (form != null) form.Activate();
            else
            {
               frmInHoatDongNhanVien f = new frmInHoatDongNhanVien();
               f.ShowDialog();
            }
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            report = 5;
            Form form = this.CheckExists(typeof(frmInTongHopNhapXuat));
            if (form != null) form.Activate();
            else
            {
                frmInTongHopNhapXuat f = new frmInTongHopNhapXuat();
                //Program.formMain.Enabled = false;
                f.ShowDialog();
            }
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            report = 3;
            Form form = this.CheckExists(typeof(SupportReport));
            if (form != null) form.Activate();
            else
            {
                SupportReport f = new SupportReport();
                //Program.formMain.Enabled = false;
                f.ShowDialog();
            }
        }
    }
}