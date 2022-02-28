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
    public partial class FormKho : DevExpress.XtraEditors.XtraForm
    {
        private string macn;
        private int vitri;
        private Stack<String> stackundo = new Stack<string>(16);
        String query = "";
        Boolean them = false;

        public FormKho()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }
        private void LoadUndo()
        {
            if (stackundo.Count != 0)
            {
                btnUndo.Enabled = true;
            }
            else btnUndo.Enabled = false;
        }
        private void LoadTable()
        {
            try
            {
                DS.EnforceConstraints = false;

                this.khoTableAdapter.Connection.ConnectionString = Program.constr;
                this.khoTableAdapter.Fill(this.DS.Kho);

                this.chiNhanhTableAdapter.Connection.ConnectionString = Program.constr;
                this.chiNhanhTableAdapter.Fill(this.DS.ChiNhanh);

                this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
                this.datHangTableAdapter.Fill(this.DS.DatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);


                macn = ((DataRowView)bdsKho[0])["MACN"].ToString();
                if (Program.mGroup.Equals("CONGTY"))
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = false;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    cbChiNhanh.Enabled = true;
                    gcInfoKho.Enabled = false;
                }
                else if (Program.mGroup == "USER")
                {
                    btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = true;
                    btnThem.Enabled = true;
                    cbChiNhanh.Enabled = txtMaCN.Enabled = false;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    gcInfoKho.Enabled = false;
                }
                else if (Program.mGroup == "CHINHANH")
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled
                        = true;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    cbChiNhanh.Enabled = false; txtMaCN.Enabled = false;
                    gcInfoKho.Enabled = false;
                }

                LoadUndo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FormKho_Load(object sender, EventArgs e)
        {
            LoadTable();
            cbChiNhanh.DataSource = Program.bds_dspm.DataSource;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChiNhanh;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            gcInfoKho.Enabled = true;
            vitri = bdsKho.Position;
            bdsKho.AddNew();
            txtMaCN.Text = macn;
            txtMaKho.Enabled = true;
            them = true;


            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnThoat.Enabled = true;
            txtMaCN.Enabled = cbChiNhanh.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            vitri = bdsKho.Position;
            gcInfoKho.Enabled = true;
            txtMaKho.Enabled = false;
            them = false;
            query = String.Format("update Kho set TENKHO=N'{1}', DIACHI=N'{2}',MACN=N'{3}' where MAKHO=N'{0}'", txtMaKho.Text.Trim(), txtTenKho.Text, txtDiaChi.Text, txtMaCN.Text);
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnThoat.Enabled = true;
            txtMaCN.Enabled = cbChiNhanh.Enabled = false;
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (gcInfoKho.Enabled)
            {
                if (MessageBox.Show("Dữ liệu chưa được lưu vào data", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.serverName = cbChiNhanh.SelectedValue.ToString();
            if (cbChiNhanh.SelectedIndex != Program.mChiNhanh)
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
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới");
            }
            else
            {
                LoadTable();
            }
        }
        private int kiemTraTonTai(String maKho)
        {
            int result = 1;
            String lenh = String.Format("EXEC SP_TIMKHO_L {0}", maKho);
            using (SqlConnection connection = new SqlConnection(Program.constr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    sqlcmt.ExecuteNonQuery();
                }
                catch
                {
                    result = 0;
                }

            }
            return result;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            // KIEM TRA DAU VAO
            txtMaKho.Text = txtMaKho.Text.Trim();

            if (txtMaKho.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Mã kho không được để trống", "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            if (txtMaKho.Text.Length > 4)
            {
                MessageBox.Show("Mã kho không được quá 4 ký tự ", "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;

            }
            else if (txtMaKho.Text.Contains(" "))
            {
                MessageBox.Show("Mã kho không được chứa khoảng trắng!", "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }

            if (txtMaKho.Enabled == true)
            {
                try
                {
                    if (kiemTraTonTai(txtMaKho.EditValue.ToString()) == 1)
                    {
                        MessageBox.Show("Mã kho không được trùng!", "", MessageBoxButtons.OK);
                        txtMaKho.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            if (txtTenKho.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Tên kho không được thiếu !", "", MessageBoxButtons.OK);
                txtTenKho.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Địa chỉ không được thiếu!", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            // luu
            try
            {
                // luu dataset
                bdsKho.EndEdit();
                bdsKho.ResetCurrentItem();
                // luu csdl
                this.khoTableAdapter.Connection.ConnectionString = Program.constr;
                this.khoTableAdapter.Update(this.DS.Kho);
                if (them)
                {
                    query = String.Format("Delete from Kho where MAKHO = N'{0}' ", txtMaKho.Text.Trim());
                }

                stackundo.Push(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi kho." + ex.Message);
                return;
            }
            LoadTable();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            String lenh = stackundo.Pop();
            using (SqlConnection connection = new SqlConnection(Program.constr))
            {
                connection.Open();
                SqlCommand sqlcmt = new SqlCommand(lenh, connection);
                sqlcmt.CommandType = CommandType.Text;
                try
                {
                    sqlcmt.ExecuteNonQuery();
                    LoadTable();
                }
                catch
                {
                    MessageBox.Show(lenh);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maKho = "";
            maKho = ((DataRowView)bdsKho[bdsKho.Position])["MAKHO"].ToString();
            if (bdsPN.Count + bdsPX.Count + bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho này vì đã lập phiếu", "", MessageBoxButtons.OK);
                return;
            }
            else if (MessageBox.Show("Bạn có thật sự xoá kho này !", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String tenKho = ((DataRowView)bdsKho[bdsKho.Position])["TENKHO"].ToString();
                    String diaChi = ((DataRowView)bdsKho[bdsKho.Position])["DIACHI"].ToString();
                    bdsKho.RemoveCurrent();
                    this.khoTableAdapter.Connection.ConnectionString = Program.constr;
                    this.khoTableAdapter.Update(this.DS.Kho);
                    query = String.Format("INSERT INTO KHO (MAKHO, TENKHO,DIACHI,MACN) VALUES(N'{0}', N'{1}', N'{2}',N'{3}')", maKho, tenKho, diaChi, macn);
                    stackundo.Push(query);
                    LoadTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa vật tư. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    //Đặt con trỏ về vị trí hiện thời
                    this.khoTableAdapter.Fill(this.DS.Kho);
                    bdsKho.Position = bdsKho.Find("MAKHO", maKho);
                    return;
                }
            }
        }

      

    }      
}