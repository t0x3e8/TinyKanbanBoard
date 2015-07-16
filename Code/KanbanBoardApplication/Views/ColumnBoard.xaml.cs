using KanbanBoardApplication.Model;
using KanbanBoardApplication.Model.Database;
using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ColumnBoard.xaml
    /// </summary>
    public partial class ColumnBoard : ItemsControl, ICardsBoard, INotifyPropertyChanged
    {
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(ColumnBoard));
        public event PropertyChangedEventHandler PropertyChanged;
        private string newCardText = null;

        public string Header {
            get { return (string)this.GetValue(HeaderProperty); }
            set { this.SetValue(HeaderProperty, value); }
        }

        public string NewCardText
        {
            get { return this.newCardText; }
            set
            {
                if (this.newCardText != value)
                {
                    this.newCardText = value;
                    this.NotifyPropertyChanged("NewCardText");
                }
            }
        }

        public ColumnBoard()
        {
            InitializeComponent();
            this.DragOver += this.Board_DragOver;
            this.Drop += this.Board_Drop;
        }

        private void NewCardButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.NewCardText))
            {
                (this.ItemsSource as IList<Card>).Add(new Card() { Text = this.NewCardText });
                this.NewCardText = null;
            }
        }

        private void Board_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Object"))
            {
                e.Effects = DragDropEffects.Move;
            }
        }

        private void Board_Drop(object sender, DragEventArgs e)
        {
            if (e.Handled == false)
            {
                Column targetColumn = (Column)this.DataContext;
                Card draggedCard = (Card)e.Data.GetData("Object");
                

                //ItemsControl targetControl = (ItemsControl)sender;
                //UIElement sourceElement = (UIElement)e.Data.GetData("Object");

                //if (targetControl != null && sourceElement != null)
                //{
                //    // Get the panel that the element currently belongs to, 
                //    // then remove it from that panel and add it the Children of 
                //    // the panel that its been dropped on.
                //    ItemsControl sourceElementContainer = (ItemsControl)(sourceElement as CardControl).Parent;
                    
                //    if (sourceElementContainer != null)
                //    {
                //        if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                //        {
                //            sourceElementContainer.Items.Remove(sourceElement);
                //            targetControl.Items.Add(sourceElement);
                //            // set the value to return to the DoDragDrop call
                //            e.Effects = DragDropEffects.Move;
                //        }
                //    }
                //}
            }
        }

        //private void Board_DragLeave(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent("Object"))
        //    {
        //        Panel targetPanel = (Panel)sender;

        //        if (targetPanel != null)
        //            targetPanel.Background = Brushes.White;
        //    }
        //}

        //private void Board_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent("Object"))
        //    {
        //        UIElement sourceElement = (UIElement)e.Data.GetData("Object");
        //        this.ChangeBoardColor(sourceElement);
        //    }
        //}

        //public void HandleOverlappingCards(UIElement bottomCard, UIElement topCard)
        //{
        //    if ((bottomCard is Card) && (bottomCard as Card).IsAnotherCardHoveredOver)
        //    {
        //        int bottomCardIndex = this.Children.IndexOf(bottomCard);
        //        int topCardIndex = this.Children.IndexOf(topCard);

        //        if (topCardIndex != -1)
        //        {
        //            this.Children.RemoveAt(topCardIndex);
        //            this.Children.Insert(bottomCardIndex, topCard);
        //        }
        //    }
        //}

        //public void HandleDragEnter(UIElement card)
        //{
        //    this.ChangeBoardColor(card);
        //}

        //private void ChangeBoardColor(UIElement sourceElement)
        //{
        //    Panel targetPanel = (Panel)this;
        //    Panel sourcePanel = (Panel)VisualTreeHelper.GetParent(sourceElement);

        //    System.Diagnostics.Debug.WriteLine("Target: {0}", targetPanel.ToString());
        //    System.Diagnostics.Debug.WriteLine("Source: {0}", sourcePanel.ToString());

        //    if (targetPanel != null && sourcePanel != null && targetPanel != sourcePanel)
        //        targetPanel.Background = Brushes.WhiteSmoke;
        //}


        //public void HandleDragLeave(UIElement card)
        //{
        //    this.Background = Brushes.White;
        //}

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}