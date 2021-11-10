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
    public partial class FormPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        Stack stack = new Stack();
        String action = "";
        int vitri = 0;
        String PXinfo = "";
        string maPXtemp = "";
        public BindingSource getbdsCTPX()
        {
            return this.bdsCTPX;
        }
        public DS getDataset()
        {
            return this.DS;
        }
        public FormPhieuXuat()
        {
            InitializeComponent();
        }

        private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPX.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormPhieuXuat_Load(object sender, EventArgs e)
        {


            DS.EnforceConstraints = false;
            this.khoTableAdapter.Connection.ConnectionString = Program.constr;
            this.khoTableAdapter.Fill(this.DS.Kho);
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.constr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
            this.CTPXTableAdapter.Connection.ConnectionString = Program.constr;
            this.CTPXTableAdapter.Fill(this.DS.CTPX);
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChiNhanh;
            cbKho.DataSource = khoTableAdapter.GetData();
            cbKho.DisplayMember = "MAKHO";
            cbKho.ValueMember = "MAKHO";
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
            btnUndo.Enabled = btnGhi.Enabled = gbPX.Enabled = false;
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (cbChiNhanh.SelectedValue.ToString() == null) return;

            // Lấy tên server
            Program.serverName = cbChiNhanh.SelectedValue.ToString();

            // Nếu tên server khác với tên server ngoài đăng nhập, thì ta phải sử dụng HTKN
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
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
                this.CTPXTableAdapter.Connection.ConnectionString = Program.constr;
                this.CTPXTableAdapter.Fill(this.DS.CTPX);
                //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            action = "actThem";
            stack.Push(action);
            vitri = bdsPX.Position;
            groupControl1.Enabled = true;
            bdsPX.AddNew();
            txtNgay.EditValue = "";
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gridPhieuXuat.Enabled = btnSua.Enabled = gridCTPX.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = gbPX.Enabled = true;
            txtMaPX.Focus();
            txtMaNV.Text = Program.userName;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Program.userName != ((DataRowView)bdsPX[bdsPX.Position])["MANV"].ToString())
            {
                MessageBox.Show("Không thể xoá phiếu xuất của các nhân viên khác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xoá phiếu xuất đã có CTPX.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult mess = MessageBox.Show("Bạn có thực sự muốn xóa phiếu xuất này không?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mess == DialogResult.Yes)
            {
                try
                {
                    PXinfo = txtMaPX.Text.Trim() + "#" + txtKhach.Text.Trim() + "#" + cbKho.SelectedValue.ToString().Trim() + "#" + txtNgay.Text.Trim() + "#" + txtMaNV.Text.Trim();
                    maPXtemp = txtMaPX.Text.Trim();
                    vitri = bdsPX.Position;
                    bdsPX.RemoveCurrent();
                    btnUndo.Enabled = true;
                    stack.Push(PXinfo);
                    stack.Push("DELETE");
                    this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);
                    bdsPX.Position = vitri;
                    return;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Program.userName.Equals(((DataRowView)bdsPX[bdsPX.Position])["MANV"].ToString().Trim()))
            {
                action = "actSua";
                PXinfo = txtMaPX.Text.Trim() + "#" + txtKhach.Text.Trim() + "#" + cbKho.SelectedValue.ToString().Trim() + "#" + txtNgay.Text.Trim() + "#" + txtMaNV.Text.Trim();
                stack.Push(PXinfo);
                stack.Push(action);
                vitri = bdsPX.Position;
                gbPX.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gridPhieuXuat.Enabled = txtMaNV.Enabled = false;
                btnGhi.Enabled = btnUndo.Enabled = gbPX.Enabled = true;
                txtMaPX.Focus();
            }
            else
            {
                MessageBox.Show("Không thể chỉnh sửa phiếu xuất của các nhân viên khác!", "Message",

                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

            String maPX = "";
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống mã nhân viên!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtMaPX.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống mã  phiếu xuất!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPX.Focus();
                return;
            }
            if (txtNgay.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống ngày lập!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgay.Focus();
                return;
            }
            if (txtKhach.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống họ tên của khách hàng!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKhach.Focus();
                return;
            }
            if (cbKho.SelectedValue.ToString().Equals(""))
            {
                MessageBox.Show("Xin hãy chọn kho!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbKho.Focus();
                return;
            }
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (action == "actThem")
                {
                    maPX = txtMaPX.Text.Trim();
                    String query = "DECLARE @return_value int  EXEC @return_value = [dbo].[SP_KTTrungPX] @MAPX "
                       + "SELECT 'Return Value' = @return_value";
                    SqlCommand sqlCommand = new SqlCommand(query, Program.con);
                    sqlCommand.Parameters.AddWithValue("@MAPX", maPX);
                    SqlDataReader dataReader = null;

                    try
                    {
                        dataReader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                        return;
                    }
                    dataReader.Read();
                    int result_value = int.Parse(dataReader.GetValue(0).ToString());
                    dataReader.Close();
                    if (result_value == 1 || maPX.Equals(maPXtemp))
                    {
                        MessageBox.Show("Mã  phiếu xuất đã tồn tại!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                try
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = gridPhieuXuat.Enabled = gridCTPX.Enabled = true;
                    btnReload.Enabled = btnGhi.Enabled = true;
                    txtMK.Text = cbKho.SelectedValue.ToString();
                    btnGhi.Enabled = gbPX.Enabled = false; this.bdsPX.EndEdit();
                    this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);
                    stack.Pop();
                    if (action == "actThem")
                    {
                        stack.Push(maPX);
                        stack.Push("INSERT");
                        if (MessageBox.Show("Thêm vật tư vào  phiếu xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Program.ctpxForm = new FormCTPX();
                            Program.ctpxForm.ShowDialog();
                        }
                    }
                    else if (action == "actSua")
                    {
                        //stack.Push();
                        stack.Push("EDIT");
                    }
                    bdsPX.Position = bdsPX.Position;

                }
                catch (Exception ex)
                {
                    if (action.Equals("actThem"))
                    {
                        bdsPX.RemoveCurrent();

                    }
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
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = gridPhieuXuat.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    gbPX.Enabled = false;
                    bdsPX.RemoveCurrent();
                    bdsPX.Position = vitri;
                }
                else if (statement.Equals("actSua"))
                {

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = gridPhieuXuat.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    gbPX.Enabled = false;
                    this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
                    bdsPX.Position = vitri;
                }
                else if (statement.Equals("DELETE"))
                {
                    //btnThem.Enabled = btnXoa.Enabled = nhanVienGridControl.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
                    //btnUndo.Enabled = gcInfoNhanVien.Enabled = btnGhi.Enabled = true;
                    this.bdsPX.AddNew();
                    String info = stack.Pop().ToString();
                    String[] arrinfo = info.Split('#');
                    txtMaPX.Text = arrinfo[0];
                    txtKhach.Text = arrinfo[1];
                    txtMK.Text = arrinfo[2];
                    cbKho.SelectedItem = txtMK.Text;
                    txtNgay.Text = arrinfo[3];
                    txtMaNV.Text = arrinfo[4];

                    //this.bdsDH.EndEdit();
                    //this.datHangTableAdapter.Update(this.DS.DatHang);
                }
                else if (statement.Equals("INSERT"))
                {
                    if (bdsCTPX.Count > 0)
                    {
                        MessageBox.Show("Không thể Undo vì bạn đã thêm vật tư vào phiếu xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stack.Pop();
                        return;
                    }

                    String maPX = stack.Pop().ToString();
                    int vitrixoa = bdsPX.Find("MAPX", maPX);
                    bdsPX.Position = vitrixoa;
                    bdsPX.RemoveCurrent();
                }
                else if (statement.Equals("EDIT"))
                {
                    String info = stack.Pop().ToString();
                    String[] arrinfo = info.Split('#');
                    txtMaPX.Text = arrinfo[0];
                    txtKhach.Text = arrinfo[1];
                    txtMK.Text = arrinfo[2];
                    txtNgay.Text = arrinfo[3];
                    txtMaNV.Text = arrinfo[4];
                    cbKho.SelectedItem = txtMK.Text;
                    this.bdsPX.EndEdit();
                    //this.datHangTableAdapter.Update(this.DS.DatHang);
                }
                this.bdsPX.EndEdit();
                this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);

            }
            if (stack.Count == 0) btnUndo.Enabled = false;
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridCTPX_DoubleClick(object sender, EventArgs e)
        {

            if (txtMaNV.Text == Program.userName)
            {
                Program.ctpxForm = new FormCTPX();
                Program.ctpxForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa phiếu xuất này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}