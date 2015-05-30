using KanbanBoardApplication.UserControls;
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

namespace KanbanBoardApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Board_DragOver(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent("Object"))
            //{
            //    if (e.KeyStates == DragDropKeyStates.ControlKey)
            //    {
            //        e.Effects = DragDropEffects.Copy;
            //    }
            //    else
            //    {
            //        e.Effects = DragDropEffects.Move;
            //    }
            //}
        }

        private void Board_Drop(object sender, DragEventArgs e)
        {
            if (e.Handled == false)
            {
                Panel targetPanel = (Panel)sender;
                UIElement sourceElement = (UIElement)e.Data.GetData("Object");

                if (targetPanel != null && sourceElement != null)
                {
                    // Get the panel that the element currently belongs to, 
                    // then remove it from that panel and add it the Children of 
                    // the panel that its been dropped on.
                    Panel sourceElementParent = (Panel)VisualTreeHelper.GetParent(sourceElement);

                    if (sourceElementParent != null)
                    {
                        if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            sourceElementParent.Children.Remove(sourceElement);
                            targetPanel.Children.Add(sourceElement);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }
        }
    }
}
