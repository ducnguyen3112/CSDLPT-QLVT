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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            {
               Application.Exit();
               Program.loginForm.Show();
            }
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát chương trình!", "Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            {
                this.Hide();
                Program.loginForm.Visible = true;
                /*Program.loginForm = new FormLogin();
                Program.loginForm.Show();*/
            }
        }
    }
}
