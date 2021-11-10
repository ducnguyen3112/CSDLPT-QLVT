using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_DH.Reports
{
    public partial class RP_DSNV : DevExpress.XtraReports.UI.XtraReport
    {
        public RP_DSNV()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.constr;
            this.sqlDataSource1.Fill();
        }

    }
}
 