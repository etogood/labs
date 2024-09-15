using System.Windows.Media;

namespace _4.Notes
{
    public class Color(SolidColorBrush brush, string name)
    {
        public SolidColorBrush Brush { get; set; } = brush;
        public string Name { get; set; } = name;
    }
}
