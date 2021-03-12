using Studio.View;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.Commands
{
    public class DeleteLoteCommand : ICommand
    {
        
        public event EventHandler CanExecuteChanged;
        public MainWindowViewModel main { get; set; }

        public DeleteLoteCommand(MainWindowViewModel main)
        {
            this.main = main;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            main.ItemLote.Remove(main.ItemLote[main.SelectedItem]);
            main.Automatismo.Lotes.Remove(main.Automatismo.Lotes[main.SelectedItem]);
        }
    }
}
