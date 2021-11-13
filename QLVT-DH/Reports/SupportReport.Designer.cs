
namespace QLVT_DH.Reports
{
    partial class SupportReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.get_SubscribesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSPM = new QLVT_DH.DSPM();
            this.lb = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.get_SubscribesTableAdapter = new QLVT_DH.DSPMTableAdapters.Get_SubscribesTableAdapter();
            this.tableAdapterManager = new QLVT_DH.DSPMTableAdapters.TableAdapterManager();
            this.lbtt = new DevExpress.XtraEditors.LabelControl();
            this.lbTu = new DevExpress.XtraEditors.LabelControl();
            this.lbDen = new DevExpress.XtraEditors.LabelControl();
            this.cbThang2 = new System.Windows.Forms.ComboBox();
            this.cbNam2 = new System.Windows.Forms.ComboBox();
            this.cbNam1 = new System.Windows.Forms.ComboBox();
            this.cbThang1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.get_SubscribesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPM)).BeginInit();
            this.SuspendLayout();
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbChiNhanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbChiNhanh.DataSource = this.get_SubscribesBindingSource;
            this.cbChiNhanh.DisplayMember = "TENCN";
            this.cbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChiNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbChiNhanh.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(159, 155);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(270, 33);
            this.cbChiNhanh.TabIndex = 6;
            this.cbChiNhanh.ValueMember = "TENSERVER";
            this.cbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cbChiNhanh_SelectedIndexChanged);
            // 
            // get_SubscribesBindingSource
            // 
            this.get_SubscribesBindingSource.DataMember = "Get_Subscribes";
            this.get_SubscribesBindingSource.DataSource = this.DSPM;
            // 
            // DSPM
            // 
            this.DSPM.DataSetName = "DSPM";
            this.DSPM.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lb
            // 
            this.lb.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.lb.Appearance.Options.UseForeColor = true;
            this.lb.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb.ImageOptions.SvgImage = global::QLVT_DH.Properties.Resources.pin_icon;
            this.lb.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.lb.Location = new System.Drawing.Point(112, 155);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(41, 28);
            this.lb.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(575, 70);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "BÁO CÁO";
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPreview.Appearance.Options.UseBackColor = true;
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Location = new System.Drawing.Point(67, 377);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(148, 52);
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "Xem trước";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnIn
            // 
            this.btnIn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.btnIn.Appearance.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseBackColor = true;
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Location = new System.Drawing.Point(332, 377);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(148, 52);
            this.btnIn.TabIndex = 10;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // get_SubscribesTableAdapter
            // 
            this.get_SubscribesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = QLVT_DH.DSPMTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lbtt
            // 
            this.lbtt.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtt.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.lbtt.Appearance.Options.UseFont = true;
            this.lbtt.Appearance.Options.UseForeColor = true;
            this.lbtt.Appearance.Options.UseTextOptions = true;
            this.lbtt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbtt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbtt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbtt.Location = new System.Drawing.Point(0, 70);
            this.lbtt.Name = "lbtt";
            this.lbtt.Size = new System.Drawing.Size(575, 33);
            this.lbtt.TabIndex = 11;
            this.lbtt.Text = "text";
            // 
            // lbTu
            // 
            this.lbTu.Appearance.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTu.Appearance.Options.UseFont = true;
            this.lbTu.Location = new System.Drawing.Point(39, 226);
            this.lbTu.Name = "lbTu";
            this.lbTu.Size = new System.Drawing.Size(27, 20);
            this.lbTu.TabIndex = 16;
            this.lbTu.Text = "Từ:";
            // 
            // lbDen
            // 
            this.lbDen.Appearance.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDen.Appearance.Options.UseFont = true;
            this.lbDen.Location = new System.Drawing.Point(296, 226);
            this.lbDen.Name = "lbDen";
            this.lbDen.Size = new System.Drawing.Size(36, 20);
            this.lbDen.TabIndex = 17;
            this.lbDen.Text = "Đến:";
            // 
            // cbThang2
            // 
            this.cbThang2.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThang2.FormattingEnabled = true;
            this.cbThang2.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbThang2.Location = new System.Drawing.Point(339, 223);
            this.cbThang2.Name = "cbThang2";
            this.cbThang2.Size = new System.Drawing.Size(43, 28);
            this.cbThang2.TabIndex = 18;
            // 
            // cbNam2
            // 
            this.cbNam2.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNam2.FormattingEnabled = true;
            this.cbNam2.Items.AddRange(new object[] {
            "2070",
            "2069",
            "2068",
            "2067",
            "2066",
            "2065",
            "2064",
            "2063",
            "2062",
            "2061",
            "2060",
            "2059",
            "2058",
            "2057",
            "2056",
            "2055",
            "2054",
            "2053",
            "2052",
            "2051",
            "2050",
            "2049",
            "2048",
            "2047",
            "2046",
            "2045",
            "2044",
            "2043",
            "2042",
            "2041",
            "2040",
            "2039",
            "2038",
            "2037",
            "2036",
            "2035",
            "2034",
            "2033",
            "2032",
            "2031",
            "2030",
            "2029",
            "2028",
            "2027",
            "2026",
            "2025",
            "2024",
            "2023",
            "2022",
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002",
            "2001",
            "2000",
            "1999",
            "1998",
            "1997",
            "1996",
            "1995",
            "1994",
            "1993",
            "1992",
            "1991",
            "1990",
            "1989",
            "1988",
            "1987",
            "1986",
            "1985",
            "1984",
            "1983",
            "1982",
            "1981",
            "1980",
            "1979",
            "1978",
            "1977",
            "1976",
            "1975",
            "1974",
            "1973",
            "1972",
            "1971",
            "1970",
            "1969",
            "1968",
            "1967",
            "1966",
            "1965",
            "1964",
            "1963",
            "1962",
            "1961",
            "1960",
            "1959",
            "1958",
            "1957",
            "1956",
            "1955",
            "1954",
            "1953",
            "1952",
            "1951"});
            this.cbNam2.Location = new System.Drawing.Point(388, 223);
            this.cbNam2.Name = "cbNam2";
            this.cbNam2.Size = new System.Drawing.Size(121, 28);
            this.cbNam2.TabIndex = 19;
            // 
            // cbNam1
            // 
            this.cbNam1.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNam1.FormattingEnabled = true;
            this.cbNam1.Items.AddRange(new object[] {
            "2070",
            "2069",
            "2068",
            "2067",
            "2066",
            "2065",
            "2064",
            "2063",
            "2062",
            "2061",
            "2060",
            "2059",
            "2058",
            "2057",
            "2056",
            "2055",
            "2054",
            "2053",
            "2052",
            "2051",
            "2050",
            "2049",
            "2048",
            "2047",
            "2046",
            "2045",
            "2044",
            "2043",
            "2042",
            "2041",
            "2040",
            "2039",
            "2038",
            "2037",
            "2036",
            "2035",
            "2034",
            "2033",
            "2032",
            "2031",
            "2030",
            "2029",
            "2028",
            "2027",
            "2026",
            "2025",
            "2024",
            "2023",
            "2022",
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002",
            "2001",
            "2000",
            "1999",
            "1998",
            "1997",
            "1996",
            "1995",
            "1994",
            "1993",
            "1992",
            "1991",
            "1990",
            "1989",
            "1988",
            "1987",
            "1986",
            "1985",
            "1984",
            "1983",
            "1982",
            "1981",
            "1980",
            "1979",
            "1978",
            "1977",
            "1976",
            "1975",
            "1974",
            "1973",
            "1972",
            "1971",
            "1970",
            "1969",
            "1968",
            "1967",
            "1966",
            "1965",
            "1964",
            "1963",
            "1962",
            "1961",
            "1960",
            "1959",
            "1958",
            "1957",
            "1956",
            "1955",
            "1954",
            "1953",
            "1952",
            "1951"});
            this.cbNam1.Location = new System.Drawing.Point(123, 223);
            this.cbNam1.Name = "cbNam1";
            this.cbNam1.Size = new System.Drawing.Size(121, 28);
            this.cbNam1.TabIndex = 20;
            // 
            // cbThang1
            // 
            this.cbThang1.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThang1.FormattingEnabled = true;
            this.cbThang1.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbThang1.Location = new System.Drawing.Point(74, 223);
            this.cbThang1.Name = "cbThang1";
            this.cbThang1.Size = new System.Drawing.Size(43, 28);
            this.cbThang1.TabIndex = 21;
            // 
            // SupportReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 452);
            this.Controls.Add(this.cbThang1);
            this.Controls.Add(this.cbNam1);
            this.Controls.Add(this.cbNam2);
            this.Controls.Add(this.cbThang2);
            this.Controls.Add(this.lbDen);
            this.Controls.Add(this.lbTu);
            this.Controls.Add(this.lbtt);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cbChiNhanh);
            this.Controls.Add(this.lb);
            this.Name = "SupportReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SupportReport";
            this.Load += new System.EventHandler(this.SupportReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.get_SubscribesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbChiNhanh;
        private DevExpress.XtraEditors.LabelControl lb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DSPM DSPM;
        private System.Windows.Forms.BindingSource get_SubscribesBindingSource;
        private DSPMTableAdapters.Get_SubscribesTableAdapter get_SubscribesTableAdapter;
        private DSPMTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.LabelControl lbtt;
        private DevExpress.XtraEditors.LabelControl lbTu;
        private DevExpress.XtraEditors.LabelControl lbDen;
        private System.Windows.Forms.ComboBox cbThang2;
        private System.Windows.Forms.ComboBox cbNam2;
        private System.Windows.Forms.ComboBox cbNam1;
        private System.Windows.Forms.ComboBox cbThang1;
    }
}