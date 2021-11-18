
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
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.rbtnNhap = new System.Windows.Forms.RadioButton();
            this.rbtnXuat = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.get_SubscribesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
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
            this.cbChiNhanh.Location = new System.Drawing.Point(221, 152);
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
            this.lb.Location = new System.Drawing.Point(174, 155);
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
            this.labelControl1.Size = new System.Drawing.Size(675, 70);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "BÁO CÁO";
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPreview.Appearance.Options.UseBackColor = true;
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Location = new System.Drawing.Point(149, 377);
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
            this.btnIn.Location = new System.Drawing.Point(392, 377);
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
            this.lbtt.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbtt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbtt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbtt.Location = new System.Drawing.Point(0, 70);
            this.lbtt.Name = "lbtt";
            this.lbtt.Size = new System.Drawing.Size(675, 33);
            this.lbtt.TabIndex = 11;
            this.lbtt.Text = "text";
            // 
            // lbTu
            // 
            this.lbTu.Appearance.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTu.Appearance.Options.UseFont = true;
            this.lbTu.Location = new System.Drawing.Point(42, 268);
            this.lbTu.Name = "lbTu";
            this.lbTu.Size = new System.Drawing.Size(27, 20);
            this.lbTu.TabIndex = 16;
            this.lbTu.Text = "Từ:";
            this.lbTu.Visible = false;
            // 
            // lbDen
            // 
            this.lbDen.Appearance.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDen.Appearance.Options.UseFont = true;
            this.lbDen.Location = new System.Drawing.Point(372, 266);
            this.lbDen.Name = "lbDen";
            this.lbDen.Size = new System.Drawing.Size(36, 20);
            this.lbDen.TabIndex = 17;
            this.lbDen.Text = "Đến:";
            this.lbDen.Visible = false;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(70, 268);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEdit1.Properties.Appearance.Options.UseFont = true;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(182, 24);
            this.dateEdit1.TabIndex = 18;
            this.dateEdit1.Visible = false;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(414, 264);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEdit2.Properties.Appearance.Options.UseFont = true;
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(182, 24);
            this.dateEdit2.TabIndex = 19;
            this.dateEdit2.Visible = false;
            // 
            // rbtnNhap
            // 
            this.rbtnNhap.AutoSize = true;
            this.rbtnNhap.Location = new System.Drawing.Point(201, 220);
            this.rbtnNhap.Name = "rbtnNhap";
            this.rbtnNhap.Size = new System.Drawing.Size(96, 21);
            this.rbtnNhap.TabIndex = 20;
            this.rbtnNhap.TabStop = true;
            this.rbtnNhap.Text = "Hàng nhập";
            this.rbtnNhap.UseVisualStyleBackColor = true;
            this.rbtnNhap.Visible = false;
            // 
            // rbtnXuat
            // 
            this.rbtnXuat.AutoSize = true;
            this.rbtnXuat.Location = new System.Drawing.Point(372, 220);
            this.rbtnXuat.Name = "rbtnXuat";
            this.rbtnXuat.Size = new System.Drawing.Size(93, 21);
            this.rbtnXuat.TabIndex = 21;
            this.rbtnXuat.TabStop = true;
            this.rbtnXuat.Text = "Hàng xuất";
            this.rbtnXuat.UseVisualStyleBackColor = true;
            this.rbtnXuat.Visible = false;
            // 
            // SupportReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 452);
            this.Controls.Add(this.rbtnXuat);
            this.Controls.Add(this.rbtnNhap);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private System.Windows.Forms.RadioButton rbtnNhap;
        private System.Windows.Forms.RadioButton rbtnXuat;
    }
}