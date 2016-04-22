using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace KanbanApplicationMVVM.Model.Behaviors
{
    public class FrameworkElementDropBehavior : Behavior<FrameworkElement>
    {
        private Type dataType;
        private DragDropAdorner adorner;
        private bool allowDropState;

        protected override void OnAttached()
        {
            base.OnAttached();

            this.allowDropState = this.AssociatedObject.AllowDrop;
            this.AssociatedObject.AllowDrop = true;

            this.AssociatedObject.DragEnter += AssociatedObject_DragEnter;
            this.AssociatedObject.DragLeave += AssociatedObject_DragLeave;
            this.AssociatedObject.DragOver += AssociatedObject_DragOver;
            this.AssociatedObject.Drop += AssociatedObject_Drop;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.AllowDrop = this.allowDropState;

            this.AssociatedObject.DragEnter -= AssociatedObject_DragEnter;
            this.AssociatedObject.DragLeave -= AssociatedObject_DragLeave;
            this.AssociatedObject.DragOver -= AssociatedObject_DragOver;
            this.AssociatedObject.Drop -= AssociatedObject_Drop;
        }

        void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            if (this.dataType != null)
            {
                if (e.Data.GetDataPresent(this.dataType))
                {
                    Card card = e.Data.GetData("Card") as Card;
                    
                    ICardDragable source = e.Data.GetData(this.dataType) as ICardDragable;
                    source.RemoveDragCard(card);

                    ICardDropable target = this.AssociatedObject.DataContext as ICardDropable;
                    target.Drop(card);
                }
            }
        }

        void AssociatedObject_DragOver(object sender, DragEventArgs e)
        {
            if (this.dataType != null)
            {
                if (e.Data.GetDataPresent(this.dataType))
                {
                    this.SetDragDropEffect(e);

                    //if (this.adorner != null)
                    //    this.adorner.Update();
                }
            }
        }

        void AssociatedObject_DragLeave(object sender, DragEventArgs e)
        {
            if (this.adorner != null)
                this.adorner = null;

            e.Handled = true;
        }

        void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            if (this.dataType == null)
            {
                if (this.AssociatedObject.DataContext != null)
                {
                    ICardDropable dropObject = this.AssociatedObject.DataContext as ICardDropable;
                    if (dropObject != null)
                    {
                        this.dataType = dropObject.Type;
                    }
                }
            }

            if (this.adorner == null)
                this.adorner = new DragDropAdorner(sender as UIElement, e.GetPosition(sender as UIElement));

            e.Handled = true;
        }

        private void SetDragDropEffect(DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            if (e.Data.GetDataPresent(this.dataType))
            {
                e.Effects = DragDropEffects.Move;
            }
        }
    }
}
