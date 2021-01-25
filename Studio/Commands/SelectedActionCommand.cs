using Studio.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.Commands
{
    public class SelectedActionCommand : ICommand
    {
        public SelectedActionCommand(AccionesUCViewModel accionesUCViewModel, MainWindowViewModel viewModel)
        {
            this.accionesUCViewModel = accionesUCViewModel;
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public AccionesUCViewModel accionesUCViewModel { get; set; }
        public MainWindowViewModel viewModel  { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            switch (parameter.ToString())
            {
                case "IMAGEN":
                    viewModel.SelectedViewModel = new BuscarImagenUCViewModel(viewModel);
                    break;
                case "IMAGENMOVE":
                    viewModel.SelectedViewModel = new BuscarMoverImagenUCViewModel();
                    break;
                case "IMAGENCLICK":
                    viewModel.SelectedViewModel = new ImagenClickUCViewModel();
                    break;
                case "MOVER":
                    viewModel.SelectedViewModel = new MoverRatonUCViewModel(viewModel);
                    break;
                case "CLICK":
                    viewModel.SelectedViewModel = new ClickarRatonUCModel();
                    break;
                case "ESCRIBIR":
                    viewModel.SelectedViewModel = new EscribirUCViewModel();
                    break;
                case "GHASH":
                    viewModel.SelectedViewModel = new GuardarHashUCViewModel();
                    break;
                case "LHASH":
                    viewModel.SelectedViewModel = new LeerHashUCViewModel();
                    break;
                case "LISTA":
                    viewModel.SelectedViewModel = new CrearListaUCViewModel();
                    break;
                case "BUSCARLISTA":
                    viewModel.SelectedViewModel = new BuscarValorListaUCViewModel();
                    break;
                case "ANADIRLISTA":
                    viewModel.SelectedViewModel = new AnadirValorListaUCViewModel();
                    break;
                case "ELIMINARLISTA":
                    viewModel.SelectedViewModel = new EliminarValorLitaUCViewModel();
                    break;
            }
            foreach (var item in viewModel.NewTabItem)
            {
                foreach (var item1 in item.macroUCViewModels)
                {
                    foreach (var item2 in item1.accionForms)
                    {
                        item2.ActionSeleted = Brushes.Transparent;
                    }
                    
                }
            }
            if (accionesUCViewModel.ActionSeleted == Brushes.Transparent)
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
