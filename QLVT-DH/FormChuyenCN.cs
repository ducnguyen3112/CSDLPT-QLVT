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
    public partial class FormChuyenCN : Form
    {
        public FormChuyenCN()
        {
            InitializeComponent();
        }

        private void FormChuyenCN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSPM.Get_Subscribes' table. You can move, or remove it, as needed.
            this.get_SubscribesTableAdapter.Fill(this.DSPM.Get_Subscribes);
            if (Program.mChiNhanh == 0)
            {
                cbChuyenCN.SelectedIndex = 1;
            }
            if (Program.mChiNhanh == 1)
            {
                cbChuyenCN.SelectedIndex = 0;
            }



        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            string cnChuyen = cbChuyenCN.SelectedValue.ToString();
            String maCN = "";

            if (cnChuyen != Program.serverName)
            {

                if (cnChuyen.Contains("2")) maCN = "CN2";
                else if (cnChuyen.Contains("1")) maCN = "CN1";

                Program.con = new SqlConnection(Program.constr);
                Program.con.Open();
                SqlCommand cmd = new SqlCommand("SP_ChuyenCN", Program.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANV", FormNV.maNV));
                cmd.Parameters.Add(new SqlParameter("@MACN", maCN));
                SqlDataReader myReader = null;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("Chuyển nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormNV.stack.Push(FormNV.maNV + "#" + cnChuyen);
                    FormNV.stack.Push("CHUYENCN");
                    this.Cursor = Cursors.Default;

                    this.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Cursor = Cursors.Default;

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn CN khác chi nhánh hiện tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Cursor = Cursors.Default;


                return;
            }
        }
    }
}
