namespace Hisa
{
    partial class Purchasing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchasing));
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLPO = new System.Windows.Forms.Button();
            this.btnAddStockItems = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnSwitchUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(11, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(450, 2);
            this.label6.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "Purchasing Module";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLPO
            // 
            this.btnLPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLPO.Location = new System.Drawing.Point(69, 58);
            this.btnLPO.Name = "btnLPO";
            this.btnLPO.Size = new System.Drawing.Size(92, 61);
            this.btnLPO.TabIndex = 50;
            this.btnLPO.Text = "Purchase Order (LPO)";
            this.btnLPO.UseVisualStyleBackColor = true;
            this.btnLPO.Click += new System.EventHandler(this.btnLPO_Click);
            // 
            // btnAddStockItems
            // 
            this.btnAddStockItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStockItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStockItems.Location = new System.Drawing.Point(186, 58);
            this.btnAddStockItems.Name = "btnAddStockItems";
            this.btnAddStockItems.Size = new System.Drawing.Size(92, 61);
            this.btnAddStockItems.TabIndex = 51;
            this.btnAddStockItems.Text = "Add Stock Items";
            this.btnAddStockItems.UseVisualStyleBackColor = true;
            this.btnAddStockItems.Click += new System.EventHandler(this.btnAddStockItems_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequest.Location = new System.Drawing.Point(305, 58);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(92, 61);
            this.btnRequest.TabIndex = 52;
            this.btnRequest.Text = "Request from Store";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnReports
            // 
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(69, 139);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(92, 61);
            this.btnReports.TabIndex = 53;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSupplier.Location = new System.Drawing.Point(186, 139);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(92, 61);
            this.btnAddSupplier.TabIndex = 54;
            this.btnAddSupplier.Text = "Add Supplier Info";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnSwitchUser
            // 
            this.btnSwitchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchUser.Location = new System.Drawing.Point(305, 139);
            this.btnSwitchUser.Name = "btnSwitchUser";
            this.btnSwitchUser.Size = new System.Drawing.Size(92, 61);
            this.btnSwitchUser.TabIndex = 55;
            this.btnSwitchUser.Text = "Switch User";
            this.btnSwitchUser.UseVisualStyleBackColor = true;
            this.btnSwitchUser.Click += new System.EventHandler(this.btnSwitchUser_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(11, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 2);
            this.label2.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.label3.Location = new System.Drawing.Point(12, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "label3";
            // 
            // Purchasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 253);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSwitchUser);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.btnAddStockItems);
            this.Controls.Add(this.btnLPO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Purchasing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchasing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLPO;
        private System.Windows.Forms.Button btnAddStockItems;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnSwitchUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}