using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    internal interface IFigure
    { 
        public string Name { get;}
        public void Draw(Graphics g);
    }

    internal class Line : IFigure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public string Name { get; }
        public Line(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            this.Name = "Line";
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(PenColor, PenWidth), new Point(x1, y1), new Point(x2, y2));
        }

    }
}
