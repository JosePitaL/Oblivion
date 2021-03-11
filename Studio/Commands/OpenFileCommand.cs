using Studio.Model;
using Studio.Servicios;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace Studio.Commands
{
    public class OpenFileCommand : ICommand
    {
        public OpenFileCommand(MainWindowViewModel Main)
        {
            this.Main = Main;
        }

        public event EventHandler CanExecuteChanged;
        public MainWindowViewModel Main { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Abrir Fichero

            Fichero fichero = new Fichero();
            fichero.Path = fichero.OpenFile();

            Main.Automatismo= null;
            Main.Automatismo = fichero.OpenRobot();
            Fichero.GenerateTree(Main.Automatismo, Main);

            foreach (var lote in Main.Automatismo.Lotes)
            {
                LoteViewModel loteView = new LoteViewModel(Main, true)
                {
                    Lote = lote
                };
                Main.ItemLote.Add(loteView);
                foreach (var macro in lote.Macros)
                {
                    MacroUCViewModel macroUCView = new MacroUCViewModel(Main, true)
                    {
                        Macro = macro,
                        Index = (loteView.ListMacro.Count).ToString()
                    };
                    loteView.ListMacro.Add(macroUCView);
                    foreach (var accion in macro.Acciones)
                    {
                        AccionesUCViewModel accionesUCView = new AccionesUCViewModel(Main, accion.Comando, macroUCView.Index, true)
                        {
                            Accion = accion
                        };
                        if(macroUCView.accionForms.Count > 3)
                        {
                            macroUCView.MacroHeigth += 30;
                        }
                        macroUCView.accionForms.Add(accionesUCView);
                    }
                }
            }
        }
    }
}
