using Studio.Model;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.Commands
{
    public class SelectedMacroCommand : ICommand
    {
        public MacroUCViewModel macroUCViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public SelectedMacroCommand(MacroUCViewModel macroUCViewModel)
        {
            this.macroUCViewModel = macroUCViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(ObservableCollection<MyTabItem> parameter)
        {
            
        }

        public void Execute(object parameter)
        {
            if (macroUCViewModel.Borde == Brushes.Red)
            {
                macroUCViewModel.Borde = Brushes.Black;
            }
            else
            {
                foreach (var item in macroUCViewModel.mainWindowViewModel.NewTabItem)
                {
                    foreach (var item1 in item.macroUCViewModels)
                    {
                        item1.Borde = Brushes.Black;
                    }
                }
                macroUCViewModel.Borde = Brushes.Red;
                
            }
        }
    }
}
