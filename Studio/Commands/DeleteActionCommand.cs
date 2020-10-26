using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.Commands
{
    public class DeleteActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public DeleteActionCommand(AccionesUCViewModel accionesUCViewModel, MainWindowViewModel viewModel)
        {
            this.accionesUCViewModel = accionesUCViewModel;
            this.viewModel = viewModel;
        }

        
        public AccionesUCViewModel accionesUCViewModel { get; set; }
        public MainWindowViewModel viewModel { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            foreach (var item in viewModel.NewTabItem)
            {
                foreach (var item1 in item.macroUCViewModels)
                {
                    foreach (var item2 in item1.accionForms)
                    {
                        if(item2.ActionSeleted == Brushes.SkyBlue)
                        {
                            item1.accionForms.Remove(item2);
                            return;
                        }
                    }
                }
            }
        }
    }
}
