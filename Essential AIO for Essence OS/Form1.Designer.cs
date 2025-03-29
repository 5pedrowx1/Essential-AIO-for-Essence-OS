namespace Essential_AIO_for_Essence_OS
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelMenu = new Panel();
            btnOptionAbout = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnOption1 = new Button();
            btnOption2 = new Button();
            btnOption3 = new Button();
            btnOption4 = new Button();
            btnOption5 = new Button();
            panelContent = new Panel();
            panelTitle = new Panel();
            btnClose = new Button();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.Black;
            panelMenu.Controls.Add(btnOptionAbout);
            panelMenu.Controls.Add(label1);
            panelMenu.Controls.Add(pictureBox1);
            panelMenu.Controls.Add(btnOption1);
            panelMenu.Controls.Add(btnOption2);
            panelMenu.Controls.Add(btnOption3);
            panelMenu.Controls.Add(btnOption4);
            panelMenu.Controls.Add(btnOption5);
            resources.ApplyResources(panelMenu, "panelMenu");
            panelMenu.Name = "panelMenu";
            // 
            // btnOptionAbout
            // 
            btnOptionAbout.BackColor = Color.Black;
            btnOptionAbout.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnOptionAbout, "btnOptionAbout");
            btnOptionAbout.ForeColor = Color.WhiteSmoke;
            btnOptionAbout.Name = "btnOptionAbout";
            btnOptionAbout.UseVisualStyleBackColor = false;
            btnOptionAbout.Click += BtnOptionAbout_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.WhiteSmoke;
            label1.Name = "label1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // btnOption1
            // 
            btnOption1.BackColor = Color.Black;
            btnOption1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnOption1, "btnOption1");
            btnOption1.ForeColor = Color.WhiteSmoke;
            btnOption1.Name = "btnOption1";
            btnOption1.UseVisualStyleBackColor = false;
            btnOption1.Click += BtnOption1_Click;
            // 
            // btnOption2
            // 
            btnOption2.BackColor = Color.Black;
            btnOption2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnOption2, "btnOption2");
            btnOption2.ForeColor = Color.WhiteSmoke;
            btnOption2.Name = "btnOption2";
            btnOption2.UseVisualStyleBackColor = false;
            btnOption2.Click += BtnOption2_Click;
            // 
            // btnOption3
            // 
            btnOption3.BackColor = Color.Black;
            btnOption3.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnOption3, "btnOption3");
            btnOption3.ForeColor = Color.WhiteSmoke;
            btnOption3.Name = "btnOption3";
            btnOption3.UseVisualStyleBackColor = false;
            btnOption3.Click += BtnOption3_Click;
            // 
            // btnOption4
            // 
            btnOption4.BackColor = Color.Black;
            btnOption4.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnOption4, "btnOption4");
            btnOption4.ForeColor = Color.WhiteSmoke;
            btnOption4.Name = "btnOption4";
            btnOption4.UseVisualStyleBackColor = false;
            btnOption4.Click += BtnOption4_Click;
            // 
            // btnOption5
            // 
            btnOption5.BackColor = Color.Black;
            btnOption5.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnOption5, "btnOption5");
            btnOption5.ForeColor = Color.WhiteSmoke;
            btnOption5.Name = "btnOption5";
            btnOption5.UseVisualStyleBackColor = false;
            btnOption5.Click += BtnOption5_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Black;
            resources.ApplyResources(panelContent, "panelContent");
            panelContent.Name = "panelContent";
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.DimGray;
            panelTitle.Controls.Add(btnClose);
            resources.ApplyResources(panelTitle, "panelTitle");
            panelTitle.Name = "panelTitle";
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.ForeColor = Color.Red;
            btnClose.Name = "btnClose";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += Button1_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Controls.Add(panelTitle);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Form1";
            Load += Form1_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitle.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button btnOption1;
        private System.Windows.Forms.Button btnOption2;
        private System.Windows.Forms.Button btnOption3;
        private System.Windows.Forms.Button btnOption4;
        private System.Windows.Forms.Button btnOption5;
        private System.Windows.Forms.Button btnOptionAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Button btnClose;
    }
}