using Studio.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Studio.Model
{
    public class MyTabItem : TabItem
    {
        public TextBox textBox { get; set; }
        public ItemsControl itemsControl { get; set; }
        public Canvas canvas { get; set; }
        public ScrollViewer scrollViewer { get; set; }
        public ObservableCollection<MacroUCViewModel> macroUCViewModels { get; set; }
        public Lote lote { get; set; }

        public MyTabItem(ItemsControl itemsControl, Canvas canvas, ScrollViewer scrollViewer, ObservableCollection<MacroUCViewModel> macroUCViewModels) : base()
        {
            this.itemsControl = itemsControl;
            this.canvas = canvas;

            this.scrollViewer = scrollViewer;
            this.macroUCViewModels = macroUCViewModels;

            textBox = new TextBox()
            {
                BorderBrush = Brushes.Transparent,
                Focusable = false,
            };
            textBox.MouseDoubleClick += EditTabItem;
            textBox.LostFocus += ChangeFocusable;
            this.Header = textBox;
            
            
            canvas.Width = double.MaxValue;
            canvas.Height = double.MaxValue;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            itemsControl.ItemsSource = macroUCViewModels;
            canvas.Children.Add(itemsControl);


            scrollViewer.Content = canvas;
            this.Content = scrollViewer;
        }

        private void ChangeFocusable(object sender, RoutedEventArgs e)
        {
            textBox.Focusable = false;
        }

        private void EditTabItem(object sender, MouseButtonEventArgs e)
        {
            textBox.Focusable = true;
            textBox.Focus();
        }

        public void CleanLines()
        {
            foreach (var line in this.canvas.Children.OfType<Polyline>().ToList())
            {
                this.canvas.Children.Remove(line);
            }
            foreach (var grid in this.macroUCViewModels)
            {
                grid.WayLotMacro.Children.Clear();
            }
        }
    
    }  
}
