namespace Hisa
{
    partial class Reports
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Daily Issue Summary");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Consumption per Department");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Department Consumption/Main Group");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Department Consumption/Sub group");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Department Consumption/Item");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Overall Consumption");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Consumption Reports", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Stocksheet");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Opening Stock");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Closing Stock");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Stock on Hand");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Stock Variance");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Physical Stocks");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Item History");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Return In List");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Return Out List");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Book Over List");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Book Short List");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Item Disposal List");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Inventory Reports", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Daily LPO Summary");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Daily GRN Summary");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Total Purchases");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Purchases for Specified Main Group");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Purchases for Specifed Sub Group");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Purchases by Supplier");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Item Purchase History");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Open LPOs");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Void LPOs");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Supplier List");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Purchase Reports", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Reprint LPO");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Reprint GRN");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Reprint Return to Supplier");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Reprint Item Disposal");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Reprint Issue Note");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Reprint Reports", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Reports", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode20,
            treeNode31,
            treeNode37});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reports Map";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 2);
            this.label2.TabIndex = 54;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.Location = new System.Drawing.Point(7, 46);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node6";
            treeNode1.Text = "Daily Issue Summary";
            treeNode2.Name = "Node7";
            treeNode2.Text = "Consumption per Department";
            treeNode3.Name = "Node8";
            treeNode3.Text = "Department Consumption/Main Group";
            treeNode4.Name = "Node9";
            treeNode4.Text = "Department Consumption/Sub group";
            treeNode5.Name = "Node10";
            treeNode5.Text = "Department Consumption/Item";
            treeNode6.Name = "Node11";
            treeNode6.Text = "Overall Consumption";
            treeNode7.Name = "Node1";
            treeNode7.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode7.Text = "Consumption Reports";
            treeNode8.Name = "Node12";
            treeNode8.Text = "Stocksheet";
            treeNode9.Name = "Node13";
            treeNode9.Text = "Opening Stock";
            treeNode10.Name = "Node14";
            treeNode10.Text = "Closing Stock";
            treeNode11.Name = "Node15";
            treeNode11.Text = "Stock on Hand";
            treeNode12.Name = "Node16";
            treeNode12.Text = "Stock Variance";
            treeNode13.Name = "Node17";
            treeNode13.Text = "Physical Stocks";
            treeNode14.Name = "Node18";
            treeNode14.Text = "Item History";
            treeNode15.Name = "Node20";
            treeNode15.Text = "Return In List";
            treeNode16.Name = "Node21";
            treeNode16.Text = "Return Out List";
            treeNode17.Name = "Node22";
            treeNode17.Text = "Book Over List";
            treeNode18.Name = "Node23";
            treeNode18.Text = "Book Short List";
            treeNode19.Name = "Node24";
            treeNode19.Text = "Item Disposal List";
            treeNode20.Name = "Node4";
            treeNode20.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode20.Text = "Inventory Reports";
            treeNode21.Name = "Node26";
            treeNode21.Text = "Daily LPO Summary";
            treeNode22.Name = "Node27";
            treeNode22.Text = "Daily GRN Summary";
            treeNode23.Name = "Node28";
            treeNode23.Text = "Total Purchases";
            treeNode24.Name = "Node29";
            treeNode24.Text = "Purchases for Specified Main Group";
            treeNode25.Name = "Node30";
            treeNode25.Text = "Purchases for Specifed Sub Group";
            treeNode26.Name = "Node1";
            treeNode26.Text = "Purchases by Supplier";
            treeNode27.Name = "Node31";
            treeNode27.Text = "Item Purchase History";
            treeNode28.Name = "Node32";
            treeNode28.Text = "Open LPOs";
            treeNode29.Name = "Node33";
            treeNode29.Text = "Void LPOs";
            treeNode30.Name = "Node35";
            treeNode30.Text = "Supplier List";
            treeNode31.Name = "Node5";
            treeNode31.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode31.Text = "Purchase Reports";
            treeNode32.Name = "Node1";
            treeNode32.Text = "Reprint LPO";
            treeNode33.Name = "Node2";
            treeNode33.Text = "Reprint GRN";
            treeNode34.Name = "Node0";
            treeNode34.Text = "Reprint Return to Supplier";
            treeNode35.Name = "Node1";
            treeNode35.Text = "Reprint Item Disposal";
            treeNode36.Name = "Node0";
            treeNode36.Text = "Reprint Issue Note";
            treeNode37.Name = "Node0";
            treeNode37.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            treeNode37.Text = "Reprint Reports";
            treeNode38.Name = "ReportsNode";
            treeNode38.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode38.Text = "Reports";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode38});
            this.treeView1.Size = new System.Drawing.Size(300, 348);
            this.treeView1.TabIndex = 55;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(334, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 360);
            this.label3.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(360, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(340, 2);
            this.label4.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Parameters for this Report";
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(360, 46);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(340, 321);
            this.MainPanel.TabIndex = 59;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 407);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel MainPanel;
    }
}