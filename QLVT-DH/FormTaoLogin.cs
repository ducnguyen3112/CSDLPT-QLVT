using DevExpress.XtraEditors;
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

namespace QLVT_DH
{
    public partial class FormTaoLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormTaoLogin()
        {
            InitializeComponent();
        }

        private void FormTaoLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.V_DS_TENNV' table. You can move, or remove it, as needed.
            this.TENNVTableAdapter.Connection.ConnectionString = Program.constr;
            this.TENNVTableAdapter.Fill(this.dS.V_DS_TENNV);
            cbCN.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cbCN.DisplayMember = "TENCN";
            cbCN.ValueMember = "TENSERVER";
            cbCN.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup.Equals("CONGTY"))
            {
                cbNhom.SelectedItem = "CONGTY";
                cbNhom.Enabled = false;
            }
            else
            {
                cbNhom.Items.Remove("CONGTY");
                cbCN.Enabled = false;
                cbNhom.SelectedIndex = 0;
            }

        }

        private void cbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCN.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.serverName = cbCN.SelectedValue.ToString();
            if (cbCN.SelectedIndex != Program.mChiNhanh)
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
            else
            {
                this.TENNVTableAdapter.Connection.ConnectionString = Program.constr;
                this.TENNVTableAdapter.Fill(this.dS.V_DS_TENNV);
                /*this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);*/
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không được để trống tên đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return;
            }

            if (txtPasswd.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không được để trống tên password", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswd.Focus();
                return;
            }
            String login = txtLogin.Text.Trim();
            String password = txtPasswd.Text.Trim();
            Program.con = new SqlConnection(Program.constr);
            Program.con.Open();
            SqlCommand cmd = new SqlCommand("SP_TAOLOGIN", Program.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@LGNAME", login));
            cmd.Parameters.Add(new SqlParameter("@PASS", password));
            cmd.Parameters.Add(new SqlParameter("@USERNAME", cbTENNV.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@ROLE", cbNhom.SelectedItem));
            SqlDataReader myReader = null;
            try
            {
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}