using Studio.Model;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Studio.Commands
{
    public class AddTabItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainWindowViewModel viewModel { get; set; }

        public AddTabItemCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.viewModel.NewTabItem = new ObservableCollection<MyTabItem>(); 
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MyTabItem tab = new MyTabItem(new ItemsControl(), new Canvas(), new ScrollViewer(),new ObservableCollection<MacroUCViewModel>());
            viewModel.NewTabItem.Add(tab);
        }
    }
}
