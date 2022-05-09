using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    internal class Storage
    {
        public List<IFigure> figures = new();

        public void AddToFigures(IFigure figure)
        {
            figures.Add(figure);
        }
    }
}
