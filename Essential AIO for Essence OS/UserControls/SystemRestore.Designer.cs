namespace Essential_AIO_for_Essence_OS.UserControls
{
    partial class SystemRestore
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles do UserControl
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvRestorePoints;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.Button btnCreateRestorePoint;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnManageSpace;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lvRestorePoints = new ListView();
            chDate = new ColumnHeader();
            chDescription = new ColumnHeader();
            btnCreateRestorePoint = new Button();
            btnRestore = new Button();
            btnManageSpace = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Verdana", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.WhiteSmoke;
            lblTitle.Location = new Point(154, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(224, 29);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "System Restore";
            // 
            // lvRestorePoints
            // 
            lvRestorePoints.BackColor = Color.Black;
            lvRestorePoints.BorderStyle = BorderStyle.None;
            lvRestorePoints.Columns.AddRange(new ColumnHeader[] { chDate, chDescription });
            lvRestorePoints.ForeColor = Color.WhiteSmoke;
            lvRestorePoints.FullRowSelect = true;
            lvRestorePoints.Location = new Point(0, 71);
            lvRestorePoints.Name = "lvRestorePoints";
            lvRestorePoints.Size = new Size(546, 342);
            lvRestorePoints.TabIndex = 1;
            lvRestorePoints.UseCompatibleStateImageBehavior = false;
            lvRestorePoints.View = View.Details;
            // 
            // chDate
            // 
            chDate.Text = "Date";
            chDate.Width = 150;
            // 
            // chDescription
            // 
            chDescription.Text = "Description";
            chDescription.Width = 240;
            // 
            // btnCreateRestorePoint
            // 
            btnCreateRestorePoint.BackColor = Color.DimGray;
            btnCreateRestorePoint.FlatAppearance.BorderSize = 0;
            btnCreateRestorePoint.FlatStyle = FlatStyle.Flat;
            btnCreateRestorePoint.ForeColor = Color.WhiteSmoke;
            btnCreateRestorePoint.Location = new Point(201, 419);
            btnCreateRestorePoint.Name = "btnCreateRestorePoint";
            btnCreateRestorePoint.Size = new Size(150, 35);
            btnCreateRestorePoint.TabIndex = 2;
            btnCreateRestorePoint.Text = "Create Restore Point";
            btnCreateRestorePoint.UseVisualStyleBackColor = false;
            btnCreateRestorePoint.Click += BtnCreateRestorePoint_Click;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.DimGray;
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.ForeColor = Color.WhiteSmoke;
            btnRestore.Location = new Point(0, 419);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(150, 35);
            btnRestore.TabIndex = 3;
            btnRestore.Text = "Restore";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += BtnRestore_Click;
            // 
            // btnManageSpace
            // 
            btnManageSpace.BackColor = Color.DimGray;
            btnManageSpace.FlatAppearance.BorderSize = 0;
            btnManageSpace.FlatStyle = FlatStyle.Flat;
            btnManageSpace.ForeColor = Color.WhiteSmoke;
            btnManageSpace.Location = new Point(396, 419);
            btnManageSpace.Name = "btnManageSpace";
            btnManageSpace.Size = new Size(150, 35);
            btnManageSpace.TabIndex = 4;
            btnManageSpace.Text = "Manage Space";
            btnManageSpace.UseVisualStyleBackColor = false;
            btnManageSpace.Click += BtnManageSpace_Click;
            // 
            // SystemRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(btnManageSpace);
            Controls.Add(btnRestore);
            Controls.Add(btnCreateRestorePoint);
            Controls.Add(lvRestorePoints);
            Controls.Add(lblTitle);
            Name = "SystemRestore";
            Size = new Size(546, 454);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}