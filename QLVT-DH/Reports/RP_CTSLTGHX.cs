using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_DH.Reports
{
    public partial class RP_CTSLTGHX : DevExpress.XtraReports.UI.XtraReport
    {
        public RP_CTSLTGHX()
        {
            InitializeComponent();
        }
        public RP_CTSLTGHX(DateTime date1, DateTime date2, string group)
        {
            InitializeComponent();
            lbTu.Text = date1.ToString("dd/MM/yyyy");
            lbDen.Text = date2.ToString("dd/MM/yyyy");
            this.sqlDataSource1.Connection.ConnectionString = Program.constr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = date1.ToString("yyyy-MM-dd");
            this.sqlDataSource1.Queries[0].Parameters[1].Value = date2.ToString("yyyy-MM-dd");
            this.sqlDataSource1.Queries[0].Parameters[2].Value = group;
            this.sqlDataSource1.Fill();

        }

    }
}
