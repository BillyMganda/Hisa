namespace Hisa
{
    partial class Add_Stock_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Stock_Items));
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMainGroup = new System.Windows.Forms.Button();
            this.btnSubGroup = new System.Windows.Forms.Button();
            this.btnStockItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(13, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(370, 2);
            this.label6.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "Add Stock Items";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnMainGroup
            // 
            this.btnMainGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainGroup.Location = new System.Drawing.Point(32, 60);
            this.btnMainGroup.Name = "btnMainGroup";
            this.btnMainGroup.Size = new System.Drawing.Size(92, 61);
            this.btnMainGroup.TabIndex = 52;
            this.btnMainGroup.Text = "Add Main Group";
            this.btnMainGroup.UseVisualStyleBackColor = true;
            this.btnMainGroup.Click += new System.EventHandler(this.btnMainGroup_Click);
            // 
            // btnSubGroup
            // 
            this.btnSubGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubGroup.Location = new System.Drawing.Point(151, 60);
            this.btnSubGroup.Name = "btnSubGroup";
            this.btnSubGroup.Size = new System.Drawing.Size(92, 61);
            this.btnSubGroup.TabIndex = 53;
            this.btnSubGroup.Text = "Add Sub Group";
            this.btnSubGroup.UseVisualStyleBackColor = true;
            this.btnSubGroup.Click += new System.EventHandler(this.btnSubGroup_Click);
            // 
            // btnStockItem
            // 
            this.btnStockItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockItem.Location = new System.Drawing.Point(274, 60);
            this.btnStockItem.Name = "btnStockItem";
            this.btnStockItem.Size = new System.Drawing.Size(92, 61);
            this.btnStockItem.TabIndex = 54;
            this.btnStockItem.Text = "Add Stock Items";
            this.btnStockItem.UseVisualStyleBackColor = true;
            this.btnStockItem.Click += new System.EventHandler(this.btnStockItem_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(17, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 2);
            this.label2.TabIndex = 55;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(274, 158);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 61);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Add_Stock_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 234);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStockItem);
            this.Controls.Add(this.btnSubGroup);
            this.Controls.Add(this.btnMainGroup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Add_Stock_Items";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Stock Items";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMainGroup;
        private System.Windows.Forms.Button btnSubGroup;
        private System.Windows.Forms.Button btnStockItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
    }
}