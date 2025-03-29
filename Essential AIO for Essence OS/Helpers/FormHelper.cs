using System.Runtime.InteropServices;

namespace Essential_AIO_for_Essence_OS.Helpers
{
    public static class FormHelper
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public static void ArredondarBordasForm(Form form, int raio)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, raio, raio));
        }

        public static void ArredondarBotao(Button botao, int raio)
        {
            botao.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, botao.Width, botao.Height, raio, raio));
        }

        public static void HabilitarMovimento(Form form, Control controle)
        {
            controle.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }
    }
}