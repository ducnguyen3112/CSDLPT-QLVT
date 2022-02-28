using System;
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
    public partial class FormCTPX : Form
    {
        private int vitri = 0;
        //private int soluong = 0;
        //private string mavt;
        //String loaiphieu = "X";
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
            btnGhi.Enabled = false;
            txtMavtPX.Visible = true;
            txtMaVT.Visible = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnGhi.Enabled = true;
            action = "actThem";
            txtMavtPX.Visible = false;
            txtMaVT.Visible = true;

            bdsCTPX.AddNew();

            vitri = bdsCTPX.Position;
            groupControl1.Enabled = btnGhi.Enabled = true;
            btnXoa.Enabled = btnThem.Enabled = false;
            txtMavtPX.Focus();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (action.Equals("actThem"))
            {
                txtMavtPX.Text = txtMaVT.Text;
                int indexMaVT = bdsCTPX.Find("MAVT", txtMavtPX.Text);

                if (indexMaVT != -1)
                {
                    MessageBox.Show("Đã tồn tại mã vật tư trong đơn hàng!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if ((int)spinSL.Value > int.Parse(((DataRowView)bdsVT[bdsVT.Position])["SOLUONGTON"].ToString()))
                {
                    MessageBox.Show("Đã vượt quá số lượng tồn!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }           
            txtMavtPX.Visible = true;
            txtMaVT.Visible = false;            
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    string maVT = txtMaVT.Text;
                    int soLuong = (int)spinSL.Value;
                    this.bdsCTPX.EndEdit();
                    this.CTPXTableAdapter.Update(Program.
                        pxForm.getDataset().CTPX);
                    String query = "DECLARE	@return_value int " +
                                       "EXEC @return_value = [dbo].[SP_UpdateExportSLVT] " +
                                       "@p1, @p2" +
                                       " SELECT 'ReturnValue' = @return_value";
                    SqlCommand sqlCommand = new SqlCommand(query, Program.con);
                    sqlCommand.Parameters.AddWithValue("@p1", maVT);
                    sqlCommand.Parameters.AddWithValue("@p2", soLuong);
                    SqlDataReader dataReader = null;

                    try
                    {
                        dataReader = sqlCommand.ExecuteReader();
                        dataReader.Read();
                        this.vattuTableAdapter.Connection.ConnectionString = Program.constr;
                        this.vattuTableAdapter.Fill(this.DS.Vattu);
                        if (int.Parse(dataReader.GetValue(0).ToString()) == 0)
                        {
                            MessageBox.Show("Lỗi khi cập nhật số lượng vật tư!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Thêm vật tư vào danh sách thành công!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnXoa.Enabled = btnThem.Enabled = true;
                            action = "";
                            dataReader.Close();

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật số lượng vật tư!\n" + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        dataReader.Close();
                        return;
                    }
                    groupControl1.Enabled = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("LỖI!!\n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);



                }


            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bdsCTPX.RemoveCurrent();
            this.CTPXTableAdapter.Update(Program.pxForm.getDataset().CTPX);
        }

        private void FormCTPX_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (MessageBox.Show("Thoát?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (action.Equals("actThem"))
                {
                    bdsCTPX.RemoveCurrent();
                }

            }
        }
    }
}
