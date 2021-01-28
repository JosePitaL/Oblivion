using Studio.View;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.Commands
{
    class LostFocusCaminoCommand : ICommand
    {
        

        public event EventHandler CanExecuteChanged;
        public MacroUCViewModel MacroUCViewModel { get; set; }
        
        public LostFocusCaminoCommand(MacroUCViewModel MacroUCViewModel)
        {
            this.MacroUCViewModel = MacroUCViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            foreach (var item in MacroUCViewModel.mainWindowViewModel.NewTabItem)
            {
                item.CleanLines();
            }
            MacroUCViewModel.mainWindowViewModel.PaintLinesCommand.Execute("");
        }
    }
}
