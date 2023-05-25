using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace year9DTC_Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bodyPanel.Paint += bodyPanel_Paint;
        }
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            // Create a new GraphicsPath object to hold the rounded rectangle path
            GraphicsPath roundedRect = new GraphicsPath();

            // Add the arcs that define the top left and top right corners of the rectangle
            roundedRect.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            roundedRect.AddLine(rect.X + radius, rect.Y, rect.X + rect.Width - radius * 2, rect.Y);

            // Add the arcs that define the bottom right and bottom left corners of the rectangle
            roundedRect.AddArc(rect.X + rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            roundedRect.AddLine(rect.X + rect.Width, rect.Y + radius * 2, rect.X + rect.Width, rect.Y + rect.Height - radius * 2);
            roundedRect.AddArc(rect.X + rect.Width - radius * 2, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            roundedRect.AddLine(rect.X + rect.Width - radius * 2, rect.Y + rect.Height, rect.X + radius * 2, rect.Y + rect.Height);

            // Add the arc that defines the top left corner of the rectangle and close the path
            roundedRect.AddArc(rect.X, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Y + rect.Height - radius * 2, rect.X, rect.Y + radius * 2);
            roundedRect.CloseFigure();

            // Return the GraphicsPath object that defines the rounded rectangle shape
            return roundedRect;
        }

        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = bodyPanel.ClientRectangle;
            int radius = 30;
            GraphicsPath path = GetRoundedRectanglePath(rect, radius);
            bodyPanel.Region = new Region(path);
        }
    }
}
