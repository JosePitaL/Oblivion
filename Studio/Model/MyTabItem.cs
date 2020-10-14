using Studio.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Studio.Model
{
    public class MyTabItem : TabItem
    {
        public ItemsControl itemsControl { get; set; }
        public Canvas canvas { get; set; }
        public ScrollViewer scrollViewer { get; set; }
        public Thumb thumb { get; set; }
        public ObservableCollection<MacroUCViewModel> macroUCViewModels { get; set; }

        public MyTabItem(ItemsControl itemsControl, Canvas canvas, ScrollViewer scrollViewer, ObservableCollection<MacroUCViewModel> macroUCViewModels) : base()
        {
            this.itemsControl = itemsControl;
            this.canvas = canvas;
            this.thumb = thumb;
            this.scrollViewer = scrollViewer;
            this.macroUCViewModels = macroUCViewModels;

            canvas.Width = double.MaxValue;
            canvas.Height = double.MaxValue;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;



            itemsControl.ItemsSource = macroUCViewModels;
            canvas.Children.Add(itemsControl);
            scrollViewer.Content = canvas;
            this.Content = scrollViewer;
           
        }
        
    }  
}
