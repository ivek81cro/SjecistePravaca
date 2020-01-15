using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Graph_lines
{

    /// <summary>
    ///   Delegat koji predstavlja metodu koju možemo dodati panelu.
    /// </summary>
    public delegate double Function(double x);
    public delegate double Function2(double x);

    /// <summary>
    ///   Panel koji iscrtava funkcije zadane Function delegatom.
    /// </summary>
    public class FunctionPanel : System.Windows.Forms.Panel {

        public FunctionPanel() {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private Function m_function;
        private Function2 m_function2;

        private RectangleF m_displayBounds = new RectangleF(-5, -5, 100, 100);

        public Function Function {
            set { m_function = value; }
        }
        public Function2 Function2
        {
            set { m_function2 = value; }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            DrawCoordinateSystem(e.Graphics);
            DrawFunction(e.Graphics);
            DrawFunction2(e.Graphics);
        }

        private void DrawFunction(Graphics graphics) {
            if (m_function != null) {
                using (Pen pen = new Pen(Color.Blue)) {
                    Point[] points = new Point[ClientRectangle.Width];
                    for (int i = 0; i < ClientRectangle.Width; i++) {
                        double x = CartesianX(i);
                        double y = m_function(x);
                        int y0 = ScreenY(y);
                        points[i] = new Point(i, y0);
                    }
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.DrawCurve(pen, points);
                }
            }
        }

        private void DrawFunction2(Graphics graphics)
        {
            if (m_function != null)
            {
                using (Pen pen = new Pen(Color.Red))
                {
                    Point[] points = new Point[ClientRectangle.Width];
                    for (int i = 0; i < ClientRectangle.Width; i++)
                    {
                        double x = CartesianX(i);
                        double y = m_function2(x);
                        int y0 = ScreenY(y);
                        points[i] = new Point(i, y0);
                    }
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.DrawCurve(pen, points);
                }
            }
        }

        private double CartesianX(int x) {
            return ((double)x / (ClientRectangle.Width / 2) - 1) * (m_displayBounds.Width / 2);
        }

        public int ScreenY(double y) {
            return (int)((1 - y / (m_displayBounds.Height / 2)) * ClientRectangle.Height / 2);
        }

        private void DrawCoordinateSystem(Graphics graphics) {
            using (Pen pen = new Pen(Color.Gray)) {
                MarkAxes(graphics, pen);
                graphics.DrawLine(pen, 0, ClientRectangle.Height / 2, 
					ClientRectangle.Width, ClientRectangle.Height / 2);
                graphics.DrawLine(pen, ClientRectangle.Width / 2, 0, 
					ClientRectangle.Width / 2, ClientRectangle.Height);
            }
        }

        private void MarkAxes(Graphics graphics, Pen pen) {
            using (Pen penGrid = new Pen(Color.LightGray)) {
                penGrid.DashStyle = DashStyle.Dot;
                MarkXAxes(graphics, pen, penGrid);
                MarkYAxes(graphics, pen, penGrid);
            }
        }

        private void MarkXAxes(Graphics graphics, Pen pen, Pen penGrid) {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int y0 = ScreenY(0) - 10;
            int y1 = ScreenY(0) + 10;
            double x = -m_displayBounds.Width;
            double increment = m_displayBounds.Width / 10;
            while (x <= m_displayBounds.Width) {
                int xScr = ScreenX(x);
                graphics.DrawLine(penGrid, xScr, 0, xScr, this.Height);
                graphics.DrawLine(pen, xScr, y0, xScr, y1);
                float y = ScreenY(0);
                SizeF labelSize = graphics.MeasureString(x.ToString(), drawFont);
                //if (DaLiJeCijeliUnutarPanela(new Point((int)(xScr - labelSize.Width / 2), (int)(y + 3)), labelSize)) {
                    graphics.DrawString(x.ToString(), drawFont, drawBrush, xScr - labelSize.Width / 2 , y + 3); 
                //}
                x += increment;
            }
        }

        private void MarkYAxes(Graphics graphics, Pen pen, Pen penGrid) {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int x0 = ScreenX(0) - 10;
            int x1 = ScreenX(0) + 10;
            double y = -m_displayBounds.Height;
            double increment = m_displayBounds.Height / 10;
            while (y <= m_displayBounds.Height) {
                int yScr = ScreenY(y);
                graphics.DrawLine(penGrid, 0, yScr, this.Width, yScr); 
                graphics.DrawLine(pen, x0, yScr, x1, yScr);
                SizeF labelSize = graphics.MeasureString(y.ToString(), drawFont);
                //if (DaLiJeCijeliUnutarPanela(new Point(X1, (int)(Yscr - velicina.Height / 2)), velicina)) {
                    graphics.DrawString(y.ToString(), drawFont, drawBrush, x1, yScr - labelSize.Height / 2);
                //}
                y += increment;
            }
        }

        public int ScreenX(double x) {
            return (int)((x / (m_displayBounds.Width / 2) + 1) * ClientRectangle.Width / 2);
        }
    
	}
}