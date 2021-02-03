using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.Commands
{
    public class EditNameMacroCommand : ICommand
    {   
        public MacroUCViewModel macroUCViewModel { get; set; }
        public EditNameMacroCommand(MacroUCViewModel macroUCViewModel)
        {
            this.macroUCViewModel = macroUCViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            macroUCViewModel.FocusableNameMacro = true;
        }
    }
}
