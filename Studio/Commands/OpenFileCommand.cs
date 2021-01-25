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

            Main.Automatismo = auto;

            
            foreach (var item in Main.Automatismo.Lotes)
            {
                int i = 0;
                ObservableCollection<MacroUCViewModel> macroUCs = new ObservableCollection<MacroUCViewModel>();
                MyTabItem tabItem = new MyTabItem(new ItemsControl(), new Canvas(), new ScrollViewer(), macroUCs)
                {
                    lote = item,
                };
                tabItem.Header = tabItem.lote.Nombre;
                Main.NewTabItem.Add(tabItem);

                foreach (var item1 in item.Macros)
                {
                    MacroUCViewModel macro = new MacroUCViewModel(Main);
                    macro.Index = i.ToString();
                    macro.Macro = item1;
                    ObservableCollection<AccionesUCViewModel> accionesUCViews = new ObservableCollection<AccionesUCViewModel>();
                    macro.accionForms = accionesUCViews;

                    macro.Macro = item1;
                    macroUCs.Add(macro);
                    foreach (var item2 in item1.Acciones)
                    {
                        if (accionesUCViews.Count > 3)
                        {
                            macro.MacroHeigth += 30;
                        }
                        AccionesUCViewModel acciones = new AccionesUCViewModel(Main)
                        {
                            Accion = item2
                        };
                        accionesUCViews.Add(acciones);
                    }
                    i++;
                }
            }
        }
    }
}
