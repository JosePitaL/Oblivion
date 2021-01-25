using Studio.Commands;
using Studio.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.ViewModel
{
    public class AccionesUCViewModel : BaseViewModel
    {
        public ICommand SelectedActionCommand { get; set; }
        public ICommand DeleteActionCommand { get; set; }


        private Brush _actionSeleted;
        public Brush ActionSeleted
        {
            get { return _actionSeleted; }
            set 
            { 
                _actionSeleted = value;
                OnPropertyChanged(nameof(ActionSeleted));
            }
        }

        private Accion _accion;
        public Accion Accion
        {
            get { return _accion; }
            set
            {
                _accion = value;
                OnPropertyChanged(nameof(Accion));
            }
        }

        public MainWindowViewModel main { get; set; }




        public AccionesUCViewModel(MainWindowViewModel main)
        {
            ActionSeleted = Brushes.Transparent;
            this.main = main;
            SelectedActionCommand = new SelectedActionCommand(this, main);
            DeleteActionCommand = new DeleteActionCommand(this, main);
        }

    }
}
