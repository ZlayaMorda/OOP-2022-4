
namespace Paint
{
    public interface IFigure
    {
        public IFigure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor, string Name = "Name");
        public IFigure CreateFigure(List<Line> lst);
        public void Draw(Graphics g);
    }

    public class Line : IFigure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public string Name { get; set; }
        public Line(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor) 
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
            this.Name = "Line";
        }
        public IFigure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor, string Name = "Line")
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
            return new Line(x1, y1, x2, y2, PenColor, PenWidth, BrushColor);
        }
        public IFigure CreateFigure(List<Line> lst)
        {
            throw new NotImplementedException();
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(PenColor, PenWidth), new Point(x1, y1), new Point(x2, y2));
        }

    }

    internal class BrokenLine : IFigure
    {
        public List<Line>? Lines { get; set; }
        public BrokenLine()
        {

        }
        public BrokenLine(List<Line> lines)
        {
            this.Lines = lines;
        }
        public IFigure CreateFigure(List<Line> lst)
        {
            return new BrokenLine(lst);
        }
        public void Draw(Graphics graphics)
        {
            foreach (Line line in Lines)
            {
                line.Draw(graphics);
            }
        }
        public IFigure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor, string Name = "BrokenLine")
        {
            throw new NotImplementedException();
        }

    }

    internal class Rectangle : IFigure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public string Name { get; set; }
        public Rectangle(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
            this.Name = "Rectangle";
        }
        public IFigure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor, string Name = "Rectangle")
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
            return new Rectangle(x1, y1, x2, y2, PenColor, PenWidth, BrushColor);
        }
        public IFigure CreateFigure(List<Line> lst)
        {
            throw new NotImplementedException();
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(PenColor, PenWidth), x1, y1, x2, y2);
            if (PenWidth % 2 != 0)
            {
                graphics.FillRectangle(new SolidBrush(BrushColor), x1 + 1, y1 + 1, x2 - 1, y2 - 1);
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(BrushColor), x1, y1, x2, y2);
            }
        }
    }

    internal class Ellipse : IFigure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public string Name { get; set; }    
        public Ellipse(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
            this.Name = "Ellipse";
        }
        public IFigure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor, string Name = "Ellipse")
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
            return new Ellipse(x1, y1, x2, y2, PenColor, PenWidth, BrushColor);
        }
        public IFigure CreateFigure(List<Line> lst)
        {
            throw new NotImplementedException();
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(PenColor, PenWidth), x1, y1, x2, y2);
            graphics.FillEllipse(new SolidBrush(BrushColor), x1, y1, x2, y2);
        }
    }
}
