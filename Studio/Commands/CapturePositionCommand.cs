
using Studio.ViewModel;
using System;
using System.Windows.Input;
using Studio.View;

namespace Studio.Commands
{
    public class CapturePositionCommand:ICommand
    {
        private MoverRatonUCViewModel moverRaton { get; set; }
        private MainWindowViewModel mainViewModel { get; set; }

        public event EventHandler CanExecuteChanged;
        private MoverPantalla moverPantalla { get; set; }

       
        public CapturePositionCommand(MoverRatonUCViewModel moverRaton, MainWindowViewModel mainViewModel)
        {

            this.mainViewModel = mainViewModel;
            this.moverRaton = moverRaton;
   
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {     
            pantallaRaton();
        }

        private void pantallaRaton()
        {
            moverPantalla = new MoverPantalla(mainViewModel,moverRaton);
            mainViewModel.minimizarVentanaMain();
            moverPantalla.Show();
        }

    }
}
