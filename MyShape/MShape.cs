using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace MyShape
{
    public abstract class MShape
    {
        public Brush StrokeBrush { get; set; }
        public double StrokeThickness { get; set; }
        public Brush FillBrush { get; set; }
        public DoubleCollection StrokeDashArray { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public UIElement DrawedElement { get; set; }
        public abstract void Draw(UIElementCollection collection);
        public void Remove(UIElementCollection collection)
        {
            if (DrawedElement != null)
                collection.Remove(DrawedElement);
        }
        public abstract void UpdateShape();

    }
}
