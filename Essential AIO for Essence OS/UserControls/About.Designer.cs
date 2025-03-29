namespace Essential_AIO_for_Essence_OS.UserControls
{
    partial class About
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            richTextBoxAbout = new RichTextBox();
            label4 = new Label();
            PicDev1 = new Essential_AIO_for_Essence_OS.Models.PicModel();
            label5 = new Label();
            PicDev2 = new Essential_AIO_for_Essence_OS.Models.PicModel();
            ((System.ComponentModel.ISupportInitialize)PicDev1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicDev2).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Verdana", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.WhiteSmoke;
            labelTitle.Location = new Point(210, 36);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(105, 29);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "ABOUT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 3;
            label1.Text = "MIT License";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 437);
            label2.Name = "label2";
            label2.Size = new Size(119, 14);
            label2.TabIndex = 5;
            label2.Text = "AIO Version: 1.0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(277, 440);
            label3.Name = "label3";
            label3.Size = new Size(266, 14);
            label3.TabIndex = 6;
            label3.Text = "Creators: 5pedrowx1 | Akshay The Best";
            // 
            // richTextBoxAbout
            // 
            richTextBoxAbout.BackColor = Color.Black;
            richTextBoxAbout.BorderStyle = BorderStyle.None;
            richTextBoxAbout.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxAbout.ForeColor = Color.WhiteSmoke;
            richTextBoxAbout.Location = new Point(0, 205);
            richTextBoxAbout.Name = "richTextBoxAbout";
            richTextBoxAbout.ReadOnly = true;
            richTextBoxAbout.Size = new Size(546, 229);
            richTextBoxAbout.TabIndex = 7;
            richTextBoxAbout.Text = "";
            richTextBoxAbout.LinkClicked += RichTextBoxAbout_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(78, 175);
            label4.Name = "label4";
            label4.Size = new Size(96, 18);
            label4.TabIndex = 9;
            label4.Text = "5pedrowx1";
            // 
            // PicDev1
            // 
            PicDev1.BackColor = Color.Transparent;
            PicDev1.Image = Properties.Resources._5pedrowx1;
            PicDev1.Location = new Point(78, 72);
            PicDev1.Name = "PicDev1";
            PicDev1.Size = new Size(100, 100);
            PicDev1.SizeMode = PictureBoxSizeMode.StretchImage;
            PicDev1.TabIndex = 8;
            PicDev1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(310, 175);
            label5.Name = "label5";
            label5.Size = new Size(145, 18);
            label5.TabIndex = 11;
            label5.Text = "Akshay The Best";
            // 
            // PicDev2
            // 
            PicDev2.BackColor = Color.Transparent;
            PicDev2.Image = Properties.Resources.Akshay_The_Best;
            PicDev2.Location = new Point(335, 72);
            PicDev2.Name = "PicDev2";
            PicDev2.Size = new Size(100, 100);
            PicDev2.SizeMode = PictureBoxSizeMode.StretchImage;
            PicDev2.TabIndex = 10;
            PicDev2.TabStop = false;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(label5);
            Controls.Add(PicDev2);
            Controls.Add(label4);
            Controls.Add(PicDev1);
            Controls.Add(richTextBoxAbout);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelTitle);
            ForeColor = Color.WhiteSmoke;
            Name = "About";
            Size = new Size(546, 454);
            ((System.ComponentModel.ISupportInitialize)PicDev1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicDev2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private RichTextBox richTextBoxAbout;
        private Label label4;
        private Models.PicModel PicDev1;
        private Label label5;
        private Models.PicModel PicDev2;
    }
}
