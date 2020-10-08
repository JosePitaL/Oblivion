using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Studio.Commands
{
    public class MoveMacroCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MacroUCViewModel macroUCViewModel { get; set; }

        public MoveMacroCommand(MacroUCViewModel macroUCViewModel)
        {
            this.macroUCViewModel = macroUCViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Pendiente de movimiento");
        }

       
    }
}
