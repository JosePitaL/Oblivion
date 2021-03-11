using Studio.ViewModel;
using System;
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

        public void Execute(object parameter)
        {
            if (macroUCViewModel.Borde == Brushes.Red)
            {
                macroUCViewModel.Borde = Brushes.Black;
            }
            else
            {
                foreach (var item in macroUCViewModel.mainWindowViewModel.ItemLote)
                {
                    foreach (var item1 in item.ListMacro)
                    {
                        item1.Borde = Brushes.Black;
                    }
                }
                macroUCViewModel.Borde = Brushes.Red;  
            }
        }
    }
}
