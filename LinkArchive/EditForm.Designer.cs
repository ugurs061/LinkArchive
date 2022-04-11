namespace LinkArchive
{
    partial class EditForm
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
            this.cBoxKategori = new System.Windows.Forms.ComboBox();
            this.lblKategori = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.txtTittle = new System.Windows.Forms.TextBox();
            this.lblLink = new System.Windows.Forms.Label();
            this.lblTittle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cBoxKategori
            // 
            this.cBoxKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cBoxKategori.FormattingEnabled = true;
            this.cBoxKategori.Items.AddRange(new object[] {
            "Özel",
            "Eğitim",
            "İş"});
            this.cBoxKategori.Location = new System.Drawing.Point(147, 167);
            this.cBoxKategori.Name = "cBoxKategori";
            this.cBoxKategori.Size = new System.Drawing.Size(222, 33);
            this.cBoxKategori.TabIndex = 15;
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKategori.Location = new System.Drawing.Point(10, 167);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(119, 29);
            this.lblKategori.TabIndex = 14;
            this.lblKategori.Text = "Kategori:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.Location = new System.Drawing.Point(381, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(207, 69);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEdit.Location = new System.Drawing.Point(134, 242);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(207, 69);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtLink
            // 
            this.txtLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLink.Location = new System.Drawing.Point(147, 101);
            this.txtLink.Multiline = true;
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(454, 39);
            this.txtLink.TabIndex = 11;
            // 
            // txtTittle
            // 
            this.txtTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTittle.Location = new System.Drawing.Point(147, 36);
            this.txtTittle.Multiline = true;
            this.txtTittle.Name = "txtTittle";
            this.txtTittle.Size = new System.Drawing.Size(454, 39);
            this.txtTittle.TabIndex = 10;
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLink.Location = new System.Drawing.Point(61, 105);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(68, 29);
            this.lblLink.TabIndex = 9;
            this.lblLink.Text = "Link:";
            // 
            // lblTittle
            // 
            this.lblTittle.AutoSize = true;
            this.lblTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTittle.Location = new System.Drawing.Point(49, 36);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(80, 29);
            this.lblTittle.TabIndex = 8;
            this.lblTittle.Text = "Tittle:";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 328);
            this.Controls.Add(this.cBoxKategori);
            this.Controls.Add(this.lblKategori);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.txtTittle);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblTittle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxKategori;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.TextBox txtTittle;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.Label lblTittle;
    }
}