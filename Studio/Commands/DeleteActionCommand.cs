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
            
            for (int i = 0; i < viewModel.ItemLote.Count; i++)
            {
                for (int e = 0; e < viewModel.ItemLote[i].ListMacro.Count; e++)
                {
                    for (int u = 0; u < viewModel.ItemLote[i].ListMacro[e].accionForms.Count; u++)
                    {
                        if (viewModel.ItemLote[i].ListMacro[e].accionForms[u].ActionSeleted == Brushes.SkyBlue)
                        {
                            viewModel.ItemLote[i].ListMacro[e].accionForms.Remove(viewModel.ItemLote[i].ListMacro[e].accionForms[u]); ;
                            viewModel.Automatismo.Lotes[i].Macros[e].Acciones.Remove(viewModel.Automatismo.Lotes[i].Macros[e].Acciones[u]);
                            return;
                        }
                    }
                }
            }
        }
    }
}
