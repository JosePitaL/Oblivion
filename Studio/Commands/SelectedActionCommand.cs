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
            var p = parameter as ContentControl;
            switch (p.Content.ToString())
            {
                case "BuscarImagen":
                    viewModel.SelectedViewModel = new BuscarImagenUCViewModel(viewModel);
                    break;
                case "BuscarMoverImagen":
                    viewModel.SelectedViewModel = new BuscarMoverImagenUCViewModel();
                    break;
                case "ImagenClick":
                    viewModel.SelectedViewModel = new ImagenClickUCViewModel();
                    break;
                case "MoverRaton":
                    viewModel.SelectedViewModel = new MoverRatonUCViewModel();
                    break;
                case "ClickarRaton":
                    viewModel.SelectedViewModel = new ClickarRatonUCModel();
                    break;
                case "Escribir":
                    viewModel.SelectedViewModel = new EscribirUCViewModel();
                    break;
                case "GuardarHash":
                    viewModel.SelectedViewModel = new GuardarHashUCViewModel();
                    break;
                case "LeerHash":
                    viewModel.SelectedViewModel = new LeerHashUCViewModel();
                    break;
                case "CrearLista":
                    viewModel.SelectedViewModel = new CrearListaUCViewModel();
                    break;
                case "BuscarenLista":
                    viewModel.SelectedViewModel = new BuscarValorListaUCViewModel();
                    break;
                case "AñadirenLista":
                    viewModel.SelectedViewModel = new AnadirValorListaUCViewModel();
                    break;
                case "EliminarenLista":
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
