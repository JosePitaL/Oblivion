using Reproductor;
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




        public AccionesUCViewModel(MainWindowViewModel main, Comandos.Comando comando, string index, bool f=false)
        {
            ActionSeleted = Brushes.Transparent;
            this.main = main;
            if(f== false)
            {
                Accion = new Accion()
                {
                    Comando = comando
                };
                main.Automatismo.Lotes[main.SelectedItem].Macros[int.Parse(index)].Acciones.Add(Accion);
            }
            
            SelectedActionCommand = new SelectedActionCommand(this, main);
            DeleteActionCommand = new DeleteActionCommand(this, main);
        }

    }
}
