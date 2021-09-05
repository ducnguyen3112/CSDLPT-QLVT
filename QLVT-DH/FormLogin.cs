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

    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conPublisher = new SqlConnection();
        private void layDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            if (conPublisher.State==ConnectionState.Closed)
            {
                conPublisher.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd, conPublisher);
            da.Fill(dt);
            conPublisher.Close();
            Program.bds_dspm.DataSource = dt;
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
        }

        private int ketNoiPublisher()
        {
            if (conPublisher != null && conPublisher.State == ConnectionState.Open)
            {
                
                conPublisher.Close();
            }
            try
            {
                conPublisher.ConnectionString = Program.constrPublisher;
                conPublisher.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!\n\n" + e.Message, "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }

       


        public FormLogin()
        {
            
            InitializeComponent();
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cbChiNhanh.SelectedValue.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (ketNoiPublisher() == 0)
            {
                return;
            }
            layDSPM("select TENCN,TENSERVER from Get_Subscribes where TENSERVER!='STARSCREAM\\STARCREAMSERVER3'");
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim()==""||txtPasswd.Text.Trim()=="")
            {
                MessageBox.Show("Username và mật khật không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.mLogin = txtUserName.Text;
            Program.passwd = txtPasswd.Text;
            Program.servername = cbChiNhanh.SelectedValue.ToString();
            if (Program.KetNoi()==0)
            {
                return;
            }
            Program.mChiNhanh = cbChiNhanh.SelectedIndex;
            Program.mloginDN = Program.mLogin;
            Program.passwdDN = Program.passwd;
            string spStr = "EXEC SP_LayThongTinNVTuLogin '" + Program.mLogin + "'";

            Program.myReader = Program.ExecSqlDataReader(spStr);
            if (Program.myReader==null)
            {
                return;
            }
            Program.myReader.Read();
            Program.userName = Program.myReader.GetString(0);
            if (Convert.IsDBNull(Program.userName))
            {
                MessageBox.Show("Tài khoản không có quyền truy cập dữ liệu!\nKiểu tra lại Username và password.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.mHoTen = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();

            Program.mainForm = new FormMain();
            this.Hide();
            Program.mainForm.ShowDialog();
            txtPasswd.Text = "";
            txtUserName.Text = "";
            this.Show();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}