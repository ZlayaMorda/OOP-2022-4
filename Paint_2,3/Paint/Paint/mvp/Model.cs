using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.mvp
{
    internal class Model
    {
        private int x1;
        private int x2;
        private int y1;
        private int y2;
        private int temp_x1;
        private int temp_y1;
        public Pen pen { get; set; }
        public Graphics g { get; set; }
        public SolidBrush brush { get; set; }
        public bool IsClicked { get; set; }

        public Model()
        {
            IsClicked = false;
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
            temp_x1 = 0;
            temp_y1 = 0;
            pen = new Pen(Color.Black);
            brush = new SolidBrush(Color.Transparent);
        }
    }
}
