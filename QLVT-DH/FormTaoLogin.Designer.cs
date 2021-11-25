
namespace QLVT_DH
{
    partial class FormTaoLogin
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbNhom = new System.Windows.Forms.ComboBox();
            this.txtLogin = new DevExpress.XtraEditors.TextEdit();
            this.txtPasswd = new DevExpress.XtraEditors.TextEdit();
            this.bdsTENNV = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLVT_DH.DS();
            this.cbCN = new System.Windows.Forms.ComboBox();
            this.get_SubscribesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSPM = new QLVT_DH.DSPM();
            this.btnTao = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.TENNVTableAdapter = new QLVT_DH.DSTableAdapters.V_DS_TENNVTableAdapter();
            this.tableAdapterManager = new QLVT_DH.DSTableAdapters.TableAdapterManager();
            this.get_SubscribesTableAdapter = new QLVT_DH.DSPMTableAdapters.Get_SubscribesTableAdapter();
            this.tableAdapterManager1 = new QLVT_DH.DSPMTableAdapters.TableAdapterManager();
            this.cbTENNV = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTENNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_SubscribesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPM)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.ImageOptions.SvgImage = global::QLVT_DH.Properties.Resources.add_user;
            this.labelControl1.ImageOptions.SvgImageSize = new System.Drawing.Size(100, 100);
            this.labelControl1.Location = new System.Drawing.Point(147, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(125, 125);
            this.labelControl1.TabIndex = 0;
            // 
            // cbNhom
            // 
            this.cbNhom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhom.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhom.FormattingEnabled = true;
            this.cbNhom.Items.AddRange(new object[] {
            "CONGTY",
            "CHINHANH",
            "USER"});
            this.cbNhom.Location = new System.Drawing.Point(72, 261);
            this.cbNhom.Name = "cbNhom";
            this.cbNhom.Size = new System.Drawing.Size(271, 34);
            this.cbNhom.TabIndex = 1;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(72, 341);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Properties.Appearance.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Properties.Appearance.Options.UseFont = true;
            this.txtLogin.Size = new System.Drawing.Size(271, 32);
            this.txtLogin.TabIndex = 2;
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(72, 379);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Properties.Appearance.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswd.Properties.Appearance.Options.UseFont = true;
            this.txtPasswd.Size = new System.Drawing.Size(271, 32);
            this.txtPasswd.TabIndex = 3;
            // 
            // bdsTENNV
            // 
            this.bdsTENNV.DataMember = "V_DS_TENNV";
            this.bdsTENNV.DataSource = this.dS;
            // 
            // DS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbCN
            // 
            this.cbCN.BackColor = System.Drawing.Color.White;
            this.cbCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCN.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCN.FormattingEnabled = true;
            this.cbCN.Location = new System.Drawing.Point(72, 186);
            this.cbCN.Name = "cbCN";
            this.cbCN.Size = new System.Drawing.Size(271, 34);
            this.cbCN.TabIndex = 5;
            this.cbCN.SelectedIndexChanged += new System.EventHandler(this.cbCN_SelectedIndexChanged);
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
            // btnTao
            // 
            this.btnTao.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.btnTao.Appearance.Font = new System.Drawing.Font("Roboto Mono", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTao.Appearance.Options.UseBackColor = true;
            this.btnTao.Appearance.Options.UseFont = true;
            this.btnTao.Location = new System.Drawing.Point(72, 445);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(271, 63);
            this.btnTao.TabIndex = 6;
            this.btnTao.Text = "TẠO TÀI KHOẢN";
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.ImageOptions.SvgImage = global::QLVT_DH.Properties.Resources.pin1;
            this.labelControl2.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelControl2.Location = new System.Drawing.Point(41, 193);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 25);
            this.labelControl2.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.ImageOptions.SvgImage = global::QLVT_DH.Properties.Resources.user_group;
            this.labelControl3.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelControl3.Location = new System.Drawing.Point(41, 268);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 25);
            this.labelControl3.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.ImageOptions.SvgImage = global::QLVT_DH.Properties.Resources.driver_license;
            this.labelControl4.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelControl4.Location = new System.Drawing.Point(41, 308);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(25, 25);
            this.labelControl4.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.ImageOptions.SvgImage = global::QLVT_DH.Properties.Resources.usercreate;
            this.labelControl5.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelControl5.Location = new System.Drawing.Point(41, 348);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(25, 25);
            this.labelControl5.TabIndex = 10;
            // 
            // labelControl6
            // 
            this.labelControl6.ImageOptions.SvgImage = global::QLVT_DH.Properties.Resources.padlock;
            this.labelControl6.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelControl6.Location = new System.Drawing.Point(41, 386);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(25, 25);
            this.labelControl6.TabIndex = 11;
            // 
            // TENNVTableAdapter
            // 
            this.TENNVTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.sp_DSNhanVienTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_DH.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // get_SubscribesTableAdapter
            // 
            this.get_SubscribesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = QLVT_DH.DSPMTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cbTENNV
            // 
            this.cbTENNV.DataSource = this.bdsTENNV;
            this.cbTENNV.DisplayMember = "HOTEN";
            this.cbTENNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTENNV.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTENNV.FormattingEnabled = true;
            this.cbTENNV.Location = new System.Drawing.Point(72, 301);
            this.cbTENNV.Name = "cbTENNV";
            this.cbTENNV.Size = new System.Drawing.Size(271, 34);
            this.cbTENNV.TabIndex = 12;
            this.cbTENNV.ValueMember = "MANV";
            // 
            // FormTaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 545);
            this.Controls.Add(this.cbTENNV);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.cbCN);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.cbNhom);
            this.Controls.Add(this.labelControl1);
            this.Name = "FormTaoLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo tài khoản đăng nhập";
            this.Load += new System.EventHandler(this.FormTaoLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTENNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_SubscribesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cbNhom;
        private DevExpress.XtraEditors.TextEdit txtLogin;
        private DevExpress.XtraEditors.TextEdit txtPasswd;
        private System.Windows.Forms.ComboBox cbCN;
        private DevExpress.XtraEditors.SimpleButton btnTao;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DS dS;
        private System.Windows.Forms.BindingSource bdsTENNV;
        private DSTableAdapters.V_DS_TENNVTableAdapter TENNVTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DSPM DSPM;
        private System.Windows.Forms.BindingSource get_SubscribesBindingSource;
        private DSPMTableAdapters.Get_SubscribesTableAdapter get_SubscribesTableAdapter;
        private DSPMTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.ComboBox cbTENNV;
    }
}