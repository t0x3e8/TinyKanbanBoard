using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace KanbanApplicationMVVM.Model.Behaviors
{
    class DragDropAdorner : Adorner
    {
        private Point offset;
        private Point location;

        public DragDropAdorner(UIElement adornedElement, Point offset) : base(adornedElement)
        {
            this.offset = offset;
        }

        public void UpdatePosition(Point location)
        {
            this.location = location;
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            Point newPosition = location;
            newPosition.X = newPosition.X - this.offset.X;
            newPosition.Y = newPosition.Y - this.offset.Y;

            Pen pen = new Pen(Brushes.LightGray, 2);
            pen.DashStyle = DashStyles.Dash;

            // Size must be increase otherwise dragging card by clicking on border cause problems with detecting where the mouse pointer is on the screen.
            // If the background is not null nor transparent, but filled up with color then dragging does not work since mouse pointer stays on the card.
            drawingContext.DrawRectangle(null, pen, new Rect(newPosition.X - 2, newPosition.Y - 2, this.RenderSize.Width + 4, this.RenderSize.Height + 4));
        }
    }
}
