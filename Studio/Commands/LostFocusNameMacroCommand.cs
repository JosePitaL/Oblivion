using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.Commands
{
    class LostFocusNameMacroCommand : ICommand
    {
        public LostFocusNameMacroCommand(MacroUCViewModel macroUC)
        {
            this.macroUC = macroUC;
        }

        public MacroUCViewModel macroUC { get; set; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            macroUC.FocusableNameMacro = false;
        }
    }
}
