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
                        item1.accionForms.Add(new AccionesUCViewModel(viewModel));
                    }
                }
            }
           
        }
    }
}
