using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KanbanBoardApplication.Views
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        //private DropAdorner adorner;

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CardControl));

        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        //public bool IsAnotherCardHoveredOver { get; private set; }

        public CardControl()
        {
            InitializeComponent();
        }

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);

        //    if (!(e.OriginalSource is TextBox) && e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        this.adorner = new DropAdorner(this, e.GetPosition(this));
        //        AdornerLayer.GetAdornerLayer(this).Add(this.adorner);
        //        this.Visibility = System.Windows.Visibility.Hidden;

        //        DataObject data = new DataObject();
        //        data.SetData("Object", this);

        //        DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
        //        AdornerLayer.GetAdornerLayer(this).Remove(this.adorner);
        //        this.Visibility = System.Windows.Visibility.Visible;
        //    }
        //}

        //protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        //{
        //    base.OnGiveFeedback(e);

        //    if (this.adorner != null)
        //        this.adorner.UpdatePosition(this.PointFromScreen(MouseHelper.GetMousePosition()));

        //    if (e.Effects.HasFlag(DragDropEffects.Move))
        //        Mouse.SetCursor(Cursors.Hand);
        //    else
        //        Mouse.SetCursor(Cursors.Arrow);

        //    e.Handled = true;
        //}

        //protected override void OnDragEnter(DragEventArgs e)
        //{
        //    base.OnDragEnter(e);

        //    this.IsAnotherCardHoveredOver = true;
        //    this.NotifyParent(e.Data.GetData("Object") as Card);

        //    e.Handled = true;
        //}

        //protected override void OnDragLeave(DragEventArgs e)
        //{
        //    base.OnDragLeave(e);

        //    this.IsAnotherCardHoveredOver = false;
        //    if (this.Parent != null && this.Parent is ICardsBoard)
        //    {
        //        ICardsBoard board = this.Parent as ICardsBoard;
        //        board.HandleDragLeave(e.Data.GetData("Object") as Card);
        //    }

        //    e.Handled = true;
        //}

        //protected void NotifyParent(Card draggedCard)
        //{
        //    if (this.Parent != null && this.Parent is ICardsBoard)
        //    {
        //        ICardsBoard board = this.Parent as ICardsBoard;

        //        if (board != null)
        //        {
        //            board.HandleDragEnter(draggedCard);
        //            board.HandleOverlappingCards(this, draggedCard);
        //        }
        //    }
        //}
    }
}
