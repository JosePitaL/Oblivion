using Studio.Model;
using Studio.Servicios;
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
            foreach (var item in viewModel.NewTabItem)
            {
                foreach (var item1 in item.macroUCViewModels)
                {
                    if(item1.Borde == Brushes.Red)
                    {
                        if(item1.accionForms.Count > 3)
                        {
                            item1.MacroHeigth += 30;
                        }
                        Reproductor.Comandos.Comando comando;
                        switch (parameter.ToString())
                        {
                            case "IMAGEN":
                                comando = Reproductor.Comandos.Comando.IMAGEN;
                                break;
                            case "IMAGENMOVE":
                                comando = Reproductor.Comandos.Comando.IMAGENMOVE;
                                break;
                            case "IMAGENCLICK":
                                comando = Reproductor.Comandos.Comando.IMAGENCLICK;
                                break;
                            case "MOVER":
                                comando = Reproductor.Comandos.Comando.MOVER;
                                break;
                            case "CLICK":
                                comando = Reproductor.Comandos.Comando.CLICK;
                                break;
                            case "ESCRIBIR":
                                comando = Reproductor.Comandos.Comando.ESCRIBIR;
                                break;
                            case "GHASH":
                                comando = Reproductor.Comandos.Comando.GHASH;
                                break;
                            case "LHASH":
                                comando = Reproductor.Comandos.Comando.LHASH; 
                                break;
                            case "LISTA":
                                comando = Reproductor.Comandos.Comando.LISTA;
                                break;
                            case "BUSCARLISTA":
                                comando = Reproductor.Comandos.Comando.BUSCARLISTA; 
                                break;
                            case "ANADIRLISTA":
                                comando = Reproductor.Comandos.Comando.ANADIRLISTA; 
                                break;
                            case "ELIMINARLISTA":
                                comando = Reproductor.Comandos.Comando.ELIMINARLISTA; 
                                break;
                            default:
                                comando = Reproductor.Comandos.Comando.IMAGEN;
                                break;
                        }
                        item1.accionForms.Add(new AccionesUCViewModel(viewModel)
                        {
                            Accion = new Accion()
                            {
                                Comando = comando
                            }
                        });
                        viewModel.Automatismo.Lotes[viewModel.SelectedItem].Macros[int.Parse(item1.Index)].Acciones.Add(item1.accionForms[item1.accionForms.Count - 1].Accion);
                    }
                }
            }
           
        }
    }
}
