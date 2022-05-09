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

        internal Presenter(IPaint paint)
        {
            ViewPresenter = paint;
        }

    }
}
