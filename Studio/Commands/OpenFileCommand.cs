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
            Fichero.GenerateTree(auto, Main);

            Main.Automatismo = auto;

            
            foreach (var item in Main.Automatismo.Lotes)
            {
                int i = 0;
                MyTabItem tabItem = new MyTabItem(new ItemsControl(), new Canvas(), new ScrollViewer(), new ObservableCollection<MacroUCViewModel>(),Main)
                {
                    lote = item,
                };
                tabItem.Header = tabItem.lote.Nombre;
                Main.NewTabItem.Add(tabItem);
                double top = 0;
                foreach (var item1 in item.Macros)
                {
                    MacroUCViewModel macro = new MacroUCViewModel(Main);
                    macro.Index = i.ToString();
                    macro.Macro = item1;
                    macro.accionForms = new ObservableCollection<AccionesUCViewModel>();
                    macro.CanvasTop = top;
                    tabItem.macroUCViewModels.Add(macro);

                    foreach (var item2 in item1.Acciones)
                    {
                        if (macro.accionForms.Count > 3)
                        {
                            macro.MacroHeigth += 30;
                        }
                        AccionesUCViewModel acciones = new AccionesUCViewModel(Main)
                        {
                            Accion = item2
                        };
                        macro.accionForms.Add(acciones);
                    }
                    top += macro.MacroHeigth + 50;
                    i++;
                }
            }

            foreach (var item in Main.NewTabItem)
            {
                item.CleanLines();
            }
            Main.PaintLinesCommand.Execute("");
        }
    }
}
