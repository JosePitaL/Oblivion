using Studio.Servicios;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Studio.Commands
{
    public class MouseCaptureCommand : ICommand
    {
        public MouseCaptureCommand(MoverRatonUCViewModel MoverRaton)
        {
            this.MoverRaton = MoverRaton;
        }

        public event EventHandler CanExecuteChanged;
        public MoverRatonUCViewModel MoverRaton { get; set; }
        public MouseCapture window { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            window = new MouseCapture(MoverRaton);
            window.Show();
            MoverRaton.main.MainWindowState = System.Windows.WindowState.Minimized;
        }
    }
}
