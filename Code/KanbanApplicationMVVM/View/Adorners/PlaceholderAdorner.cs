using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace KanbanApplicationMVVM.View.Adorners
{
    public class PlaceholderAdorner : Adorner
    {
        public PlaceholderAdorner(UIElement adornedElement) : base(adornedElement) { }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(Brushes.Red, null, new System.Windows.Rect(0, 0, this.Width, this.Height));
        }
    }
}
