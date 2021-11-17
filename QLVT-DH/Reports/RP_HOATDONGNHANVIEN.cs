using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace QLVT_DH.Reports
{
    public partial class RP_HOATDONGNHANVIEN : DevExpress.XtraReports.UI.XtraReport
    {
        private int maNV;
        private DateTime from;
        private DateTime to;
        private String type;
        public RP_HOATDONGNHANVIEN(int maNV, DateTime from, DateTime to, String type)
        {
            this.maNV = maNV;
            this.from = from;
            this.to = to;
            this.type = type;
            InitializeComponent();
        }

        private void RP_HOATDONGNHANVIEN_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            sP_RP_HOATDONGCUANHANVIENTableAdapter1.Connection.ConnectionString = Program.constr;

            String query = "EXEC SP_RP_HoatDongCuaNhanVien @p1, @p2, @p3, @p4";
            SqlCommand sqlCommand = new SqlCommand(query, Program.con);
            sqlCommand.Parameters.AddWithValue("@p1", this.maNV);
            sqlCommand.Parameters.AddWithValue("@p2", this.from);
            sqlCommand.Parameters.AddWithValue("@p3", this.to);
            sqlCommand.Parameters.AddWithValue("@p4", this.type);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.DataSource = dataTable;    //Lưu ý DataSource, DataMember, DataAdapter bên Design phải để None
        }
    }
}
