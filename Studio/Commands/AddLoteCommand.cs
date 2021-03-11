using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.Commands
{
    class AddLoteCommand : ICommand
    {
        public AddLoteCommand(MainWindowViewModel main)
        {
            this.main = main;
        }

        public event EventHandler CanExecuteChanged;
        public MainWindowViewModel main { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LoteViewModel lote = new LoteViewModel(main);
            main.ItemLote.Add(lote);
        }
    }
}
