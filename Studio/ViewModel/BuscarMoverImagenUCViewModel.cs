using Studio.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.ViewModel
{
    public class BuscarMoverImagenUCViewModel : BaseViewModel
    {

       public ICommand CaptureImageCommand { get; set; }

        public MainWindowViewModel mainWindowViewModel;


        public BuscarMoverImagenUCViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            CaptureImageCommand = new CaptureImageCommand(this, mainWindowViewModel);
        }
    }
}
