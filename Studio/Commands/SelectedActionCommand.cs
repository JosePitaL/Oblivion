using Studio.ViewModel;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.Commands
{
    public class SelectedActionCommand : ICommand
    {
        public SelectedActionCommand(AccionesUCViewModel accionesUCViewModel)
        {
            this.accionesUCViewModel = accionesUCViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public AccionesUCViewModel accionesUCViewModel { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(accionesUCViewModel.ActionSeleted == Brushes.Transparent)
            {
                accionesUCViewModel.ActionSeleted = Brushes.SkyBlue;
            }
            else
            {
                accionesUCViewModel.ActionSeleted = Brushes.Transparent;
            }
            
        }
    }
}
