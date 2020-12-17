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
            
            Automatismo auto = fichero.OpenRobot();
            fichero.GenerateTree(auto, Main);

            //Crear arbol
            foreach (var item in auto.Lotes)
            {
                ObservableCollection<MacroUCViewModel> macroUCs = new ObservableCollection<MacroUCViewModel>();
                MyTabItem tabItem = new MyTabItem(new ItemsControl(), new Canvas(), new ScrollViewer(), macroUCs)
                {
                    Header = item.Nombre
                };
                Main.NewTabItem.Add(tabItem);

                foreach (var item1 in item.Macros)
                {
                    MacroUCViewModel macro = new MacroUCViewModel(Main);
                    ObservableCollection<AccionesUCViewModel> accionesUCViews = new ObservableCollection<AccionesUCViewModel>();
                    macro.accionForms = accionesUCViews;
                    macro.Macro = item1;
                    macroUCs.Add(macro);
                    
                   
                    foreach (var item2 in item1.Acciones)
                    {
                        AccionesUCViewModel acciones = new AccionesUCViewModel(new ContentControl(), "",  Main);
                        accionesUCViews.Add(acciones);
                    }
                }
            }


        }
    }
}
