using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiFrame
{
    public static class PictureBoxExtensions
    {

        public static void Center(this System.Windows.Forms.PictureBox p)
        {
            p.Left = (p.Parent.Width - p.Width) / 2;
            p.Top = (p.Parent.Height - p.Height) / 2;
        }

        public static void FitContainer(this System.Windows.Forms.PictureBox p)
        {
            float wratio = (float)p.Parent.Width / (float)p.Image.Width;
            float hratio = (float)p.Parent.Height / (float)p.Image.Height;
            float AdjRatio = (wratio < hratio ? wratio : hratio);

            int width = (int)Math.Round((float)p.Image.Width * AdjRatio);
            int height = (int)Math.Round((float)p.Image.Height * AdjRatio);

            /* Resize PictureBox */
            p.Width = width;
            p.Height = height;

            /* Resize Image in PictureBox */
            Bitmap bm_tmp = new Bitmap(p.Image, width, height);
            bm_tmp.SetResolution(p.Image.HorizontalResolution, p.Image.VerticalResolution);
            Graphics g = Graphics.FromImage(bm_tmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(p.Image, 0, 0, width, height);
            g.Dispose();
            p.Image = bm_tmp;
        }

    }
}
