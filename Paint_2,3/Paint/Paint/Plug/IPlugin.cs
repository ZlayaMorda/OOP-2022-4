using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public interface IPlugin
    {
        public void RunHost(IHost host);
    }
}
