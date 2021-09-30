using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH
{
    public partial class FormDDH : DevExpress.XtraEditors.XtraForm
    {
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
            DS.EnforceConstraints = false;
            this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);

            this.CTDDHTableAdapter.Connection.ConnectionString = Program.constr;
            this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
 

           

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
                this.CTDDHTableAdapter.Connection.ConnectionString = Program.constr;
                this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
                this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
                this.datHangTableAdapter.Fill(this.DS.DatHang);
              
                //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString();
            }
        }
            private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}