using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Essential_AIO_for_Essence_OS.UserControls
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
            OnLoadAbout();
        }

        private void RichTextBoxAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.LinkText!) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o link: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnLoadAbout()
        {
            try
            {
                string licenseFilePath = Path.Combine(Application.StartupPath, "License.txt");
                string licenseText;

                if (File.Exists(licenseFilePath))
                {
                    licenseText = File.ReadAllText(licenseFilePath, Encoding.UTF8);
                }
                else
                {
                    licenseText = @"Essensial AIO © 03/26/2025

Developed by 5pedrowx1 & Akshay The Best, Essensial AIO is an innovative project designed to provide a comprehensive solution for various user needs. Whether for automation, management, or optimization, this software is built to offer convenience and efficiency.

This project is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International. This means you are free to share and adapt the material, as long as you give appropriate credit, do not use it for commercial purposes, and distribute any modifications under the same license.

For more details about the license terms, visit:
🔗 https://creativecommons.org/licenses/by-nc-sa/4.0/";

                    File.WriteAllText(licenseFilePath, licenseText, Encoding.UTF8);
                }

                richTextBoxAbout.Text = licenseText;
                richTextBoxAbout.ScrollBars = RichTextBoxScrollBars.Vertical;
                richTextBoxAbout.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o texto da licença: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}