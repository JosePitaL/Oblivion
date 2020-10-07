using Studio.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.ViewModel
{
    public class MacroUCViewModel : BaseViewModel
    {
        
        public ICommand SelectedMacroCommand { get; set; }

        private MainWindowViewModel _mainWindowViewModel;

        public MainWindowViewModel mainWindowViewModel
        {
            get { return _mainWindowViewModel; }
            set { _mainWindowViewModel = value; }
        }

        private Brush _borde;
        public Brush Borde
        {
            get { return _borde; }
            set 
            { 
                _borde = value;
                OnPropertyChanged(nameof(Borde));
            }
        }

        public MacroUCViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            Borde = Brushes.Black;
            SelectedMacroCommand = new SelectedMacroCommand(this);
        }


    }
}
