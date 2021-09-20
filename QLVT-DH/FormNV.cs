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

            DS.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.constr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.constr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

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
                btnThem.Enabled = btnXoa.Enabled = false;
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
            stack.Push("btnThemAction");
            vitri = bdsNV.Position;
            groupControl1.Enabled = true;
            bdsNV.AddNew();
            txtMaCN.Text = maCN;
            txtNgaySinh.EditValue = "";
            cbXoa.Checked = false;
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gcNV.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            txtMaNV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = "";

            if (cbXoa.Checked == true)
            {
                MessageBox.Show("Nhân viên đã bị xóa, đang ở chi nhánh khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập đơn đặt hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập phiếu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPX.Count > 0)
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
                    String NV_info = txtMaNV.Text.Trim() + "#" + txtHo.Text.Trim() + "#" + txtTen.Text.Trim() + "#" + txtMaCN.Text.Trim() + "#" +
                            txtNgaySinh.Text + "#" + txtDiaChi.Text.Trim() + "#" + txtLuong.Text.Trim();
                    Console.WriteLine(NV_info);
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
                        stack.Push(NV_info);
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
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.constr;
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
                this.datHangTableAdapter.Fill(this.DS.DatHang);
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            int trangThaiXoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString());
            if (trangThaiXoa == 0)
            {
                FormChuyenCN chuyenCN = new FormChuyenCN();
                chuyenCN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nhân viên hiện không có ở chi nhánh này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
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
                txtMaNV.Text = txtMaNV.Text.Trim();
                String maNV = txtMaNV.Text;
                String query_MANV = "DECLARE @return_value int  EXEC @return_value = [dbo].[SP_KTTrungNV] @MaNV "
                   + "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MANV, Program.con);
                sqlCommand.Parameters.AddWithValue("@MaNV", maNV);
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
                int result_value_MANV = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();
                // Check ràng buộc MANV

                if (result_value_MANV == 1)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    try
                    {
                        //Program.flagCloseFormKho = true; //Bật cờ cho phép tắt Form NV
                        btnThem.Enabled = btnXoa.Enabled = gcNV.Enabled = true;
                        btnReload.Enabled = btnGhi.Enabled = true;
                        btnGhi.Enabled = groupControl1.Enabled = false;

                        this.bdsNV.EndEdit();
                        this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                        stack.Push(maNV);
                        stack.Push("INSERT");
                        bdsNV.Position = bdsNV.Position;
                    }
                    catch (Exception ex)
                    {
                        // Khi Update database lỗi thì xóa record vừa thêm trong bds
                        bdsNV.RemoveCurrent();
                        MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                String statement = stack.Pop().ToString();
                if (statement.Equals("btnThemAction"))
                {

                    gcNV.Enabled = true;
                    this.bdsNV.RemoveCurrent();
                    bdsNV.CancelEdit();

                    if (btnThem.Enabled == false)
                    {
                        bdsNV.Position = vitri;
                    }
                    groupControl1.Enabled = false;
                    btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = false;

                }
                if (statement.Equals("DELETE"))
                {
                    //btnThem.Enabled = btnXoa.Enabled = nhanVienGridControl.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
                    //btnUndo.Enabled = gcInfoNhanVien.Enabled = btnGhi.Enabled = true;
                    this.bdsNV.AddNew();
                    String TT = stack.Pop().ToString();
                    String[] TT_NV = TT.Split('#');
                    txtMaNV.Text = TT_NV[0];
                    txtHo.Text = TT_NV[1];
                    txtTen.Text = TT_NV[2];
                    txtMaCN.Text = TT_NV[3];
                    txtNgaySinh.Text = TT_NV[4];
                    txtDiaChi.Text = TT_NV[5];
                    txtLuong.Text = TT_NV[6];
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
                else if (statement.Equals("CHUYENCN"))
                {
                    String info = stack.Pop().ToString();
                    String[] info_CN = info.Split('#');
                    Console.WriteLine(info_CN[0] + " " + info_CN[1]);
                    String servername_temp = Program.serverName;

                    Program.serverName = info_CN[1].ToString();

                    Program.mLogin = Program.remoteLogin;
                    Program.passwd = Program.remotePasswd;


                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối", "", MessageBoxButtons.OK);
                    String maNV = info_CN[0].ToString();
                    String maCN = "";
                    if (info_CN[1].ToString().Contains("2")) maCN = "CN1";
                    else if (info_CN[1].ToString().Contains("1")) maCN = "CN2";
                    Program.con = new SqlConnection(Program.constr);
                    Program.con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CHUYENCHINHANH_NV", Program.con);
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
                        if (Program.serverName != servername_temp)
                        {
                            Program.serverName = servername_temp;
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
    }
}