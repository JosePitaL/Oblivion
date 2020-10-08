using Studio.Model;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.Commands
{
    public class UpdateViewModelCommand : ICommand
    {
        private MainWindowViewModel viewModel;

        public UpdateViewModelCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "BuscarImagen":
                    viewModel.SelectedViewModel = new BuscarImagenUCViewModel();
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
                    if(item1.Borde == Brushes.Red)
                    {
                        item1.accionForms.Add(new AccionesUCViewModel(new ContentControl()
                        {
                            Content = parameter.ToString()
                        }, ""));
                    }
                    else
                    {
                        MessageBox.Show("No hay ninguna macro seleccionada");
                    }
                }
            }
           
        }
    }
}
