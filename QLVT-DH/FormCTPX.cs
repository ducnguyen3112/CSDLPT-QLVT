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
    public partial class FormCTPX : Form
    {
        private int vitri = 0;
        string action = "";
        public FormCTPX()
        {
            InitializeComponent();
        }

        private void cTPNBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCTPX.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormCTPX_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.CTPX' table. You can move, or remove it, as needed.

            DS.EnforceConstraints = false;
            this.vattuTableAdapter.Connection.ConnectionString = Program.constr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);
            this.CTPXTableAdapter.Connection.ConnectionString = Program.constr;
            this.CTPXTableAdapter.Fill(this.DS.CTPX);
            this.bdsCTPX.DataSource = Program.pxForm.getbdsCTPX();
            txtMavtPX.Visible = true;
            txtMaVT.Visible = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            action = "actThem";
            txtMavtPX.Visible = false;
            txtMaVT.Visible = true;

            bdsCTPX.AddNew();

            vitri = bdsCTPX.Position;
            groupControl1.Enabled = true;
            btnGhi.Enabled = true;
            txtMavtPX.Focus();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (action.Equals("actThem"))
            {
                txtMavtPX.Text = txtMaVT.Text;

            }
            txtMavtPX.Visible = true;
            txtMaVT.Visible = false;
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    this.bdsCTPX.EndEdit();
                    this.CTPXTableAdapter.Update(Program.
                        pxForm.getDataset().CTPX);
                    groupControl1.Enabled = false;
                }
                catch (Exception ex)
                {
                    if (action.Equals("actThem"))
                    {
                        bdsCTPX.RemoveCurrent();
                    }
                    MessageBox.Show("LỖI!!\n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);



                }


            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bdsCTPX.RemoveCurrent();
            this.CTPXTableAdapter.Update(Program.pxForm.getDataset().CTPX);
        }
    }
}
