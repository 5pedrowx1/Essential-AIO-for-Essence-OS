using Essential_AIO_for_Essence_OS.UserControls;
using Essential_AIO_for_Essence_OS.Helpers;

namespace Essential_AIO_for_Essence_OS
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            FormHelper.HabilitarMovimento(this, panelTitle);
            FormHelper.ArredondarBordasForm(this, 30);
            FormHelper.ArredondarBotao(btnOption1, 15);
            FormHelper.ArredondarBotao(btnOption2, 15);
            FormHelper.ArredondarBotao(btnOption3, 15);
            FormHelper.ArredondarBotao(btnOption4, 15);
            FormHelper.ArredondarBotao(btnOption5, 15);
            FormHelper.ArredondarBotao(btnOptionAbout, 15);
            FormHelper.ArredondarBotao(btnClose, 15);
        }

        private void BtnOption1_Click(object sender, EventArgs e)
        {
            var sysInfoControl = new Essential_AIO_for_Essence_OS.UserControls.SystemInformation();

            panelContent.Controls.Clear();
            sysInfoControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(sysInfoControl);
        }

        private void BtnOption2_Click(object sender, EventArgs e)
        {
            var RequirdPackControl = new Essential_AIO_for_Essence_OS.UserControls.RequiredPackages();

            panelContent.Controls.Clear();
            RequirdPackControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(RequirdPackControl);
        }

        private void BtnOption3_Click(object sender, EventArgs e)
        {
            var ProgramsControl = new Essential_AIO_for_Essence_OS.UserControls.Programs();

            panelContent.Controls.Clear();
            ProgramsControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ProgramsControl);
        }

        private void BtnOption4_Click(object sender, EventArgs e)
        {
            var Tweaks = new Essential_AIO_for_Essence_OS.UserControls.Tweaks();

            panelContent.Controls.Clear();
            Tweaks.Dock = DockStyle.Fill;
            panelContent.Controls.Add(Tweaks);
        }

        private void BtnOption5_Click(object sender, EventArgs e)
        {
            var SysRestore = new Essential_AIO_for_Essence_OS.UserControls.SystemRestore();

            panelContent.Controls.Clear();
            SysRestore.Dock = DockStyle.Fill;
            panelContent.Controls.Add(SysRestore);
        }

        private void BtnOptionAbout_Click(object sender, EventArgs e)
        {
            var About = new Essential_AIO_for_Essence_OS.UserControls.About();

            panelContent.Controls.Clear();
            About.Dock = DockStyle.Fill;
            panelContent.Controls.Add(About);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var Inicialize = new Essential_AIO_for_Essence_OS.UserControls.SystemInformation();

            panelContent.Controls.Clear();
            Inicialize.Dock = DockStyle.Fill;
            panelContent.Controls.Add(Inicialize);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
