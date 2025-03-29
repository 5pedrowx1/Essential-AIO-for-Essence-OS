using Essential_AIO_for_Essence_OS.Helpers;

namespace Essential_AIO_for_Essence_OS
{
    public partial class VersionSelectionForm : Form
    {
        public string? SelectedVersion { get; private set; }

        public VersionSelectionForm()
        {
            InitializeComponent();
            FormHelper.HabilitarMovimento(this, pnlMover);
            FormHelper.ArredondarBordasForm(this, 30);
            FormHelper.ArredondarBotao(btn64Bit, 15);
            FormHelper.ArredondarBotao(btn64Bit, 15);
            FormHelper.ArredondarBotao(btnClose, 15);
            this.ShowInTaskbar = false;
        }

        private void Btn64Bit_Click(object? sender, EventArgs e)
        {
            SelectedVersion = "64-bit";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn32Bit_Click(object? sender, EventArgs e)
        {
            SelectedVersion = "32-bit";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new(typeof(VersionSelectionForm));
            btn64Bit = new Button();
            btn32Bit = new Button();
            pnlMover = new Panel();
            btnClose = new Button();
            pnlMover.SuspendLayout();
            SuspendLayout();
            // 
            // btn64Bit
            // 
            btn64Bit.FlatAppearance.BorderSize = 0;
            btn64Bit.FlatStyle = FlatStyle.Flat;
            btn64Bit.Location = new Point(12, 30);
            btn64Bit.Name = "btn64Bit";
            btn64Bit.Size = new Size(100, 40);
            btn64Bit.TabIndex = 1;
            btn64Bit.Text = "64-bit";
            btn64Bit.UseVisualStyleBackColor = true;
            btn64Bit.Click += Btn64Bit_Click;
            // 
            // btn32Bit
            // 
            btn32Bit.FlatAppearance.BorderSize = 0;
            btn32Bit.FlatStyle = FlatStyle.Flat;
            btn32Bit.Location = new Point(118, 30);
            btn32Bit.Name = "btn32Bit";
            btn32Bit.Size = new Size(100, 40);
            btn32Bit.TabIndex = 2;
            btn32Bit.Text = "32-bit";
            btn32Bit.UseVisualStyleBackColor = true;
            btn32Bit.Click += Btn32Bit_Click;
            // 
            // pnlMover
            // 
            pnlMover.BackColor = Color.DimGray;
            pnlMover.Controls.Add(btnClose);
            pnlMover.Location = new Point(0, 0);
            pnlMover.Name = "pnlMover";
            pnlMover.Size = new Size(233, 24);
            pnlMover.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(205, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(28, 24);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // VersionSelectionForm
            // 
            BackColor = Color.Black;
            ClientSize = new Size(232, 83);
            Controls.Add(pnlMover);
            Controls.Add(btn64Bit);
            Controls.Add(btn32Bit);
            ForeColor = Color.WhiteSmoke;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon?)resources.GetObject("$this.Icon");
            Name = "VersionSelectionForm";
            Text = "Select Version";
            pnlMover.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Button btn64Bit = null!;
        private Panel pnlMover = null!;
        private Button btnClose = null!;
        private Button btn32Bit = null!;
    }
}