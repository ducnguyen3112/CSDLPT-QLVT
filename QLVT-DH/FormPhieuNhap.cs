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
    public partial class FormPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        private int vitri;
        private string mavt;
        private string maDDH;
        private int soluong;
        public Stack<String> stackundo = new Stack<string>();
        String query = "";
        private bool isAdd = false;
        Boolean isDel = true;
        private string madhang;
        public FormPhieuNhap()
        {
            InitializeComponent();
        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPN.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }
        private void LoadTable()
        {
            try
            {
                dS.EnforceConstraints = false;

                this.productTableAdapter.Connection.ConnectionString = Program.constr;
                this.productTableAdapter.Fill(this.dS.product);

                this.khoTableAdapter.Connection.ConnectionString = Program.constr;
                this.khoTableAdapter.Fill(this.dS.Kho);

                this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
                this.datHangTableAdapter.Fill(this.dS.DatHang);

                this.dsDDHchuaCoPNTableAdapter.Connection.ConnectionString = Program.constr;
                this.dsDDHchuaCoPNTableAdapter.Fill(this.dS.dsDDHchuaCoPN);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

                this.cTPNTableAdapter.Connection.ConnectionString = Program.constr;
                this.cTPNTableAdapter.Fill(this.dS.CTPN);
                
                madhang = ((DataRowView)bdsPN[bdsPN.Position])["MasoDDH"].ToString();

                if (Program.mGroup == "CONGTY")
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                    btnReload.Enabled = btnThoat.Enabled = true;
                    panelControl2.Enabled = true;
                    gbInfoPN.Enabled = false;
                    contextMenuStrip1.Enabled = false;
                    gridCTPN.Enabled = false;
                }
                else
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    panelControl2.Enabled = false;
                    gbInfoPN.Enabled = false;
                }
                if (stackundo.Count != 0)
                {
                    btnUndo.Enabled = true;
                }
                else btnUndo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
           
            LoadTable();
            /*  if (Program.mGroup != "CONGTY")
               {
                 this.bdsPN.Filter = "MANV='" + Program.username + "'";
                 this.dsDDHchuaCoPNBindingSource.Filter = "MANV='" + Program.username + "'";
               }*/
            if (Program.mGroup != "CONGTY")
            {
                //madhang = ((DataRowView)phieuNhapBindingSource[phieuNhapBindingSource.Position])["MasoDDH"].ToString();
                this.bdsPN.Filter = "MANV='" + Program.userName + "'";
                this.dsDDHchuaCoPNBindingSource.Filter = "MANV='" + Program.userName + "'";
                this.productBindingSource.Filter = "MasoDDH='" + madhang + "'";
            }
            cbChiNhanh.DataSource = Program.bds_dspm.DataSource;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChiNhanh;
            btnGhi.Enabled = false;
        }
        private void EnableButton()
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
        }
        private void DisEnableButton()
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            vitri = bdsPN.Position;
            bdsPN.AddNew();
            DisEnableButton();
            gbInfoPN.Enabled = true;
            txtMaNv.Text = Program.userName;
            ngay.Text = DateTime.Now.ToString().Substring(0, 10);
            txtMaNv.Enabled = ngay.Enabled = false;
            isAdd = true;
            isDel = true;
            txtMaPN.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (gbInfoPN.Enabled)
            {
                if (MessageBox.Show("Chưa lưu dữ liệu vào dataSet. Thoát dữ liệu sẽ bị mất", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            gbInfoPN.Enabled = true;
            vitri = bdsPN.Position;
            txtMaPN.Enabled = txtMaNv.Enabled = ngay.Enabled = false;
            isDel = false;
            query = String.Format("Update PhieuNhap Set NGAY=N'{1}', MasoDDH=N'{2}', MANV={3}, MAKHO=N'{4}' Where MAPN=N'{0}' ", txtMaPN.Text, ngay.Text, cbDDH.Text, Program.userName, cbMaKho.Text);
            DisEnableButton();
            isAdd = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Phiếu Nhập đã có Chi Tiết Phiếu Nhập nên không thể xóa !", "", MessageBoxButtons.OK);
                return;
            }
            else if (MessageBox.Show("Bạn thực sự muốn xóa ??", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mapn = ((DataRowView)bdsPN[bdsPN.Position])["MAPN"].ToString();
                    String ngay = ((DataRowView)bdsPN[bdsPN.Position])["NGAY"].ToString();
                    String masoddh = ((DataRowView)bdsPN[bdsPN.Position])["MasoDDH"].ToString();
                    String makho = ((DataRowView)bdsPN[bdsPN.Position])["MAKHO"].ToString();

                    bdsPN.RemoveCurrent();
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
                    this.phieuNhapTableAdapter.Update(this.dS.PhieuNhap);
                    query = String.Format("Insert into PhieuNhap (MAPN, NGAY, MasoDDH, MANV, MAKHO) values(N'{0}', N'{1}', N'{2}',{3},N'{4}' )", mapn, ngay, masoddh, Program.userName, makho);
                    stackundo.Push(query);
                    LoadTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa phiếu nhập. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
                    return;
                }

            }
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
        private int kiemTraTonTai(String mapn)
        {
            int result = 1;
            String lenh = String.Format("EXEC SP_TIMPHIEUNHAP {0}", mapn);
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
                return result;
            }

        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {

                if (kiemTraTonTai(txtMaPN.Text.Trim()) == 1)
                {
                    MessageBox.Show("Mã Phiếu Nhập không được trùng !", "", MessageBoxButtons.OK);
                    txtMaPN.Focus();
                    return;
                }

                if (txtMaPN.Text == string.Empty)
                {
                    MessageBox.Show("Mã Phiếu Nhập không được thiếu !", "", MessageBoxButtons.OK);
                    txtMaPN.Focus();
                    return;
                }

                if (txtMaPN.Text.Length > 8)
                {
                    MessageBox.Show("Mã Phiếu Nhập không được hơn 8 ký tự !", "", MessageBoxButtons.OK);
                    txtMaPN.Focus();
                    return;
                }
            }

            if (cbDDH.Text == string.Empty)
            {
                MessageBox.Show("Mã Đơn Đặt Hàng không được thiếu !", "", MessageBoxButtons.OK);
                return;
            }
            if (cbMaKho.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Mã kho không được trống !", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                bdsPN.EndEdit();
                bdsPN.ResetCurrentItem();
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuNhapTableAdapter.Update(this.dS.PhieuNhap);
                if (isDel == true)
                {
                    query = String.Format("delete from PhieuNhap where MAPN = N'{0}'", txtMaPN.Text);
                }
                stackundo.Push(query);
                MessageBox.Show("Ghi thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi Phiếu nhập .\n" + ex.Message);
                return;
            }
            ctmsThemCTPN.Enabled = true;
            btnXoaCTPN.Enabled = true;
            btnGhiCTPN.Enabled = false;
            LoadTable();
            gbInfoPN.Enabled = false;
        }

        private void ctmsThemCTPN_Click(object sender, EventArgs e)
        {
            bdsCTPN.AddNew();
            btnGhiCTPN.Enabled = true;
            ctmsThemCTPN.Enabled = btnXoaCTPN.Enabled = false;

        }

      

      
       
        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
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
                MessageBox.Show("Loi ket noi ve chi nhanh.", "", MessageBoxButtons.OK);
            }
            else
            {
                LoadTable();
            }
        }
        
        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn xóa ??", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    bdsCTPN.RemoveCurrent();

                    this.cTPNTableAdapter.Connection.ConnectionString = Program.constr;
                    this.cTPNTableAdapter.Update(this.dS.CTPN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa chi tiết phiếu nhập. Bạn hãy xóa lại \n", ex.Message, MessageBoxButtons.OK);
                    this.cTPNTableAdapter.Fill(this.dS.CTPN);
                    return;
                }
            }
        }
        private bool KtraVattuTrenView(string maVT)
        {
            for (int index = 0; index < bdsCTPN.Count - 1; index++)
            {
                if (((DataRowView)bdsCTPN[index])["MAVT"].ToString().Equals(maVT))
                {
                    return false;
                }
            }
            return true;
        }
        private int ktctddh(string maddh, string mavt)
        {
            int result = 1;
            string lenh = string.Format("EXEC SP_TIMCTDDH {0},{1}", maddh, mavt);
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
                return result;
            }
        }
        private int ktSoLuongdathang(string maDDH, string maVT, int sluong)
        {
            int result = 1; // thoa
            string lenh = string.Format("EXEC SP_KIEMTRASOLUONGVATTU {0}, {1}, {2}", maDDH, maVT, sluong);
            using (SqlConnection connection = new SqlConnection(Program.constr))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(lenh, connection);
                sqlCommand.CommandType = CommandType.Text;
                try
                {
                    //SqlDataReader reader = sqlCommand.ExecuteReader();
                    //string kq = "";
                    //while (reader.Read())
                    //{
                    //    kq = (string)reader["SOLUONG"];
                    //}

                    //if (kq.Length == 0)
                    //{
                    //    result = 0;
                    //}
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    result = 0;
                    MessageBox.Show(ex.Message + " ");
                }
            }
            return result;
        }
        private void btnGhiCTPN_Click(object sender, EventArgs e)
        {
            btnXoaCTPN.Enabled = ctmsThemCTPN.Enabled = true;
            mavt = ((DataRowView)bdsCTPN[bdsCTPN.Count - 1])["MAVT"].ToString();
            maDDH = ((DataRowView)phieuNhapBindingSource[phieuNhapBindingSource.Position])["MasoDDH"].ToString();
            if (mavt == string.Empty)
            {
                MessageBox.Show("Vật tư không thể thiếu ! ", "", MessageBoxButtons.OK);
                ctmsThemCTPN.Enabled = false;
                btnXoaCTPN.Enabled = false;
                return;
            }

            if (KtraVattuTrenView(mavt) == false)
            {
                MessageBox.Show("Vật tư đã được nhập ! ", "", MessageBoxButtons.OK);
                //cTPNBindingSource.RemoveCurrent();
                ctmsThemCTPN.Enabled = false;
                btnXoaCTPN.Enabled = false;
                return;
            }

            if (ktctddh(maDDH, mavt) == 0)
            {
                MessageBox.Show("Vật tư không có trong đơn đặt hàng ! ", "", MessageBoxButtons.OK);
                ctmsThemCTPN.Enabled = false;
                btnXoaCTPN.Enabled = false;
                return;
            }

            if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SOLUONG").ToString() == string.Empty)
            {
                MessageBox.Show("Số lượng không thể thiếu! ", "", MessageBoxButtons.OK);
                ctmsThemCTPN.Enabled = false;
                btnXoaCTPN.Enabled = false;
                return;
            }

            soluong = int.Parse((gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SOLUONG").ToString()));

            if (soluong < 0)
            {
                MessageBox.Show("Số lượng không thể âm ! ", "", MessageBoxButtons.OK);
                ctmsThemCTPN.Enabled = false;
                btnXoaCTPN.Enabled = false;
                return;
            }
            if (ktSoLuongdathang(maDDH, mavt, soluong) == 0)
            {
                MessageBox.Show("Số lượng nhập không được hơn số lượng đã đặt !", "", MessageBoxButtons.OK);
                ctmsThemCTPN.Enabled = false;
                btnXoaCTPN.Enabled = false;
                return;
            }

            if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DONGIA").ToString() == string.Empty)
            {
                MessageBox.Show("Đơn giá không được thiếu !", "", MessageBoxButtons.OK);
                ctmsThemCTPN.Enabled = false;
                btnXoaCTPN.Enabled = false;
                return;
            }

            try
            {
                bdsCTPN.EndEdit();
                bdsCTPN.ResetCurrentItem();


                MessageBox.Show("Ghi thành công !!!");

                this.cTPNTableAdapter.Connection.ConnectionString = Program.constr;
                this.cTPNTableAdapter.Update(this.dS.CTPN);
            }
            catch (Exception) { }
            EnableButton();
            LoadTable();
            btnGhiCTPN.Enabled = false;
        }
    }
}