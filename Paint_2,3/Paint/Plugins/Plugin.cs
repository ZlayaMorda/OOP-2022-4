using Paint;

[assembly: Name("Trapeze")]

namespace Plugins
{
    public class Plugin : IPlugin
    {
        public void RunHost(IHost host)
        {
            host.AddPluginToForm("Trapeze");
            host.AddPLuginToDict("Trapeze", new Trapeze(0, 0, 0, 0, Color.Black, 1, Color.AntiqueWhite));
        }
    }
}
