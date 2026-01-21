using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienS.Helper_UI
{
    public static class GraphicsHelper
    {
        public static void SetBorderRadius(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // Góc trên trái
            path.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);
            // Cạnh trên
            path.AddLine(radius, 0, panel.Width - radius, 0);
            // Góc trên phải
            path.AddArc(new Rectangle(panel.Width - radius * 2, 0, radius * 2, radius * 2), 270, 90);
            // Cạnh phải
            path.AddLine(panel.Width, radius, panel.Width, panel.Height - radius);
            // Góc dưới phải
            path.AddArc(new Rectangle(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2), 0, 90);
            // Cạnh dưới
            path.AddLine(panel.Width - radius, panel.Height, radius, panel.Height);
            // Góc dưới trái
            path.AddArc(new Rectangle(0, panel.Height - radius * 2, radius * 2, radius * 2), 90, 90);

            path.CloseFigure();
            panel.Region = new Region(path);
        }

        /// <summary>
        /// Bo tròn góc cho Button
        /// </summary>
        public static void SetButtonRadius(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // Góc trên trái
            path.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);
            // Cạnh trên
            path.AddLine(radius, 0, button.Width - radius, 0);
            // Góc trên phải
            path.AddArc(new Rectangle(button.Width - radius * 2, 0, radius * 2, radius * 2), 270, 90);
            // Cạnh phải
            path.AddLine(button.Width, radius, button.Width, button.Height - radius);
            // Góc dưới phải
            path.AddArc(new Rectangle(button.Width - radius * 2, button.Height - radius * 2, radius * 2, radius * 2), 0, 90);
            // Cạnh dưới
            path.AddLine(button.Width - radius, button.Height, radius, button.Height);
            // Góc dưới trái
            path.AddArc(new Rectangle(0, button.Height - radius * 2, radius * 2, radius * 2), 90, 90);

            path.CloseFigure();
            button.Region = new Region(path);
        }
    }
}

