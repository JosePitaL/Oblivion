using Studio.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.ViewModel
{
    public class BuscarImagenUCViewModel : BaseViewModel
    {
        public MainWindowViewModel main { get; set; }
        public ICommand CaptureImageCommand { get; set; }
        public BuscarImagenUCViewModel(MainWindowViewModel main)
        {
            this.main = main;
            CaptureImageCommand = new CaptureImageCommand(this);
        }
    }
}
