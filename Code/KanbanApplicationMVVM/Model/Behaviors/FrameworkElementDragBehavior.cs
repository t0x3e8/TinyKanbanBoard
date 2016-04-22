using KanbanApplicationMVVM.Service;
using KanbanApplicationMVVM.View.Adorners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Interactivity;

namespace KanbanApplicationMVVM.Model.Behaviors
{
    public class FrameworkElementDragBehavior : Behavior<FrameworkElement>
    {
        private bool isLeftMouseDown = false;
        private bool isDraggingOn = false;
        private DragDropAdorner adorner;

        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
            this.AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
            this.AssociatedObject.GiveFeedback += AssociatedObject_GiveFeedback;
            this.AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.isLeftMouseDown)
            {
                ICardDragable dragingObject = this.AssociatedObject.DataContext as ICardDragable;
                if (dragingObject != null)
                {
                    System.Diagnostics.Debug.WriteLine("mm");

                    this.adorner = new DragDropAdorner(this.AssociatedObject, e.MouseDevice.GetPosition(this.AssociatedObject));
                    var adornerLayer = AdornerLayer.GetAdornerLayer(this.AssociatedObject);
                    adornerLayer.Add(this.adorner);
                    this.AssociatedObject.Visibility = Visibility.Hidden;

                    DataObject data = new DataObject();
                    data.SetData(dragingObject.Type, this.AssociatedObject.DataContext);
                    data.SetData("Card", dragingObject.DragObject);
                    System.Windows.DragDrop.DoDragDrop(this.AssociatedObject, data, DragDropEffects.Move);

                    adornerLayer.Remove(adorner);
                    this.AssociatedObject.Visibility = Visibility.Visible;
                }
            }
        }

        void AssociatedObject_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (this.adorner != null)
                this.adorner.UpdatePosition(this.AssociatedObject.PointFromScreen(MouseHelper.GetMousePosition()));
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
            this.AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave;
            this.AssociatedObject.GiveFeedback -= AssociatedObject_GiveFeedback;
            this.AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }

        void AssociatedObject_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        void AssociatedObject_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.isLeftMouseDown = false;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.isLeftMouseDown = true;
        }
    }
}
