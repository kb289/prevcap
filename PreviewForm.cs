using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrevCap
{
    public partial class PreviewForm : Form
    {
        public Bitmap Image { get; set; }
        public int BaseX { get; set; }
        public int BaseY { get; set; }
        public int BaseW { get; set; }
        public int BaseH { get; set; }

        public PreviewForm()
        {
            InitializeComponent();
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(BaseW, BaseH);
            Left = 1920 / 2 - Width / 2;
            Top = 1280 / 2 - Height / 2;
            previewPicture.Left = -BaseX;
            previewPicture.Top = -BaseY;
            previewPicture.Image = Image;
        }

        private void PreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Image.Dispose();
        }

        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BaseX = -previewPicture.Left;
            BaseY = -previewPicture.Top;
        }

        private void previewPicture_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreviewForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreviewForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    previewPicture.Top -= 1;
                    break;
                case Keys.Down:
                    previewPicture.Top += 1;
                    break;
                case Keys.Left:
                    previewPicture.Left -= 1;
                    break;
                case Keys.Right:
                    previewPicture.Left += 1;
                    break;
            }
        }
    }
}
