using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Essential_AIO_for_Essence_OS.Models
{
    public class PicModel : PictureBox
    {
        public PicModel()
        {
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Atualiza a região do controle para uma elipse que ocupa todo o controle.
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new Region(gp);
            }
        }
    }
}