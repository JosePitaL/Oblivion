using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;

namespace Studio.Model
{
    public class MyTabItem : TabItem
    {
        public ItemsControl itemsControl { get; set; }
        public Grid grid { get; set; }
        public ScrollViewer scrollViewer { get; set; }
        public ObservableCollection<MacroUCViewModel> macroUCViewModels { get; set; }

        public MyTabItem(ItemsControl itemsControl, Grid grid, ScrollViewer scrollViewer, ObservableCollection<MacroUCViewModel> macroUCViewModels) : base()
        {
            this.itemsControl = itemsControl;
            this.grid = grid;
            this.scrollViewer = scrollViewer;
            this.macroUCViewModels = macroUCViewModels;

            itemsControl.ItemsSource = macroUCViewModels;
            grid.Children.Add(itemsControl);
            scrollViewer.Content = grid;
            this.Content = scrollViewer;
        } 
    }  
}
