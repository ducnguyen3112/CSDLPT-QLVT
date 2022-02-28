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
    public partial class FormDDH : DevExpress.XtraEditors.XtraForm
    {

        Stack stack = new Stack();
        String action = "";
        int vitri = 0;
        String DDHinfo = "";
        string maDDHtemp = "";
        public static string MaDDH;
        public FormDDH()
        {
            InitializeComponent();
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormDDH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.CTPN' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DS.PhieuNhap' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DS.Kho' table. You can move, or remove it, as needed.

            DS.EnforceConstraints = false;
            this.khoTableAdapter.Connection.ConnectionString = Program.constr;
            this.khoTableAdapter.Fill(this.DS.Kho);
            this.datHangTableAdapter.Connection.ConnectionString = Program.constr;

            this.datHangTableAdapter.Fill(this.DS.DatHang);
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;

            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            this.CTDDHTableAdapter.Connection.ConnectionString = Program.constr;
            this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
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
            btnUndo.Enabled = btnGhi.Enabled = gbDDH.Enabled = false;
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Trường hợp chưa kịp chọn CN, thuộc tính index ở combobox sẽ thay đổi
            // "System.Data.DataRowView" sẽ xuất hiện và tất nhiên hệ thống sẽ không thể
            // nhận diện được tên server "System.Data.DataRowView".
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
                this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
                this.datHangTableAdapter.Fill(this.DS.DatHang);
                this.CTDDHTableAdapter.Connection.ConnectionString = Program.constr;
                this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
                //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString();
            }
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            action = "actThem";
            stack.Push(action);
            vitri = bdsDH.Position;
            groupControl1.Enabled = true;
            bdsDH.AddNew();
            txtngaylap.EditValue = "";
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gridDonDatHang.Enabled = btnSua.Enabled = gridCTDDH.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = gbDDH.Enabled = true;
            txtMaDDH.Focus();
            txtMaNV.Text = Program.userName;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Program.userName != ((DataRowView)bdsDH[bdsDH.Position])["MANV"].ToString())
            {
                MessageBox.Show("Không thể xoá đơn đặt hàng của các nhân viên khác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xoá đơn đặt hàng đã có CTDH.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xoá đơn đặt hàng đã có đơn nhập hàng.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult mess = MessageBox.Show("Bạn có thực sự muốn xóa đơn đặt hàng này không?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mess == DialogResult.Yes)
            {
                try
                {
                    DDHinfo = txtMaDDH.Text.Trim() + "#" + txtNhaCC.Text.Trim() + "#" + cbKho.SelectedValue.ToString().Trim() + "#" + txtngaylap.Text.Trim() + "#" + txtMaNV.Text.Trim();
                    maDDHtemp = txtMaDDH.Text.Trim();
                    vitri = bdsDH.Position;
                    bdsDH.RemoveCurrent();
                    btnUndo.Enabled = true;
                    stack.Push(DDHinfo);
                    stack.Push("DELETE");
                    this.datHangTableAdapter.Update(this.DS.DatHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.datHangTableAdapter.Fill(this.DS.DatHang);
                    bdsDH.Position = vitri;
                    return;
                }
            }
        }
        private void gridCTDDH_DoubleClick(object sender, EventArgs e)
        {
            MaDDH = ((DataRowView)bdsCTDDH[bdsCTDDH.Position])[0].ToString().Trim();
            if (txtMaNV.Text == Program.userName)
            {
                Program.ctdhForm = new FormCTDH();
                Program.ctdhForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa đơn đặt hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        public BindingSource getbdsCTDDH()
        {
            return this.bdsCTDDH;
        }

        public DS getDataset()
        {
            return this.DS;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

            String maDDH = "";
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống mã nhân viên!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtMaDDH.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống mã đơn đặt hàng!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDDH.Focus();
                return;
            }
            if (txtngaylap.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống ngày lập!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtngaylap.Focus();
                return;
            }
            if (txtNhaCC.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống nhà cung cấp!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNhaCC.Focus();
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
                    maDDH = txtMaDDH.Text.Trim();
                    String query = "DECLARE @return_value int  EXEC @return_value = [dbo].[SP_KTTrungDDH_L] @MADDH "
                       + "SELECT 'Return Value' = @return_value";
                    SqlCommand sqlCommand = new SqlCommand(query, Program.con);
                    sqlCommand.Parameters.AddWithValue("@MADDH", maDDH);
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
                    if (result_value == 1 || maDDH.Equals(maDDHtemp))
                    {
                        MessageBox.Show("Mã đơn đặt hàng đã tồn tại!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                try
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = gridDonDatHang.Enabled = gridCTDDH.Enabled = true;
                    btnReload.Enabled = btnGhi.Enabled = true;
                    txtMK.Text = cbKho.SelectedValue.ToString();
                    btnGhi.Enabled = gbDDH.Enabled = false; this.bdsDH.EndEdit();
                    this.datHangTableAdapter.Update(this.DS.DatHang);
                    stack.Pop();
                    if (action == "actThem")
                    {
                        stack.Push(maDDH);
                        stack.Push("INSERT");
                        if (MessageBox.Show("Thêm vật tư vào đơn đặt hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Program.ctdhForm = new FormCTDH();
                            Program.ctdhForm.ShowDialog();
                        }
                    }
                    else if (action == "actSua")
                    {
                        //stack.Push();
                        stack.Push("EDIT");
                    }
                    bdsDH.Position = bdsDH.Position;

                }
                catch (Exception ex)
                {
                    if (action.Equals("actThem"))
                    {
                        bdsDH.RemoveCurrent();

                    }
                    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",

                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Program.userName.Equals(((DataRowView)bdsDH[bdsDH.Position])["MANV"].ToString().Trim()))
            {
                action = "actSua";
                DDHinfo = txtMaDDH.Text.Trim() + "#" + txtNhaCC.Text.Trim() + "#" + cbKho.SelectedValue.ToString().Trim() + "#" + txtngaylap.Text.Trim() + "#" + txtMaNV.Text.Trim();
                stack.Push(DDHinfo);
                stack.Push(action);
                vitri = bdsDH.Position;
                gbDDH.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gridDonDatHang.Enabled = txtMaNV.Enabled = false;
                btnGhi.Enabled = btnUndo.Enabled = gbDDH.Enabled = true;
                txtMaDDH.Focus();
            }
            else
            {
                MessageBox.Show("Không thể chỉnh sửa đơn hàng của các nhân viên khác!", "Message",

                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                String statement = stack.Pop().ToString();
                if (statement.Equals("actThem"))
                {
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = gridDonDatHang.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    gbDDH.Enabled = false;
                    bdsDH.RemoveCurrent();
                    bdsDH.Position = vitri;
                }
                else if (statement.Equals("actSua"))
                {

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = gridDonDatHang.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    gbDDH.Enabled = false;
                    this.datHangTableAdapter.Fill(this.DS.DatHang);
                    bdsDH.Position = vitri;
                }
                else if (statement.Equals("DELETE"))
                {
                    //btnThem.Enabled = btnXoa.Enabled = nhanVienGridControl.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
                    //btnUndo.Enabled = gcInfoNhanVien.Enabled = btnGhi.Enabled = true;
                    this.bdsDH.AddNew();
                    String info = stack.Pop().ToString();
                    String[] arrinfo = info.Split('#');
                    txtMaDDH.Text = arrinfo[0];
                    txtNhaCC.Text = arrinfo[1];
                    txtMK.Text = arrinfo[2];
                    cbKho.SelectedItem = txtMK.Text;
                    txtngaylap.Text = arrinfo[3];
                    txtMaNV.Text = arrinfo[4];

                    //this.bdsDH.EndEdit();
                    //this.datHangTableAdapter.Update(this.DS.DatHang);
                }
                else if (statement.Equals("INSERT"))
                {
                    if (bdsCTDDH.Count > 0)
                    {
                        MessageBox.Show("Không thể Undo vì bạn đã thêm vật tư vào đơn đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stack.Pop();
                        return;
                    }
                    
                    String maDDH = stack.Pop().ToString();
                    int vitrixoa = bdsDH.Find("MasoDDH", maDDH);
                    bdsDH.Position = vitrixoa;
                    bdsDH.RemoveCurrent();
                }
                else if (statement.Equals("EDIT"))
                {
                    String info = stack.Pop().ToString();
                    String[] arrinfo = info.Split('#');
                    txtMaDDH.Text = arrinfo[0];
                    txtNhaCC.Text = arrinfo[1];
                    txtMK.Text = arrinfo[2];
                    txtngaylap.Text = arrinfo[3];
                    txtMaNV.Text = arrinfo[4];
                    cbKho.SelectedItem = txtMK.Text;
                    this.bdsDH.EndEdit();
                    //this.datHangTableAdapter.Update(this.DS.DatHang);
                }
                this.bdsDH.EndEdit();
                this.datHangTableAdapter.Update(this.DS.DatHang);

            }
            if (stack.Count == 0) btnUndo.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.datHangTableAdapter.Fill(this.DS.DatHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }

}