using Essential_AIO_for_Essence_OS.Helpers;

namespace Essential_AIO_for_Essence_OS.UserControls
{
    public partial class PackageItem : UserControl
    {
        private string _category = string.Empty;
        public string Category
        {
            get => _category;
            set => _category = value;
        }

        public required string DownloadUrl64 { get; set; }
        public required string DonwloadUrl86 { get; set; }

        public string Title
        {
            get => labelTitle.Text;
            set => labelTitle.Text = value;
        }

        public string Description
        {
            get => textBoxDescription.Text;
            set => textBoxDescription.Text = value;
        }

        public Image Icon
        {
            get => pictureBoxIcon.Image;
            set
            {
                pictureBoxIcon.Image = value;
                pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public event EventHandler? DownloadClicked;

        public PackageItem()
        {
            InitializeComponent();
            FormHelper.ArredondarBotao(btnDownload, 15);
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            DownloadClicked?.Invoke(this, e);
        }
    }
}