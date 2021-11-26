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
    public partial class FormCTDH : Form
    {
        private int vitri = 0;
        string action = "";
        public FormCTDH()
        {
            InitializeComponent();
        }

        private void cTDDHBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCTDDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormCTDH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.PhieuNhap' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DS.DatHang' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DS.PhieuNhap' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DS.CTPN' table. You can move, or remove it, as needed.


            DS.EnforceConstraints = false;


            this.vattuTableAdapter.Connection.ConnectionString = Program.constr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);
            this.CTDDHTableAdapter.Connection.ConnectionString = Program.constr;
            this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            this.bdsCTDDH.DataSource = Program.ddhForm.getbdsCTDDH();
            if (bdsPN.Find("MasoDDH", FormDDH.MaDDH) != -1)
            {
                panelControl1.Enabled = false;
            }
            btnGhi.Enabled = false;



        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            action = "actThem";
            txtMavtDDH.Visible = false;
            txtMaVT.Visible = true;

            bdsCTDDH.AddNew();

            vitri = bdsCTDDH.Position;
            groupControl1.Enabled = true;
            btnGhi.Enabled = true;
            btnXoa.Enabled = btnThem.Enabled = cTDDHGridControl.Enabled = false;
            txtMavtDDH.Focus();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (action.Equals("actThem"))
            {
                txtMavtDDH.Text = txtMaVT.Text;
                int indexMaVT = bdsCTDDH.Find("MAVT", txtMavtDDH.Text);
                if (indexMaVT != -1)
                {
                    MessageBox.Show("Đã tồn tại mã vật tư trong đơn hàng!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

            }
            txtMavtDDH.Visible = true;
            txtMaVT.Visible = false;
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    this.bdsCTDDH.EndEdit();
                    this.CTDDHTableAdapter.Update(Program.ddhForm.getDataset().CTDDH);
                    MessageBox.Show("Thêm vật tư vào danh sách thành công!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupControl1.Enabled = btnGhi.Enabled = false;
                    btnXoa.Enabled = btnThem.Enabled = true;
                    action = "";
                }
                catch (Exception ex)
                {
                    if (action.Equals("actThem"))
                    {

                    }
                    MessageBox.Show("LỖI!!\n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }


            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            this.CTDDHTableAdapter.Update(Program.ddhForm.getDataset().CTDDH);

        }

        private void FormCTDH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thoát?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (action.Equals("actThem"))
                {
                    bdsCTDDH.RemoveCurrent();
                }

            }
        }
    }
}
