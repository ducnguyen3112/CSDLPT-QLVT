using DevExpress.XtraBars;
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
                FormPhieuXuat frmPX = new FormPhieuXuat();
                frmPX.MdiParent = this;
                frmPX.Show();
            }
        }
    }
}