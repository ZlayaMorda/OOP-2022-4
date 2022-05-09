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
            { "Line", new Line() }
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
        IFigure figure;
        public Pen pen { get; set; }
        public Graphics g { get; set; }
        public SolidBrush brush { get; set; }
        public bool IsClicked { get; set; }



        public Model(IPaint paint)
        {
            IsClicked = false;
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
            temp_x1 = 0;
            temp_y1 = 0;
            this.figure = Dict.FiguresDict[paint.Name];
            pen = new Pen(paint.LineColor);
            brush = new SolidBrush(paint.BrushColor);
        }

        public void MoveForLine(int eX, int eY)
        {
            x2 = eX;
            y2 = eY;
        }

        public void Paint(Graphics graphics)
        {
            figure.CreateFigure(x1, y1, x2, y2, pen.Color, pen.Width, brush.Color);
            figure.Draw(graphics);
        }

        public void Click(int eX, int eY)
        {
            if (!IsClicked)
            {
                IsClicked = true;
                x1 = eX;
                y1 = eY;
                temp_x1 = x1;
                temp_y1 = y1;
            }
            else
            {
                IsClicked = false;
                x1 = 0;
                y1 = 0;
                x2 = 0;
                y2 = 0;
            }
        }
    }
}
