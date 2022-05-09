using Newtonsoft.Json;

namespace Paint
{
    internal static class Serializer
    {
        internal static void Serialize(List<IFigure> list)
        {
            using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + @"\saved_data.json", false))
            {
                foreach (IFigure figure in list)
                {
                    string js = JsonConvert.SerializeObject(figure);
                    MessageBox.Show(js);
                    if (js == "")
                    {
                        return;
                    }
                    writer.WriteLine(js);
                }
            }
        }

    }
}
