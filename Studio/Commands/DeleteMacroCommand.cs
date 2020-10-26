﻿using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.Commands
{
    public class DeleteMacroCommand : ICommand
    {
        public DeleteMacroCommand(MacroUCViewModel macroUCViewModel)
        {
            this.macroUCViewModel = macroUCViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public MacroUCViewModel macroUCViewModel { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            foreach (var item in macroUCViewModel.mainWindowViewModel.NewTabItem)
            {
                foreach (var item1 in item.macroUCViewModels)
                {
                    if(item1.Borde == Brushes.Red)
                    {
                        item.macroUCViewModels.Remove(item1);
                        break;
                    }
                }
            }
            int i = 0;
            foreach (var item in macroUCViewModel.mainWindowViewModel.NewTabItem)
            {
                foreach (var item1 in item.macroUCViewModels)
                {
                    item1.Index = i.ToString();
                    i++;
                }
            }
        }
    }
}