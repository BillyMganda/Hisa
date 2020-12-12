namespace Hisa
{
    partial class Authorize_Item
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorize_Item));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AuthorizeDatagrid = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnauthorize = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AuthorizeDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 2);
            this.label2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Authorize new item to update inventory";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AuthorizeDatagrid
            // 
            this.AuthorizeDatagrid.AllowUserToAddRows = false;
            this.AuthorizeDatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AuthorizeDatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AuthorizeDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuthorizeDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.ItemName,
            this.MainGroup,
            this.SubGroup,
            this.ItemUnits});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AuthorizeDatagrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.AuthorizeDatagrid.Location = new System.Drawing.Point(12, 61);
            this.AuthorizeDatagrid.Name = "AuthorizeDatagrid";
            this.AuthorizeDatagrid.RowHeadersVisible = false;
            this.AuthorizeDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuthorizeDatagrid.Size = new System.Drawing.Size(448, 405);
            this.AuthorizeDatagrid.TabIndex = 7;
            // 
            // Select
            // 
            this.Select.DataPropertyName = "Select";
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.Width = 40;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 140;
            // 
            // MainGroup
            // 
            this.MainGroup.DataPropertyName = "MainGroup";
            this.MainGroup.HeaderText = "Main Group";
            this.MainGroup.Name = "MainGroup";
            this.MainGroup.Width = 80;
            // 
            // SubGroup
            // 
            this.SubGroup.DataPropertyName = "SubGroup";
            this.SubGroup.HeaderText = "Sub Group";
            this.SubGroup.Name = "SubGroup";
            this.SubGroup.Width = 80;
            // 
            // ItemUnits
            // 
            this.ItemUnits.DataPropertyName = "ItemUnits";
            this.ItemUnits.HeaderText = "Units";
            this.ItemUnits.Name = "ItemUnits";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(229, 496);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 44);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnauthorize
            // 
            this.btnauthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnauthorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnauthorize.Location = new System.Drawing.Point(387, 496);
            this.btnauthorize.Name = "btnauthorize";
            this.btnauthorize.Size = new System.Drawing.Size(73, 44);
            this.btnauthorize.TabIndex = 47;
            this.btnauthorize.Text = "Authorize";
            this.btnauthorize.UseVisualStyleBackColor = true;
            // 
            // btnVoid
            // 
            this.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoid.Location = new System.Drawing.Point(308, 496);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(73, 44);
            this.btnVoid.TabIndex = 48;
            this.btnVoid.Text = "Void";
            this.btnVoid.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(11, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(450, 2);
            this.label3.TabIndex = 49;
            // 
            // Authorize_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 562);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVoid);
            this.Controls.Add(this.btnauthorize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.AuthorizeDatagrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Authorize_Item";
            this.Load += new System.EventHandler(this.Authorize_Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AuthorizeDatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView AuthorizeDatagrid;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnauthorize;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemUnits;
    }
}