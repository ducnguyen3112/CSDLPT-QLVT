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
    public partial class FormChuyenCN : Form
    {
        public FormChuyenCN()
        {
            InitializeComponent();
        }

        private void FormChuyenCN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSPM.Get_Subscribes' table. You can move, or remove it, as needed.
            this.get_SubscribesTableAdapter.Fill(this.DSPM.Get_Subscribes);
            if (Program.mChiNhanh == 0)
            {
                cbChuyenCN.SelectedIndex = 1;
            }
            if (Program.mChiNhanh == 1)
            {
                cbChuyenCN.SelectedIndex = 0;
            }



        }
        public delegate void getCN(string index);
        public getCN server;
        private void btnChuyen_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            server(cbChuyenCN.SelectedValue.ToString());
            this.Close();
        }
    }
}
