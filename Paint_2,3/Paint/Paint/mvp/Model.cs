using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.mvp
{
    static class Dict
    {
        static internal Dictionary<string, IFigure> FiguresDict = new()
        {
            { "Line", new Line(0, 0, 0, 0, Color.Black, 1, Color.AntiqueWhite) },
            { "BrokenLine", new BrokenLine()},
            { "Rectangle", new Rectangle(0, 0, 0, 0, Color.Black, 1, Color.AntiqueWhite) },
            { "Ellipse", new Ellipse(0, 0, 0, 0, Color.Black, 1, Color.AntiqueWhite)}

        };
    }

    internal class Model
    {
        private int x1;
        private int x2;
        private int y1;
        private int y2;
        private int temp_x1;
        private int temp_y1;
        private int n;
        private float width;
        public string Name;
        IFigure figure;
        private List<Line> lines;
        public Pen pen { get; set; }
        public SolidBrush brush { get; set; }
        public bool IsClicked { get; set; }


        
        public Model(IPaint paint)
        {
            IsClicked = false;
            Name = paint.Name;
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
            temp_x1 = 0;
            temp_y1 = 0;
            n = 0;
            width = paint.Width;
            lines = new List<Line>();
            if (paint.Name == "BrokenLine")
            {
                this.figure = Dict.FiguresDict["Line"];
            }
            else { this.figure = Dict.FiguresDict[paint.Name]; }
            pen = new Pen(paint.LineColor);
            brush = new SolidBrush(paint.BrushColor);
        }
        public void FillModel(IPaint paint)
        {
            Name = paint.Name;
            IsClicked = false;
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
            temp_x1 = 0;
            temp_y1 = 0;
            n = 0;
            width = paint.Width;
            lines = new List<Line>();
            if (paint.Name == "BrokenLine")
            {
                this.figure = Dict.FiguresDict["Line"];
            }
            else { this.figure = Dict.FiguresDict[paint.Name]; }
            pen = new Pen(paint.LineColor);
            brush = new SolidBrush(paint.BrushColor);
        }


        public void MoveForLine(int eX, int eY)
        {
            x2 = eX;
            y2 = eY;
        }

        public void MoveOtherShit(int eX, int eY)
        {
            if (eX - temp_x1 > 0 && eY - temp_y1 > 0)
            {
                x1 = temp_x1;
                y1 = temp_y1;
                x2 = eX - temp_x1;
                y2 = eY - temp_y1;
            }
            if (eX - temp_x1 < 0 && eY - temp_y1 > 0)
            {
                x1 = eX;
                y1 = temp_y1;
                x2 = temp_x1 - eX;
                y2 = eY - temp_y1;
            }
            if (eX - temp_x1 > 0 && eY - temp_y1 < 0)
            {
                x1 = temp_x1;
                y1 = eY;
                x2 = eX - temp_x1;
                y2 = temp_y1 - eY;
            }
            if (eX - temp_x1 < 0 && eY - temp_y1 < 0)
            {
                x1 = eX;
                y1 = eY;
                x2 = temp_x1 - eX;
                y2 = temp_y1 - eY;
            }
        }

        public void Paint(Graphics graphics, List<IFigure> list)
        {
            foreach(IFigure figure in list)
            {
                figure.Draw(graphics);
            }

            if (Name == "BrokenLine")
            {
                foreach (Line f in lines)
                {
                    f.Draw(graphics);
                }
                figure.CreateFigure(x1, y1, x2, y2, pen.Color, this.width, brush.Color);
                figure.Draw(graphics);
            }
            else
            {
                figure.CreateFigure(x1, y1, x2, y2, pen.Color, this.width, brush.Color);
                figure.Draw(graphics);
            }

        }

        public void Click(int eX, int eY, List<IFigure> list)
        {
            n++;
            if (n != 2)
            {
                IsClicked = true;
                x1 = eX;
                y1 = eY;
                temp_x1 = x1;
                temp_y1 = y1;
            }
            else
            {
                if (Name == "BrokenLine")
                {
                    lines.Add((Line)figure.CreateFigure(x1, y1, x2, y2, pen.Color, this.width, brush.Color));
                    n = 1;
                    IsClicked = true;
                    x1 = eX;
                    y1 = eY;
                }
                else
                {
                    IsClicked = false;
                    list.Add(figure.CreateFigure(x1, y1, x2, y2, pen.Color, this.width, brush.Color));
                    n = 0;
                    x1 = 0;
                    y1 = 0;
                    x2 = 0;
                    y2 = 0;
                }
            }
        }

        public void DoubleClick(List<IFigure> list)
        {
            if (Name == "BrokenLine")
            {
                IsClicked = false;
                n = 0;
                BrokenLine temp_figure = new(lines);
                lines = new List<Line>();
                list.Add(temp_figure);
                x1 = 0;
                y1 = 0;
                x2 = 0;
                y2 = 0;
            }
        }


    }
}
