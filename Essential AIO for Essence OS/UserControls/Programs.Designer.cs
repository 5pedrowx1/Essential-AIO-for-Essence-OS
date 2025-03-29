namespace Essential_AIO_for_Essence_OS.UserControls
{
    partial class Programs
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanelPackages;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flowLayoutPanelPackages = new FlowLayoutPanel();
            labelTitle = new Label();
            lblDownload = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanelPackages
            // 
            flowLayoutPanelPackages.AutoScroll = true;
            flowLayoutPanelPackages.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelPackages.ForeColor = Color.WhiteSmoke;
            flowLayoutPanelPackages.Location = new Point(0, 72);
            flowLayoutPanelPackages.Name = "flowLayoutPanelPackages";
            flowLayoutPanelPackages.Size = new Size(574, 382);
            flowLayoutPanelPackages.TabIndex = 0;
            flowLayoutPanelPackages.WrapContents = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Verdana", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.WhiteSmoke;
            labelTitle.Location = new Point(179, 28);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(167, 29);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "PROGRAMS";
            // 
            // lblDownload
            // 
            lblDownload.AutoSize = true;
            lblDownload.ForeColor = Color.WhiteSmoke;
            lblDownload.Location = new Point(3, 11);
            lblDownload.Name = "lblDownload";
            lblDownload.Size = new Size(0, 15);
            lblDownload.TabIndex = 3;
            // 
            // Programs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(lblDownload);
            Controls.Add(labelTitle);
            Controls.Add(flowLayoutPanelPackages);
            Name = "Programs";
            Size = new Size(546, 454);
            ResumeLayout(false);
            PerformLayout();
        }
        private Label labelTitle;
        private Label lblDownload;
    }
}