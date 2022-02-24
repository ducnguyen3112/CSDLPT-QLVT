using DevExpress.XtraEditors;
using System;
using System.Collections;
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
    public partial class FormVatTu : DevExpress.XtraEditors.XtraForm
    {

        int position = 0;
        Stack undolist = new Stack();
        Boolean them = false;
        String query = "";
        public FormVatTu()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            position = bdsVT.Position;
            txtMaVT.Enabled = true;
            this.bdsVT.AddNew();
            btnThem.Enabled = btnXoa.Enabled = gcVT.Enabled = btnReload.Enabled = btnUndo.Enabled = btnSua.Enabled= false;
            btnGhi.Enabled = gcInfoVT.Enabled = true;

            //Program.flagCloseFormVT = false; //Bật cờ lên để chặn tắt Form đột ngột khi nhập liệu
            numSLT.Value = 0;
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void FormVatTu_Load(object sender, EventArgs e)
        {
            // Không kiểm tra khóa ngoại (nếu không sẽ hiện bảng cảnh báo)
            dS.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.constr;
            this.vattuTableAdapter.Fill(this.dS.Vattu);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.constr;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);

            this.cTPNTableAdapter.Connection.ConnectionString = Program.constr;
            this.cTPNTableAdapter.Fill(this.dS.CTPN);

            this.cTPXTableAdapter.Connection.ConnectionString = Program.constr;
            this.cTPXTableAdapter.Fill(this.dS.CTPX);


            if (Program.mGroup == "CONGTY")
            {
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = false;
            }

            txtMaVT.Enabled = btnUndo.Enabled =gcInfoVT.Enabled= false;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maVT = "";
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa vật tư này?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                // == Query tìm MAVT ==
                String query_MAVT = "DECLARE @return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKTT_MAVT] " +
                               "@p1 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MAVT, Program.con);
                sqlCommand.Parameters.AddWithValue("@p1", txtMaVT.Text);
                SqlDataReader dataReader = null;

                try
                {
                    dataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đọc và lấy result
                dataReader.Read();
                int result_value_MAVT = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();
                if (result_value_MAVT == 1)
                {
                    MessageBox.Show("Vật tư đang được sử dụng ở chi chánh hiện tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (result_value_MAVT == 2)
                {
                    MessageBox.Show("Vật tư đang được sử dụng ở chi nhánh khác!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        String VT_info = txtMaVT.Text.Trim() + "#" + txtTenVT.Text.Trim() + "#" + txtDVT.Text.Trim() + "#" + numSLT.Text.Trim();
                        Console.WriteLine(VT_info);
                        maVT = ((DataRowView)bdsVT[bdsVT.Position])["MAVT"].ToString(); // Giữ lại mã để khi bị lỗi có thể quay về
                        bdsVT.RemoveCurrent();
                        btnUndo.Enabled = true;
                        undolist.Push(VT_info);
                        undolist.Push("DELETE");
                        this.vattuTableAdapter.Update(this.dS.Vattu);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.vattuTableAdapter.Fill(this.dS.Vattu);
                        bdsVT.Position = bdsVT.Find("MAVT", maVT);
                        return;
                    }
                }
            }
            // Unable nút xóa nếu không có vật tư nào
            if (bdsVT.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                String query_MAVT = "DECLARE @return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKTT_MAVT] " +
                               "@p1 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand1 = new SqlCommand(query_MAVT, Program.con);
                sqlCommand1.Parameters.AddWithValue("@p1", txtMaVT.Text);
                SqlDataReader dataReader1 = null;

                try
                {
                    dataReader1 = sqlCommand1.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đọc và lấy result
                dataReader1.Read();
                int result_value_MAVT = int.Parse(dataReader1.GetValue(0).ToString());
                dataReader1.Close();
                if (result_value_MAVT == 1)
                {
                    MessageBox.Show("Không thể sửa vì vật tư đang được sử dụng ở chi chánh hiện tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (result_value_MAVT == 2)
                {
                    MessageBox.Show("Không thể sửa vì vật tư đang được sử dụng ở chi nhánh khác!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int checkMaVT = bdsVT.Find("TENVT", txtTenVT.Text);
                if (checkMaVT != -1 && (checkMaVT != bdsVT.Position))
                {
                    MessageBox.Show("Tên vật tư trùng. Vui lòng chọn tên vật tư khác!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Có cần thiết chạy SP không trong khi VATTU là nhân bản???
                String query = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKID_VATTU] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query, Program.con);
                sqlCommand.Parameters.AddWithValue("@p1", txtMaVT.Text);
                sqlCommand.Parameters.AddWithValue("@p2", "MAVT");

                SqlDataReader dataReader = null;
                try
                {
                    dataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đọc và lấy result
                dataReader.Read();
                int result_value = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();

                int indexMaVT = bdsVT.Find("MAVT", txtMaVT.Text);
                int indexCurrent = bdsVT.Position;
                String maVT = txtMaVT.Text;
                if (result_value == 1 && (indexMaVT != indexCurrent))
                {
                    MessageBox.Show("Mã vật tư đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database không?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            //Program.flagCloseFormVT = true; // Bật cờ cho phép tắt Form NV
                            btnThem.Enabled = btnXoa.Enabled = gcVT.Enabled = btnReload.Enabled = btnGhi.Enabled = gcInfoVT.Enabled =btnSua.Enabled= true;
                            btnUndo.Enabled = true;
                            this.bdsVT.EndEdit();
                            this.vattuTableAdapter.Update(this.dS.Vattu);
                            undolist.Push(maVT);
                            undolist.Push("INSERT");
                            bdsVT.Position = position;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsVT.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undolist.Count > 0)
            {
                String statement = undolist.Pop().ToString();
                if (statement.Equals("DELETE"))
                {
                    this.bdsVT.AddNew();
                    String TT = undolist.Pop().ToString();
                    Console.WriteLine(TT);
                    String[] TT_VT = TT.Split('#');

                    txtMaVT.Text = TT_VT[0];
                    txtTenVT.Text = TT_VT[1];
                    txtDVT.Text = TT_VT[2];
                    numSLT.Text = TT_VT[3];
                    this.bdsVT.EndEdit();
                    this.vattuTableAdapter.Update(this.dS.Vattu);
                }
                else if (statement.Equals("INSERT"))
                {
                    String maVT = undolist.Pop().ToString();
                    int vitrixoa = bdsVT.Find("MAVT", maVT);
                    bdsVT.Position = vitrixoa;
                    bdsVT.RemoveCurrent();
                    this.vattuTableAdapter.Update(this.dS.Vattu);
                }
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.vattuTableAdapter.Fill(this.dS.Vattu);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TxtMaVT_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaVT.Text))
            {
                e.Cancel = true;
                txtMaVT.Focus();
                errorProvider1.SetError(txtMaVT, "Mã vật tư không được để trống!");
            }
            else if (txtMaVT.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtMaVT.Focus();
                errorProvider1.SetError(txtMaVT, "Mã vật tư không được chứa khoảng trắng!");
            }
            else if (txtMaVT.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtMaVT.Focus();
                errorProvider1.SetError(txtMaVT, "Mã vật tư không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaVT, "");
            }
        }

        private void TxtTenVT_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenVT.Text))
            {
                e.Cancel = true;
                txtTenVT.Focus();
                errorProvider1.SetError(txtTenVT, "Tên vật tư không được để trống!");
            }
            else if (txtTenVT.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtTenVT.Focus();
                errorProvider1.SetError(txtTenVT, "Tên vật tư không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTenVT, "");
            }
        }

        private void TxtDVT_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDVT.Text))
            {
                e.Cancel = true;
                txtDVT.Focus();
                errorProvider1.SetError(txtDVT, "Đơn vị tính không được để trống!");
            }
            else if (txtDVT.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtDVT.Focus();
                errorProvider1.SetError(txtDVT, "Đơn vị tính không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDVT, "");
            }
        }

        private void NumSLT_Validating(object sender, CancelEventArgs e)
        {
            if (numSLT.Value == 0)
            {
                e.Cancel = true;
                numSLT.Focus();
                errorProvider1.SetError(numSLT, "Vui lòng chọn số lượng tồn!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(numSLT, "");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            position = bdsVT.Position;
            txtMaVT.Enabled = false;
            them = false;
            query = String.Format("update Vattu set TENVT=N'{1}', DVT=N'{2}' where MAVT=N'{0}'", txtMaVT.Text.Trim(), txtTenVT.Text, txtDVT.Text);
            btnThem.Enabled = btnXoa.Enabled = gcVT.Enabled = btnReload.Enabled  = false;
            btnGhi.Enabled = gcInfoVT.Enabled = btnUndo.Enabled=btnThoat.Enabled = gcVT.Enabled= true;

            //Program.flagCloseFormVT = false; //Bật cờ lên để chặn tắt Form đột ngột khi nhập liệu
            numSLT.Value = 0;
        }
    }
}