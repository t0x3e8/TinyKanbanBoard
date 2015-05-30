using System;
using System.Collections.Generic;
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

namespace KanbanBoardApplication.UserControls
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }

        public Card(Card cardCopy)
        {
            InitializeComponent();

            this.cardUI.Width = cardCopy.cardUI.Width;
            this.cardUI.Height = cardCopy.cardUI.Height;
            this.cardUI.Fill = cardCopy.cardUI.Fill;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);

            if (e.Effects.HasFlag(DragDropEffects.Move))
                Mouse.SetCursor(Cursors.Hand);
            else
                Mouse.SetCursor(Cursors.Arrow);

            e.Handled = true;
        }

        //protected override void OnDrop(DragEventArgs e)
        //{
        //    base.OnDrop(e);

        //    if (e.Data.GetDataPresent(DataFormats.StringFormat))
        //    {
        //        string dataString = e.Data.GetData(DataFormats.StringFormat).ToString();

        //        BrushConverter brushConverter = new BrushConverter();
        //        if (brushConverter.IsValid(dataString))
        //        {
        //            Brush newFill = (Brush)brushConverter.ConvertFromString(dataString);
        //            this.cardUI.Fill = newFill;

        //            if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
        //                e.Effects = DragDropEffects.Copy;
        //            else
        //                e.Effects = DragDropEffects.Move;
        //        }
        //    }

        //    e.Handled = true;
        //}

        //protected override void OnDragOver(DragEventArgs e)
        //{
        //    base.OnDragOver(e);

        //    e.Effects = DragDropEffects.None;

        //    if(e.Data.GetDataPresent(DataFormats.StringFormat))
        //    {
        //        string dataString = e.Data.GetData(DataFormats.StringFormat).ToString();

        //        BrushConverter brushConverter = new BrushConverter();
        //        if (brushConverter.IsValid(dataString))
        //        {
        //            if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
        //                e.Effects = DragDropEffects.Copy;
        //            else
        //                e.Effects = DragDropEffects.Move;
        //        }
        //    }

        //    e.Handled = true;
        //}
    }
}
