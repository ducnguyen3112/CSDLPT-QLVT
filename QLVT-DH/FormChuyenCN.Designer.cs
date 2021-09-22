
namespace QLVT_DH
{
    partial class FormChuyenCN
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
            this.btnChuyen = new DevExpress.XtraEditors.SimpleButton();
            this.cbChuyenCN = new System.Windows.Forms.ComboBox();
            this.DSPMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSPM = new QLVT_DH.DSPM();
            this.get_SubscribesTableAdapter = new QLVT_DH.DSPMTableAdapters.Get_SubscribesTableAdapter();
            this.tableAdapterManager = new QLVT_DH.DSPMTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.DSPMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPM)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.ImageOptions.SvgImage = global::QLVT_DH.Properties.Resources.b2b1;
            this.labelControl1.ImageOptions.SvgImageSize = new System.Drawing.Size(100, 100);
            this.labelControl1.Location = new System.Drawing.Point(48, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(276, 144);
            this.labelControl1.TabIndex = 5;
            // 
            // btnChuyen
            // 
            this.btnChuyen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.btnChuyen.Appearance.BorderColor = System.Drawing.Color.White;
            this.btnChuyen.Appearance.Font = new System.Drawing.Font("Roboto Mono", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyen.Appearance.Options.UseBackColor = true;
            this.btnChuyen.Appearance.Options.UseBorderColor = true;
            this.btnChuyen.Appearance.Options.UseFont = true;
            this.btnChuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChuyen.Location = new System.Drawing.Point(48, 270);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(276, 47);
            this.btnChuyen.TabIndex = 4;
            this.btnChuyen.Text = "CHUYỂN";
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // cbChuyenCN
            // 
            this.cbChuyenCN.DataSource = this.DSPMBindingSource;
            this.cbChuyenCN.DisplayMember = "TENCN";
            this.cbChuyenCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChuyenCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbChuyenCN.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChuyenCN.FormattingEnabled = true;
            this.cbChuyenCN.Location = new System.Drawing.Point(48, 162);
            this.cbChuyenCN.Name = "cbChuyenCN";
            this.cbChuyenCN.Size = new System.Drawing.Size(276, 34);
            this.cbChuyenCN.TabIndex = 3;
            this.cbChuyenCN.ValueMember = "TENSERVER";
            // 
            // DSPMBindingSource
            // 
            this.DSPMBindingSource.DataMember = "Get_Subscribes";
            this.DSPMBindingSource.DataSource = this.DSPM;
            // 
            // DSPM
            // 
            this.DSPM.DataSetName = "DSPM";
            this.DSPM.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // FormChuyenCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(366, 329);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnChuyen);
            this.Controls.Add(this.cbChuyenCN);
            this.Name = "FormChuyenCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển chi nhánh";
            this.Load += new System.EventHandler(this.FormChuyenCN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSPMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnChuyen;
        private System.Windows.Forms.ComboBox cbChuyenCN;
        private DSPM DSPM;
        private System.Windows.Forms.BindingSource DSPMBindingSource;
        private DSPMTableAdapters.Get_SubscribesTableAdapter get_SubscribesTableAdapter;
        private DSPMTableAdapters.TableAdapterManager tableAdapterManager;
    }
}