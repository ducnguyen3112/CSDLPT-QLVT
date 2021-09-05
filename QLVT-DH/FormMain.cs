using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVT_DH
{
    public partial class FormMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lbHoTen.Text = "Họ tên:" + Program.mHoTen;
            lbGroup.Text = "Nhóm:" + Program.mGroup;
            lbMaNV.Text = "Mã NV:" + Program.userName;
        }
    }
}
