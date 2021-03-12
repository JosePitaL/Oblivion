using Studio.ViewModel;
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
            for (int i = 0; i < macroUCViewModel.mainWindowViewModel.ItemLote.Count; i++)
            {
                for (int e = 0; e < macroUCViewModel.mainWindowViewModel.ItemLote[i].ListMacro.Count; e++)
                {
                    if (macroUCViewModel.mainWindowViewModel.ItemLote[i].ListMacro[e].Borde == Brushes.Red)
                    {
                        macroUCViewModel.mainWindowViewModel.ItemLote[i].ListMacro.Remove(macroUCViewModel.mainWindowViewModel.ItemLote[i].ListMacro[e]);
                        macroUCViewModel.mainWindowViewModel.Automatismo.Lotes[i].Macros.Remove(macroUCViewModel.mainWindowViewModel.Automatismo.Lotes[i].Macros[e]);
                        break;
                    }
                }
            }

            foreach (var item in macroUCViewModel.mainWindowViewModel.ItemLote)
            {
                int i = 0;
                foreach (var item1 in item.ListMacro)
                {
                    item1.Index = i.ToString();
                    i++;
                }
            }
        }
    }
}
