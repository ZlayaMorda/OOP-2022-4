
namespace Paint.Plugins
{
    public class Trapeze : IFigure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public string Name { get; set; }

        public Trapeze(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
            this.Name = "Trapeze";
        }
        IFigure IFigure.CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor, string Name)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
            return new Trapeze(x1, y1, x2, y2, PenColor, PenWidth, BrushColor);
        }

        public void Draw(Graphics graphics)
        {
            int lengthDown = Math.Abs(x2 - x1);
            int lengthUp = Math.Abs((x2 - x1) / 2);
            Pen pen = new Pen(PenColor, PenWidth);
            SolidBrush brush = new SolidBrush(BrushColor);
            int height = Math.Abs((lengthDown - lengthUp) / 2);
            if (lengthDown - lengthUp > 0)
            {
                Point[] points = { new Point(x1, y1), new Point(x1 + height, y1 - height), new Point(x1 + lengthDown - height, y1 - height), new Point(x1 + lengthDown, y1) };
                graphics.DrawPolygon(pen, points);
                if (pen.Width % 2 != 0)
                {
                    Point[] points2 = { new Point(x1, y1), new Point(x1 + height, y1 - height + 1), new Point(x1 + lengthDown - height, y1 - height), new Point(x1 + lengthDown, y1) };
                    graphics.FillPolygon(brush, points2);
                }
                else
                {
                    graphics.FillPolygon(brush, points);
                }
            }
            else
            {
                Point[] points = { new Point(x1, y1), new Point(x1 + height, y1 + height), new Point(x1 + lengthUp - height, y1 + height), new Point(x1 + lengthUp, y1) };
                graphics.DrawPolygon(pen, points);
                if (pen.Width % 2 != 0)
                {
                    Point[] points2 = { new Point(x1 + 2, y1 + 1), new Point(x1 + height, y1 + height), new Point(x1 + lengthUp - height, y1 + height), new Point(x1 + lengthUp, y1) };
                    graphics.FillPolygon(brush, points2);
                }
                else
                {
                    graphics.FillPolygon(brush, points);
                }
            }
        }
        IFigure IFigure.CreateFigure(List<Line> lst)
        {
            throw new NotImplementedException();
        }
    }
}
