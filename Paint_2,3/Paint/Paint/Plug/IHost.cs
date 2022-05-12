using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public interface IHost
    {
        public void AddPluginToForm(string pluginName);
        public void AddPLuginToDict(string Name, IFigure figure);
    }
}
