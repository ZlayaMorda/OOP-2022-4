using System.IO;
using System.Reflection;
using System;

namespace Paint
{
    public class PluginManager
    {
        public IPlugin ?AddPlugin = null;
        public void ScanPlugins(string directory, string Name)
        {
            //перебираем все файлы dll
            foreach (var file in Directory.EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories))
            {
                var ass = Assembly.LoadFile(file);



                foreach (CustomAttributeData attributedata in ass.CustomAttributes)
                {

                    foreach (CustomAttributeTypedArgument argumentset in attributedata.ConstructorArguments)
                    {
                        if (argumentset.Value.ToString() == Name)
                        {

                            switch (Name)
                            {
                                case "Trapeze":
                                    if (AddPlugin == null)
                                    {
                                        //перебираем все типы из ассембли
                                        foreach (Type type in ass.GetTypes())
                                        {
                                            //создаем экземпляр плагина
                                            var inter = type.GetInterface("IPlugin");
                                            if (inter != null)
                                                AddPlugin = ass.CreateInstance(type.FullName) as IPlugin;

                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }

            }
        }
    }
}
