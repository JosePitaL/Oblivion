using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Studio.Commands
{
    public class AddMacroCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainWindowViewModel viewmodel { get; set; }

        public AddMacroCommand(MainWindowViewModel viewmodel)
        {
            this.viewmodel = viewmodel;
            
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter != null)
            {
                int p = int.Parse(parameter.ToString());
                viewmodel.NewTabItem[p].macroUCViewModels.Add(new MacroUCViewModel());
            }
            
        }
    }
}
