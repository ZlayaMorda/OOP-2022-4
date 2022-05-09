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
                    if (js == "")
                    {
                        return;
                    }
                    writer.WriteLine(js);
                }
            }
        }
        internal static void Deserialize(Storage list)
        {
            using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + @"\saved_data.json"))
            {
                string js;
                while ((js = reader.ReadLine()) != null)
                {
                    IFigure figure;
                    try
                    {
                        string figure_type = JsonConvert.DeserializeObject<Dictionary<string, string>>(js)["Name"];
                        if (figure_type == "Line")
                        {
                            figure = (Line)JsonConvert.DeserializeObject<Line>(js);
                        }
                        else if (figure_type == "Rectangle")
                        {
                            figure = (Rectangle)JsonConvert.DeserializeObject<Rectangle>(js);
                        }
                        else
                        {
                            figure = (Ellipse)JsonConvert.DeserializeObject<Ellipse>(js);
                        }
                        list.AddToFigures(figure);
                    }
                    catch (Exception ex)
                    { 
                        figure = (BrokenLine)JsonConvert.DeserializeObject<BrokenLine>(js);
                        list.AddToFigures(figure);
                    }
                }
            }
        }

    }
}
