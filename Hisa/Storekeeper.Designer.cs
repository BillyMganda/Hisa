namespace Hisa
{
    partial class Storekeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Storekeeper));
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReceiveStockItems = new System.Windows.Forms.Button();
            this.btnItemDisposal = new System.Windows.Forms.Button();
            this.btnReturnToSupplier = new System.Windows.Forms.Button();
            this.btnIssueFromStore = new System.Windows.Forms.Button();
            this.btnPurchaseRequest = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnDepartmental = new System.Windows.Forms.Button();
            this.btnSwitchUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(11, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(450, 2);
            this.label6.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "Storekeeper Module";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnReceiveStockItems
            // 
            this.btnReceiveStockItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveStockItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveStockItems.Location = new System.Drawing.Point(19, 53);
            this.btnReceiveStockItems.Name = "btnReceiveStockItems";
            this.btnReceiveStockItems.Size = new System.Drawing.Size(92, 61);
            this.btnReceiveStockItems.TabIndex = 50;
            this.btnReceiveStockItems.Text = "Receive Stock Items";
            this.btnReceiveStockItems.UseVisualStyleBackColor = true;
            this.btnReceiveStockItems.Click += new System.EventHandler(this.btnReceiveStockItems_Click);
            // 
            // btnItemDisposal
            // 
            this.btnItemDisposal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemDisposal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemDisposal.Location = new System.Drawing.Point(136, 53);
            this.btnItemDisposal.Name = "btnItemDisposal";
            this.btnItemDisposal.Size = new System.Drawing.Size(92, 61);
            this.btnItemDisposal.TabIndex = 51;
            this.btnItemDisposal.Text = "Item Disposal";
            this.btnItemDisposal.UseVisualStyleBackColor = true;
            this.btnItemDisposal.Click += new System.EventHandler(this.btnItemDisposal_Click);
            // 
            // btnReturnToSupplier
            // 
            this.btnReturnToSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnToSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnToSupplier.Location = new System.Drawing.Point(252, 53);
            this.btnReturnToSupplier.Name = "btnReturnToSupplier";
            this.btnReturnToSupplier.Size = new System.Drawing.Size(92, 61);
            this.btnReturnToSupplier.TabIndex = 52;
            this.btnReturnToSupplier.Text = "Return to Supplier";
            this.btnReturnToSupplier.UseVisualStyleBackColor = true;
            this.btnReturnToSupplier.Click += new System.EventHandler(this.btnReturnToSupplier_Click);
            // 
            // btnIssueFromStore
            // 
            this.btnIssueFromStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueFromStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueFromStore.Location = new System.Drawing.Point(19, 132);
            this.btnIssueFromStore.Name = "btnIssueFromStore";
            this.btnIssueFromStore.Size = new System.Drawing.Size(92, 61);
            this.btnIssueFromStore.TabIndex = 53;
            this.btnIssueFromStore.Text = "Issue from Store";
            this.btnIssueFromStore.UseVisualStyleBackColor = true;
            this.btnIssueFromStore.Click += new System.EventHandler(this.btnIssueFromStore_Click);
            // 
            // btnPurchaseRequest
            // 
            this.btnPurchaseRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchaseRequest.Location = new System.Drawing.Point(136, 132);
            this.btnPurchaseRequest.Name = "btnPurchaseRequest";
            this.btnPurchaseRequest.Size = new System.Drawing.Size(92, 61);
            this.btnPurchaseRequest.TabIndex = 54;
            this.btnPurchaseRequest.Text = "Purchase Request";
            this.btnPurchaseRequest.UseVisualStyleBackColor = true;
            this.btnPurchaseRequest.Click += new System.EventHandler(this.btnPurchaseRequest_Click);
            // 
            // btnReports
            // 
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(252, 132);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(92, 61);
            this.btnReports.TabIndex = 55;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnDepartmental
            // 
            this.btnDepartmental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartmental.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartmental.Location = new System.Drawing.Point(368, 53);
            this.btnDepartmental.Name = "btnDepartmental";
            this.btnDepartmental.Size = new System.Drawing.Size(92, 61);
            this.btnDepartmental.TabIndex = 56;
            this.btnDepartmental.Text = "Departmental Budget";
            this.btnDepartmental.UseVisualStyleBackColor = true;
            this.btnDepartmental.Click += new System.EventHandler(this.btnDepartmental_Click);
            // 
            // btnSwitchUser
            // 
            this.btnSwitchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchUser.Location = new System.Drawing.Point(368, 132);
            this.btnSwitchUser.Name = "btnSwitchUser";
            this.btnSwitchUser.Size = new System.Drawing.Size(92, 61);
            this.btnSwitchUser.TabIndex = 57;
            this.btnSwitchUser.Text = "Switch User";
            this.btnSwitchUser.UseVisualStyleBackColor = true;
            this.btnSwitchUser.Click += new System.EventHandler(this.btnSwitchUser_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(16, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 2);
            this.label2.TabIndex = 58;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(136, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 61);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 11.25F);
            this.label3.Location = new System.Drawing.Point(16, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 60;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 61);
            this.button1.TabIndex = 61;
            this.button1.Text = "Return to Store";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Storekeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 340);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSwitchUser);
            this.Controls.Add(this.btnDepartmental);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnPurchaseRequest);
            this.Controls.Add(this.btnIssueFromStore);
            this.Controls.Add(this.btnReturnToSupplier);
            this.Controls.Add(this.btnItemDisposal);
            this.Controls.Add(this.btnReceiveStockItems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Storekeeper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Storekeeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReceiveStockItems;
        private System.Windows.Forms.Button btnItemDisposal;
        private System.Windows.Forms.Button btnReturnToSupplier;
        private System.Windows.Forms.Button btnIssueFromStore;
        private System.Windows.Forms.Button btnPurchaseRequest;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnDepartmental;
        private System.Windows.Forms.Button btnSwitchUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}