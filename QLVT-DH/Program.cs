using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLVT_DH
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SqlConnection con = new SqlConnection();
        public static SqlDataAdapter da;
        public static SqlDataReader myReader;
        public static String serverName = "";
        public static String constr;
        public static String constrPublisher = "Data Source=DESKTOP-8M2NJ75\\HOANGLONG1;Initial Catalog=QLVT_DATHANG;Integrated Security=True";
        public static String userName = "";
        public static String mLogin = "";
        public static String passwd = "";
        public static String database = "QLVT_DATHANG";
        public static String remoteLogin = "HTKN";
        public static String remotePasswd = "123";
        public static String mloginDN = "";
        public static String passwdDN = "";
        public static String mGroup = "";
        public static String mHoTen = "";
        public static int mChiNhanh = 0;
        public static BindingSource bds_dspm = new BindingSource();
        public static FormLogin loginForm;
        public static FormMain mainForm;

        public static int KetNoi()
        {
            if (Program.con != null && Program.con.State == ConnectionState.Open) Program.con.Close();
            try
            {
                Program.constr = "Data Source=" + Program.serverName + ";Initial Catalog=" + Program.database + ";User ID=" +
                      Program.mLogin + ";password=" + Program.passwd;
                Program.con.ConnectionString = Program.constr;
                Program.con.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!\nUsername hoặc mật khẩu không đúng.\n\n" + e.Message + "\n" + Program.constr, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static SqlDataReader ExecSqlDataReader(String cmd)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = Program.con;
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.Text;

            if (Program.con.State == ConnectionState.Closed) Program.con.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.con.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable ExecSqlQuery(String cmd, String connectionstring)
        {
            DataTable dt1 = new DataTable();
            con = new SqlConnection(connectionstring);
            da = new SqlDataAdapter(cmd, con);
            da.Fill(dt1);
            return dt1;

        }


        public static int ExecSqlNonQuery(String cmd, String connectionstring)
        {
            con = new SqlConnection(connectionstring);
            SqlCommand Sqlcmd = new SqlCommand();
            Sqlcmd.Connection = con;
            Sqlcmd.CommandText = cmd;
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 300;
            if (con.State == ConnectionState.Closed) con.Open();
            try
            {

                Sqlcmd.ExecuteNonQuery(); con.Close(); return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return 0;
            }
        }



        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* con.ConnectionString = "Data Source=STARSCREAM\\STARCREAMSERVER1;Initial Catalog=QLVT;User ID=LT;Password=123456;";
             con.Open();
             if (con!=null)
             {
                 MessageBox.Show("Thanh cong","", MessageBoxButtons.OK);
             }*/

            loginForm = new FormLogin();
            Application.Run(loginForm);
        }
    }
}