using Studio.Commands;
using Studio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
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
            set 
            { 
                _mainWindowViewModel = value;
                OnPropertyChanged(nameof(mainWindowViewModel));
            }
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

        private ObservableCollection<AccionesUCViewModel> _accionForms;
        public ObservableCollection<AccionesUCViewModel> accionForms
        {
            get { return _accionForms; }
            set 
            { 
                _accionForms = value;
                OnPropertyChanged(nameof(accionForms));
            }
        }

        public MacroUCViewModel(MainWindowViewModel mainWindowViewModel)
        {
            accionForms = new ObservableCollection<AccionesUCViewModel>();
            this.mainWindowViewModel = mainWindowViewModel;
            Borde = Brushes.Black;
            SelectedMacroCommand = new SelectedMacroCommand(this);  
        }
    }
}
