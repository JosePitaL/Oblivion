using Studio.View;
using Studio.ViewModel;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace Studio.Commands
{
    public class CaptureImageCommand:ICommand
    {

        public BuscarMoverImagenUCViewModel buscarImagenViewModel { get; set; }
        public MainWindowViewModel mainWindowViewModel { get; set; }

        public ImagenPantalla imagenPantalla { get; set; }

        public event EventHandler CanExecuteChanged;

        public CaptureImageCommand(BuscarMoverImagenUCViewModel buscarImagenViewModel, MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            this.buscarImagenViewModel = buscarImagenViewModel;
          

        }

     

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
     
          
                MessageBox.Show("hola");
                pantallaImagen();
            
        }

        private void pantallaImagen()
        {
            imagenPantalla = new ImagenPantalla(mainWindowViewModel);
            mainWindowViewModel.minimizarVentanaMain();
            imagenPantalla.Show();
        }

    }
}
