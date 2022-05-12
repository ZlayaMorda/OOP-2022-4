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
        public Stack<IFigure> stack = new();    

        public void AddToFigures(IFigure figure)
        {
            figures.Add(figure);
            stack.Clear();
        }
        
        public void ReturnBefor()
        {
            try
            {
                stack.Push(figures[figures.Count - 1]);
                figures.RemoveAt(figures.Count - 1);
            }
            catch (ArgumentOutOfRangeException) { }
            
        }
        public void ReturnAfter()
        {
            try
            {
                figures.Add(stack.Pop());
            }
            catch(InvalidOperationException) { }
            
        }
        public void Clear()
        {
            figures.Clear();
            stack.Clear();
        }
    }
}
