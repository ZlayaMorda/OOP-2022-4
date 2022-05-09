using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.mvp
{
    internal class Presenter
    {
        IPaint ViewPresenter { get; set; }
        internal Model Model { get; set; }
        Storage Storage { get; set; }

        internal Presenter(IPaint paint)
        {
            ViewPresenter = paint;
            this.Model = new(paint);
            Storage = new();
        }

        internal void ReloadView(IPaint paint)
        {
            ViewPresenter = paint;
            Model.FillModel(paint);
        }
        internal void MoveForLine(int X, int Y)
        {
            Model.MoveForLine(X, Y);
        }
        internal void Click(int X, int Y)
        {
            Model.Click(X, Y, Storage.figures);
        }
        internal void Paint(Graphics graphics)
        {
            Model.Paint(graphics, Storage.figures);
        }
        internal void DoubleClick()
        {
            Model.DoubleClick(Storage.figures);
        }
    }
}
