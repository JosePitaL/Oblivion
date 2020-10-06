using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Windows.Controls;

namespace Studio.Model
{
    public class MyTabItem : TabItem
    {
        public ItemsControl itemsControl { get; set; }
        public Canvas canvas { get; set; }
        public ScrollViewer scrollViewer { get; set; }
        public ObservableCollection<MacroUCViewModel> macroUCViewModels { get; set; }

        public MyTabItem(ItemsControl itemsControl, Canvas canvas, ScrollViewer scrollViewer, ObservableCollection<MacroUCViewModel> macroUCViewModels) : base()
        {
            this.itemsControl = itemsControl;
            this.canvas = canvas;
            this.scrollViewer = scrollViewer;
            this.macroUCViewModels = macroUCViewModels;

            
            itemsControl.ItemsSource = macroUCViewModels;
            canvas.Children.Add(itemsControl);
            scrollViewer.Content = canvas;
            this.Content = scrollViewer;
        } 
    }  
}
