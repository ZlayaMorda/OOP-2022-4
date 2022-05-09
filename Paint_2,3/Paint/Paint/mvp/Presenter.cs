
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
        internal void Click(int X, int Y)
        {
            Model.Click(X, Y, Storage);
        }
        internal void Move(int X, int Y)
        {
            if(ViewPresenter.Name == "Line" || ViewPresenter.Name == "BrokenLine")
            {
                Model.MoveForLine(X, Y);
            }
            else
            {
                Model.MoveOtherShit(X, Y);
            }
        }
        internal void Paint(Graphics graphics)
        {
            Model.Paint(graphics, Storage.figures);
        }
        internal void DoubleClick()
        {
            Model.DoubleClick(Storage);
        }
        internal void Before()
        {
            Storage.ReturnBefor();
        }
        internal void After()
        {
            Storage.ReturnAfter();
        }
        internal void Save()
        {
            Serializer.Serialize(Storage.figures);
            Storage.Clear();
        }
    }
}
