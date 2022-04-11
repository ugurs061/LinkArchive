namespace LinkArchive
{
    partial class HomePage
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
            this.lblLink = new System.Windows.Forms.Label();
            this.lblTittle = new System.Windows.Forms.Label();
            this.txtTittle = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxKategori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGVTablo = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVTablo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLink.Location = new System.Drawing.Point(55, 84);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(63, 29);
            this.lblLink.TabIndex = 0;
            this.lblLink.Text = "Link:";
            // 
            // lblTittle
            // 
            this.lblTittle.AutoSize = true;
            this.lblTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTittle.Location = new System.Drawing.Point(45, 28);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(73, 29);
            this.lblTittle.TabIndex = 1;
            this.lblTittle.Text = "Tittle:";
            // 
            // txtTittle
            // 
            this.txtTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTittle.Location = new System.Drawing.Point(124, 28);
            this.txtTittle.Multiline = true;
            this.txtTittle.Name = "txtTittle";
            this.txtTittle.Size = new System.Drawing.Size(368, 33);
            this.txtTittle.TabIndex = 2;
            // 
            // txtLink
            // 
            this.txtLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLink.Location = new System.Drawing.Point(124, 84);
            this.txtLink.Multiline = true;
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(368, 33);
            this.txtLink.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearch.Location = new System.Drawing.Point(562, 121);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(149, 47);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxKategori);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTittle);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblLink);
            this.groupBox1.Controls.Add(this.txtLink);
            this.groupBox1.Controls.Add(this.txtTittle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 194);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // cBoxKategori
            // 
            this.cBoxKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cBoxKategori.FormattingEnabled = true;
            this.cBoxKategori.Items.AddRange(new object[] {
            "Özel",
            "Eğitim",
            "İş",
            "Okul"});
            this.cBoxKategori.Location = new System.Drawing.Point(124, 139);
            this.cBoxKategori.Name = "cBoxKategori";
            this.cBoxKategori.Size = new System.Drawing.Size(185, 33);
            this.cBoxKategori.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kategori:";
            // 
            // dataGVTablo
            // 
            this.dataGVTablo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVTablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVTablo.Location = new System.Drawing.Point(12, 220);
            this.dataGVTablo.Name = "dataGVTablo";
            this.dataGVTablo.ReadOnly = true;
            this.dataGVTablo.RowHeadersWidth = 62;
            this.dataGVTablo.RowTemplate.Height = 28;
            this.dataGVTablo.Size = new System.Drawing.Size(766, 303);
            this.dataGVTablo.TabIndex = 6;
            this.dataGVTablo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVTablo_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdd.Location = new System.Drawing.Point(114, 542);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 52);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEdit.Location = new System.Drawing.Point(312, 542);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(151, 52);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Location = new System.Drawing.Point(514, 542);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 52);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 615);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGVTablo);
            this.Controls.Add(this.groupBox1);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Link Archive";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVTablo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.Label lblTittle;
        private System.Windows.Forms.TextBox txtTittle;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGVTablo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cBoxKategori;
        private System.Windows.Forms.Label label1;
    }
}

