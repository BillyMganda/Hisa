namespace Hisa
{
    partial class Cart
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cart));
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridCart = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridCheckOut = new System.Windows.Forms.DataGridView();
            this.ItemName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOH1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockValue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Request1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRequestBy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.radDay = new System.Windows.Forms.RadioButton();
            this.radNight = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSaveRecord = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.hisaDataSet1 = new Hisa.HisaDataSet1();
            this.addToCartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addToCartTableAdapter = new Hisa.HisaDataSet1TableAdapters.AddToCartTableAdapter();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCheckOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addToCartBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add to Cart";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(12, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1158, 2);
            this.label6.TabIndex = 36;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(12, 76);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(285, 20);
            this.txtSearch.TabIndex = 37;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridCart
            // 
            this.dataGridCart.AllowUserToAddRows = false;
            this.dataGridCart.AllowUserToResizeColumns = false;
            this.dataGridCart.AllowUserToResizeRows = false;
            this.dataGridCart.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.ItemCode,
            this.Units,
            this.SOH,
            this.UnitPrice,
            this.StockValue});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridCart.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridCart.Location = new System.Drawing.Point(12, 104);
            this.dataGridCart.Name = "dataGridCart";
            this.dataGridCart.RowHeadersVisible = false;
            this.dataGridCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCart.Size = new System.Drawing.Size(435, 256);
            this.dataGridCart.TabIndex = 39;
            this.dataGridCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCart_CellContentClick);
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemName.DefaultCellStyle = dataGridViewCellStyle1;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // ItemCode
            // 
            this.ItemCode.DataPropertyName = "ItemCode";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemCode.HeaderText = "Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Width = 60;
            // 
            // Units
            // 
            this.Units.DataPropertyName = "Units";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Units.DefaultCellStyle = dataGridViewCellStyle3;
            this.Units.HeaderText = "Units";
            this.Units.Name = "Units";
            this.Units.ReadOnly = true;
            this.Units.Width = 60;
            // 
            // SOH
            // 
            this.SOH.DataPropertyName = "SOH";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SOH.DefaultCellStyle = dataGridViewCellStyle4;
            this.SOH.HeaderText = "SOH";
            this.SOH.Name = "SOH";
            this.SOH.ReadOnly = true;
            this.SOH.Width = 60;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "Price";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.UnitPrice.HeaderText = "Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 60;
            // 
            // StockValue
            // 
            this.StockValue.DataPropertyName = "StockValue";
            this.StockValue.HeaderText = "Value";
            this.StockValue.Name = "StockValue";
            this.StockValue.ReadOnly = true;
            this.StockValue.Width = 60;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.Location = new System.Drawing.Point(322, 425);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(73, 44);
            this.btnAddToCart.TabIndex = 50;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(460, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 350);
            this.label2.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 52;
            this.label3.Text = "Check Out";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridCheckOut
            // 
            this.dataGridCheckOut.AllowUserToAddRows = false;
            this.dataGridCheckOut.AllowUserToResizeColumns = false;
            this.dataGridCheckOut.AllowUserToResizeRows = false;
            this.dataGridCheckOut.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridCheckOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCheckOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName1,
            this.ItemCode1,
            this.Units1,
            this.SOH1,
            this.UnitPrice1,
            this.StockValue1,
            this.Request1,
            this.Total1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridCheckOut.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridCheckOut.Location = new System.Drawing.Point(473, 104);
            this.dataGridCheckOut.Name = "dataGridCheckOut";
            this.dataGridCheckOut.RowHeadersVisible = false;
            this.dataGridCheckOut.Size = new System.Drawing.Size(604, 256);
            this.dataGridCheckOut.TabIndex = 53;
            this.dataGridCheckOut.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCheckOut_CellEndEdit);
            this.dataGridCheckOut.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCheckOut_CellEnter);
            // 
            // ItemName1
            // 
            this.ItemName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName1.DataPropertyName = "ItemName";
            this.ItemName1.HeaderText = "Item Name";
            this.ItemName1.Name = "ItemName1";
            this.ItemName1.ReadOnly = true;
            // 
            // ItemCode1
            // 
            this.ItemCode1.DataPropertyName = "ItemCode";
            this.ItemCode1.HeaderText = "Code";
            this.ItemCode1.Name = "ItemCode1";
            this.ItemCode1.ReadOnly = true;
            this.ItemCode1.Width = 60;
            // 
            // Units1
            // 
            this.Units1.DataPropertyName = "Units";
            this.Units1.HeaderText = "Units";
            this.Units1.Name = "Units1";
            this.Units1.ReadOnly = true;
            this.Units1.Width = 60;
            // 
            // SOH1
            // 
            this.SOH1.DataPropertyName = "SOH";
            this.SOH1.HeaderText = "SOH";
            this.SOH1.Name = "SOH1";
            this.SOH1.ReadOnly = true;
            this.SOH1.Width = 60;
            // 
            // UnitPrice1
            // 
            this.UnitPrice1.DataPropertyName = "UnitPrice";
            this.UnitPrice1.HeaderText = "Price";
            this.UnitPrice1.Name = "UnitPrice1";
            this.UnitPrice1.ReadOnly = true;
            this.UnitPrice1.Width = 70;
            // 
            // StockValue1
            // 
            this.StockValue1.DataPropertyName = "Value";
            this.StockValue1.HeaderText = "Value";
            this.StockValue1.Name = "StockValue1";
            this.StockValue1.ReadOnly = true;
            this.StockValue1.Width = 70;
            // 
            // Request1
            // 
            this.Request1.DataPropertyName = "Request";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            this.Request1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Request1.HeaderText = "Request";
            this.Request1.Name = "Request1";
            this.Request1.Width = 70;
            // 
            // Total1
            // 
            this.Total1.HeaderText = "Total";
            this.Total1.Name = "Total1";
            this.Total1.ReadOnly = true;
            this.Total1.Width = 60;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(918, 78);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(86, 20);
            this.txtTime.TabIndex = 56;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(816, 78);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(86, 20);
            this.txtDate.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(698, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Request Date/Time";
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(1083, 78);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ReadOnly = true;
            this.txtRequest.Size = new System.Drawing.Size(86, 20);
            this.txtRequest.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1010, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Request #";
            // 
            // txtRequestBy
            // 
            this.txtRequestBy.Location = new System.Drawing.Point(1083, 125);
            this.txtRequestBy.Name = "txtRequestBy";
            this.txtRequestBy.ReadOnly = true;
            this.txtRequestBy.Size = new System.Drawing.Size(86, 20);
            this.txtRequestBy.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1090, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Request By";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(1083, 168);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(86, 20);
            this.txtDepartment.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1090, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Department";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1104, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Shift";
            // 
            // radDay
            // 
            this.radDay.AutoSize = true;
            this.radDay.Location = new System.Drawing.Point(1093, 224);
            this.radDay.Name = "radDay";
            this.radDay.Size = new System.Drawing.Size(44, 17);
            this.radDay.TabIndex = 66;
            this.radDay.Text = "Day";
            this.radDay.UseVisualStyleBackColor = true;
            this.radDay.CheckedChanged += new System.EventHandler(this.radDay_CheckedChanged);
            // 
            // radNight
            // 
            this.radNight.AutoSize = true;
            this.radNight.Location = new System.Drawing.Point(1093, 248);
            this.radNight.Name = "radNight";
            this.radNight.Size = new System.Drawing.Size(50, 17);
            this.radNight.TabIndex = 67;
            this.radNight.Text = "Night";
            this.radNight.UseVisualStyleBackColor = true;
            this.radNight.CheckedChanged += new System.EventHandler(this.radNight_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(903, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "/";
            // 
            // btnSaveRecord
            // 
            this.btnSaveRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRecord.Location = new System.Drawing.Point(1097, 425);
            this.btnSaveRecord.Name = "btnSaveRecord";
            this.btnSaveRecord.Size = new System.Drawing.Size(73, 44);
            this.btnSaveRecord.TabIndex = 70;
            this.btnSaveRecord.Text = "Save Record";
            this.btnSaveRecord.UseVisualStyleBackColor = true;
            this.btnSaveRecord.Click += new System.EventHandler(this.btnSaveRecord_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1018, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 44);
            this.btnCancel.TabIndex = 71;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(13, 418);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1158, 2);
            this.label12.TabIndex = 72;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(976, 376);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 22);
            this.txtTotalAmount.TabIndex = 73;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(883, 379);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 15);
            this.label13.TabIndex = 74;
            this.label13.Text = "Total Amount";
            // 
            // hisaDataSet1
            // 
            this.hisaDataSet1.DataSetName = "HisaDataSet1";
            this.hisaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // addToCartBindingSource
            // 
            this.addToCartBindingSource.DataMember = "AddToCart";
            this.addToCartBindingSource.DataSource = this.hisaDataSet1;
            // 
            // addToCartTableAdapter
            // 
            this.addToCartTableAdapter.ClearBeforeFill = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(303, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 15);
            this.label7.TabIndex = 75;
            this.label7.Text = "Search by Item Name";
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 490);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveRecord);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.radNight);
            this.Controls.Add(this.radDay);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRequestBy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridCheckOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.dataGridCart);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Cart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Cart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCheckOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addToCartBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridCart;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridCheckOut;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRequestBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radDay;
        private System.Windows.Forms.RadioButton radNight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSaveRecord;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label13;
        private HisaDataSet1 hisaDataSet1;
        private System.Windows.Forms.BindingSource addToCartBindingSource;
        private HisaDataSet1TableAdapters.AddToCartTableAdapter addToCartTableAdapter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOH1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockValue1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Request1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOH;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockValue;
    }
}