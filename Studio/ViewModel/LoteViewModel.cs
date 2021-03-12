using Studio.Commands;
using Studio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Studio.ViewModel
{
    public class LoteViewModel : BaseViewModel
    {
        public MainWindowViewModel main { get; set; }
        public ICommand DeleteLoteCommand { get; set; }


        public LoteViewModel(MainWindowViewModel main, bool f=false)
        {
            this.main = main;
            ListMacro = new ObservableCollection<MacroUCViewModel>();
            if(f==false)
            {
                Lote = new Lote()
                {
                    Macros = new List<Macro>()
                };
                main.Automatismo.Lotes.Add(Lote);
            }
            DeleteLoteCommand = new DeleteLoteCommand(main);
            
        }

        private ObservableCollection<MacroUCViewModel> _listMacro;
        public ObservableCollection<MacroUCViewModel> ListMacro
        {
            get { return _listMacro; }
            set
            {
                _listMacro = value;
                OnPropertyChanged(nameof(ListMacro));
            }
        }

        private Lote _lote;
        public Lote Lote
        {
            get { return _lote; }
            set
            {
                _lote = value;
                OnPropertyChanged(nameof(Lote));
            }
        }


    }
}
