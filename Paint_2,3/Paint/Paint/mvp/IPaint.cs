using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    internal interface IPaint
    {
        string Name { get; }
        Color LineColor { get; }
        Color BrushColor { get; }
        float Width { get; }
        string PluginName { get; }

    }
}
