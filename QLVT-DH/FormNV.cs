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
    public partial class FormNV : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        string maCN = "";
        Stack stack = new Stack();
        String NVinfo = "";
        String action = "";
        public FormNV()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.PhieuXuat' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DS.PhieuNhap' table. You can move, or remove it, as needed.



            DS.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.constr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.constr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);



            cbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChiNhanh;
            if (Program.mChiNhanh == 0)
            {
                maCN = "CN1";
            }
            else
            {
                maCN = "CN2";
            }
            if (Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnChuyen.Enabled = false;
            }
            else
            {
                cbChiNhanh.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = true;
            }
            btnUndo.Enabled = btnGhi.Enabled = false;
            groupControl1.Enabled = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            action = "actThem";
            stack.Push(action);
            vitri = bdsNV.Position;
            groupControl1.Enabled = true;
            bdsNV.AddNew();
            txtMaCN.Text = maCN;
            txtNgaySinh.EditValue = "";
            cbXoa.Checked = false;
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gcNV.Enabled = btnSua.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = txtMaNV.Enabled = txtMaCN.Enabled = true;
            txtMaNV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = "";
            if (Program.userName == ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString())
            {
                MessageBox.Show("Không thể xoá nhân viên đang đăng nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbXoa.Checked == true)
            {
                MessageBox.Show("Nhân viên đã bị xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (datHangBindingSource.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập đơn đặt hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (phieuNhapBindingSource.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập phiếu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (phieuXuatBindingSource.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập phiếu xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult mess = MessageBox.Show("Bạn có thực sự muốn xóa nhân viên này không?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mess == DialogResult.Yes)
            {
                try
                {
                    NVinfo = txtMaNV.Text.Trim() + "#" + txtHo.Text.Trim() + "#" + txtTen.Text.Trim() + "#" + txtMaCN.Text.Trim() + "#" +
                            txtNgaySinh.Text + "#" + txtDiaChi.Text.Trim() + "#" + txtLuong.Text.Trim();
                    maNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                    if (maNV == Program.userName)
                    {
                        MessageBox.Show("Không thể xoá nhân viên đang đăng nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        vitri = bdsNV.Position;
                        bdsNV.RemoveCurrent();
                        btnUndo.Enabled = true;
                        stack.Push(NVinfo);
                        stack.Push("DELETE");
                        SqlCommand cmd = new SqlCommand("Xoa_Login", Program.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@USRNAME", maNV));
                        SqlDataReader myReader = null;
                        try
                        {
                            myReader = cmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        this.nhanVienTableAdapter.Update(this.DS.NhanVien);

                        this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                    bdsNV.Position = vitri;
                    return;
                }
            }
            if (bdsNV.Count == 0)
            {
                btnXoa.Enabled = false;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
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
                MessageBox.Show("Lỗi kết nối", "", MessageBoxButtons.OK);
            else
            {
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.constr;
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
                this.datHangTableAdapter.Fill(this.DS.DatHang);
                /*this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);*/
            }
        }
        String CNchuyen;
        public void getServer(String index)
        {
            CNchuyen = index;
            if (CNchuyen != Program.serverName)
            {
                String maCN = "";
                if (CNchuyen.Contains("2")) maCN = "CN2";
                else if (CNchuyen.Contains("1")) maCN = "CN1";

                String maNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                Console.WriteLine(maNV);
                Program.con = new SqlConnection(Program.constr);
                Program.con.Open();
                SqlCommand cmd = new SqlCommand("SP_ChuyenCN", Program.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANV", maNV));
                cmd.Parameters.Add(new SqlParameter("@MACN", maCN));
                SqlDataReader myReader = null;
                try
                {
                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("Chuyển nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stack.Push(maNV + "#" + CNchuyen);
                    stack.Push("CHUYENCN");
                    this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                    btnUndo.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Vui lòng chọn CN khác chi nhánh hiện tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnChuyen_Click(object sender, EventArgs e)
        {
            int trangThaiXoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString());
            if (Program.userName == ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString())
            {
                MessageBox.Show("Không thể chuyển nhân viên đang đăng nhập!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (trangThaiXoa == 0)
            {
                FormChuyenCN chuyenCN = new FormChuyenCN();
                chuyenCN.server = new FormChuyenCN.getCN(getServer);
                chuyenCN.ShowDialog();

            }
            else
            {
                MessageBox.Show("Nhân viên hiện không có ở chi nhánh này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            String maNV = "";
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống mã nhân viên!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống Họ!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống tên!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
                return;
            }
            if (txtLuong.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống lương!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuong.Focus();
                return;
            }
            if (float.Parse(txtLuong.Text.Trim()) < 4000000)
            {
                MessageBox.Show("Lương không được dưới 4,000,000!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuong.Focus();
                return;
            }
            if (txtNgaySinh.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống ngày sinh!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgaySinh.Focus();
                return;
            }
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (action == "actThem")
                {
                    //  txtMaNV.Text = txtMaNV.Text.Trim();
                    maNV = txtMaNV.Text.Trim();
                    String query_MANV = "DECLARE @return_value int  EXEC @return_value = [dbo].[SP_KTTrungNV] @MaNV "
                       + "SELECT 'Return Value' = @return_value";
                    SqlCommand sqlCommand = new SqlCommand(query_MANV, Program.con);
                    sqlCommand.Parameters.AddWithValue("@MaNV", maNV);
                    SqlDataReader dataReader = null;
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        dataReader = sqlCommand.ExecuteReader();
                        Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                        return;
                    }
                    // Đọc và lấy result
                    dataReader.Read();
                    int result_value_MANV = int.Parse(dataReader.GetValue(0).ToString());
                    dataReader.Close();
                    // Check ràng buộc MANV

                    if (result_value_MANV == 1)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                try
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = gcNV.Enabled = true;
                    btnReload.Enabled = btnGhi.Enabled = true;
                    btnGhi.Enabled = groupControl1.Enabled = false;

                    this.bdsNV.EndEdit();
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                    stack.Pop();
                    if (action == "actThem")
                    {
                        stack.Push(maNV);
                        stack.Push("INSERT");
                    }
                    else if (action == "actSua")
                    {
                        stack.Push(NVinfo);
                        stack.Push("EDIT");
                    }
                    bdsNV.Position = bdsNV.Position;
                    Cursor = Cursors.Default;

                }

                catch (Exception ex)
                {
                    // Khi Update database lỗi thì xóa record vừa thêm trong bds
                    Cursor = Cursors.Default;
                    bdsNV.RemoveCurrent();
                    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",

                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                String statement = stack.Pop().ToString();
                if (statement.Equals("actThem"))
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = gcNV.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    groupControl1.Enabled = false;
                    bdsNV.RemoveCurrent();
                    bdsNV.Position = vitri;
                }
                if (statement.Equals("actSua"))
                {

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = gcNV.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    groupControl1.Enabled = false;
                    this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                    bdsNV.Position = vitri;
                }
                if (statement.Equals("DELETE"))
                {
                    //btnThem.Enabled = btnXoa.Enabled = nhanVienGridControl.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
                    //btnUndo.Enabled = gcInfoNhanVien.Enabled = btnGhi.Enabled = true;
                    this.bdsNV.AddNew();
                    String info = stack.Pop().ToString();
                    String[] arrinfo = info.Split('#');
                    txtMaNV.Text = arrinfo[0];
                    txtHo.Text = arrinfo[1];
                    txtTen.Text = arrinfo[2];
                    txtMaCN.Text = arrinfo[3];
                    txtNgaySinh.Text = arrinfo[4];
                    txtDiaChi.Text = arrinfo[5];
                    txtLuong.Text = arrinfo[6];
                    cbXoa.Checked = false;
                    this.bdsNV.EndEdit();
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                }
                else if (statement.Equals("INSERT"))
                {
                    String maNV = stack.Pop().ToString();
                    int vitrixoa = bdsNV.Find("MANV", maNV);
                    bdsNV.Position = vitrixoa;
                    bdsNV.RemoveCurrent();
                }
                else if (statement.Equals("EDIT"))
                {
                    String info = stack.Pop().ToString();
                    String[] arrinfo = info.Split('#');
                    txtMaNV.Text = arrinfo[0];
                    txtHo.Text = arrinfo[1];
                    txtTen.Text = arrinfo[2];
                    txtMaCN.Text = arrinfo[3];
                    txtNgaySinh.Text = arrinfo[4];
                    txtDiaChi.Text = arrinfo[5];
                    txtLuong.Text = arrinfo[6];
                    if (arrinfo[7] == "1")
                    {
                        cbXoa.Checked = true;
                    }
                    cbXoa.Checked = false;
                    this.bdsNV.EndEdit();
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                }
                else if (statement.Equals("CHUYENCN"))
                {
                    String info = stack.Pop().ToString();
                    String[] infoCN = info.Split('#');

                    String temp = Program.serverName;

                    Program.serverName = infoCN[1].ToString();

                    Program.mLogin = Program.remoteLogin;
                    Program.passwd = Program.remotePasswd;


                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối", "", MessageBoxButtons.OK);
                    String maNV = infoCN[0].ToString();
                    String maCN = "";
                    if (infoCN[1].ToString().Contains("2")) maCN = "CN1";
                    else if (infoCN[1].ToString().Contains("1")) maCN = "CN2";
                    Program.con = new SqlConnection(Program.constr);
                    Program.con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ChuyenCN", Program.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MANV", maNV));
                    cmd.Parameters.Add(new SqlParameter("@MACN", maCN));
                    SqlDataReader myReader = null;
                    try
                    {
                        myReader = cmd.ExecuteReader();
                        MessageBox.Show("Chuyển nhân viên trở về thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (Program.serverName != temp)
                        {
                            Program.serverName = temp;
                            Program.mLogin = Program.mloginDN;
                            Program.passwd = Program.passwdDN;
                            if (Program.KetNoi() == 0)
                                MessageBox.Show("Lỗi kết nối", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                this.nhanVienTableAdapter.Update(this.DS.NhanVien);
            }
            if (stack.Count == 0) btnUndo.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            action = "actSua";
            NVinfo = txtMaNV.Text.Trim() + "#" + txtHo.Text.Trim() + "#" + txtTen.Text.Trim() + "#" + txtMaCN.Text.Trim() + "#" +
                           txtNgaySinh.Text + "#" + txtDiaChi.Text.Trim() + "#" + txtLuong.Text.Trim();
            if (cbXoa.Checked == true)
            {
                NVinfo += "#1";
            }
            else
            {
                NVinfo += "#0";
            }
            stack.Push(action);
            vitri = bdsNV.Position;
            groupControl1.Enabled = true;
            txtMaCN.Text = maCN;
            cbXoa.Checked = false;
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gcNV.Enabled = txtMaNV.Enabled = txtMaCN.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            txtMaNV.Focus();
        }


    }
}