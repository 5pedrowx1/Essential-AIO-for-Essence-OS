// PackageItem.Designer.cs
namespace Essential_AIO_for_Essence_OS.UserControls
{
    partial class PackageItem
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelTitle;
        private TextBox textBoxDescription;
        private Button btnDownload;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxDescription = new TextBox();
            labelTitle = new Label();
            btnDownload = new Button();
            pictureBoxIcon = new Essential_AIO_for_Essence_OS.Models.PicModel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.Black;
            textBoxDescription.BorderStyle = BorderStyle.None;
            textBoxDescription.CausesValidation = false;
            textBoxDescription.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDescription.ForeColor = Color.WhiteSmoke;
            textBoxDescription.HideSelection = false;
            textBoxDescription.Location = new Point(68, 17);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.ShortcutsEnabled = false;
            textBoxDescription.Size = new Size(423, 41);
            textBoxDescription.TabIndex = 2;
            textBoxDescription.Text = "Description";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.WhiteSmoke;
            labelTitle.Location = new Point(68, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(42, 14);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Title";
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.Black;
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.ForeColor = Color.WhiteSmoke;
            btnDownload.Image = Properties.Resources.Donwload;
            btnDownload.Location = new Point(497, 17);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(43, 41);
            btnDownload.TabIndex = 3;
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += BtnDownload_Click;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Location = new Point(3, 3);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(59, 63);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxIcon.TabIndex = 4;
            pictureBoxIcon.TabStop = false;
            // 
            // PackageItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(pictureBoxIcon);
            Controls.Add(btnDownload);
            Controls.Add(textBoxDescription);
            Controls.Add(labelTitle);
            Name = "PackageItem";
            Size = new Size(543, 69);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Models.PicModel pictureBoxIcon;
    }
}
