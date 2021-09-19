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
            lbUserinfo.Text= "Mã NV:" + Program.userName + " | Họ tên:" + Program.mHoTen + " | Nhóm:" + Program.mGroup;
            FormNV fNV = new FormNV();
            fNV.MdiParent = this;
            fNV.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormNV));
            if (frm!=null)
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
    }
}