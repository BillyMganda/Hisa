namespace Hisa
{
    partial class SupplierList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierList));
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.axCrystalActiveXReportViewer1 = new AxCrystalActiveXReportViewerLib11.AxCrystalActiveXReportViewer();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            ((System.ComponentModel.ISupportInitialize)(this.axCrystalActiveXReportViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(123, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 46);
            this.btnCancel.TabIndex = 128;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(0, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(340, 2);
            this.label4.TabIndex = 127;
            // 
            // btnRun
            // 
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(227, 261);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(84, 46);
            this.btnRun.TabIndex = 126;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // axCrystalActiveXReportViewer1
            // 
            this.axCrystalActiveXReportViewer1.Enabled = true;
            this.axCrystalActiveXReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.axCrystalActiveXReportViewer1.Name = "axCrystalActiveXReportViewer1";
            this.axCrystalActiveXReportViewer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCrystalActiveXReportViewer1.OcxState")));
            this.axCrystalActiveXReportViewer1.Size = new System.Drawing.Size(0, 0);
            this.axCrystalActiveXReportViewer1.TabIndex = 129;
            // 
            // SupplierList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axCrystalActiveXReportViewer1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRun);
            this.Name = "SupplierList";
            this.Size = new System.Drawing.Size(340, 321);
            ((System.ComponentModel.ISupportInitialize)(this.axCrystalActiveXReportViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRun;
        private AxCrystalActiveXReportViewerLib11.AxCrystalActiveXReportViewer axCrystalActiveXReportViewer1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
    }
}
