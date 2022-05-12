
namespace Paint
{
    public class NameAttribute : System.Attribute
    {
        public string Name { get; set; }

        public NameAttribute() { }

        public NameAttribute(string Name)
        {
            this.Name = Name;
        }
    }
}
