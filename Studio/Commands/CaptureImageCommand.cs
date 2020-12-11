using Studio.Servicios;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.Commands
{
    public class CaptureImageCommand : ICommand
    {
        public CaptureImageCommand(BuscarImagenUCViewModel buscarImagen)
        {
            this.buscarImagen = buscarImagen;
        }

        public event EventHandler CanExecuteChanged;
        public BuscarImagenUCViewModel buscarImagen { get; set; }
        public WindowImageCapture window { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            window = new WindowImageCapture(buscarImagen.main);
            window.Show();
            buscarImagen.main.MainWindowState = System.Windows.WindowState.Minimized;
        }
    }
}
