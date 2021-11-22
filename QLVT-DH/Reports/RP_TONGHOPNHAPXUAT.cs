using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_DH.Reports
{
    public partial class RP_TONGHOPNHAPXUAT : DevExpress.XtraReports.UI.XtraReport
    {
        public RP_TONGHOPNHAPXUAT(string bd, string kt)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.constr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = bd;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = kt;
            this.sqlDataSource1.Fill();
        }

    }
}
