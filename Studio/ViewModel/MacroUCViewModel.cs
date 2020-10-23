using Studio.Commands;
using Studio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Studio.ViewModel
{
    public class MacroUCViewModel : BaseViewModel
    {
        
        public ICommand SelectedMacroCommand { get; set; }

        private MainWindowViewModel _mainWindowViewModel = null;
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

        private string _index;
        public string Index
        {
            get { return _index; }
            set 
            {
                _index = value;
                OnPropertyChanged(nameof(Index));
            }
        }

        private string _okBoxValue;
        public string OkBoxValue
        {
            get { return _okBoxValue; }
            set 
            { 
                _okBoxValue = value;
                OnPropertyChanged(nameof(OkBoxValue));
                if (_mainWindowViewModel != null)
                {
                    mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].CleanLines();
                    mainWindowViewModel.PaintLinesCommand.Execute("");
                }
            }
        }

        private string _koBoxValue;
        public string KoBoxValue
        {
            get { return _koBoxValue; }
            set 
            { 
                _koBoxValue = value;
                OnPropertyChanged(nameof(KoBoxValue));
                if (_mainWindowViewModel != null)
                {
                    mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].CleanLines();
                    mainWindowViewModel.PaintLinesCommand.Execute("");
                }
            }
        }

        private double _macroWidth;
        public double MacroWidth
        {
            get { return _macroWidth; }
            set
            {
                _macroWidth = value;
                OnPropertyChanged(nameof(MacroWidth));
                if (_mainWindowViewModel != null)
                {
                    mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].CleanLines();
                    mainWindowViewModel.PaintLinesCommand.Execute("");
                }
            }
        }

        private double _macroHeigth;
        public double MacroHeigth
        {
            get { return _macroHeigth; }
            set
            {
                _macroHeigth = value;
                OnPropertyChanged(nameof(MacroHeigth));
                if(_mainWindowViewModel != null)
                {
                    mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].CleanLines();
                    mainWindowViewModel.PaintLinesCommand.Execute("");
                }
            }
        }

        private double _canvasLeft;
        public double CanvasLeft
        {
            get { return _canvasLeft; }
            set
            {
                _canvasLeft = value;
                OnPropertyChanged(nameof(CanvasLeft));
                if (_mainWindowViewModel != null)
                {
                    mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].CleanLines();
                    mainWindowViewModel.PaintLinesCommand.Execute("");
                }
            }
        }

        private double _canvasTop;
        public double CanvasTop
        {
            get { return _canvasTop; }
            set
            {
                _canvasTop = value;
                OnPropertyChanged(nameof(CanvasTop));
                if (_mainWindowViewModel != null)
                {
                    mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].CleanLines();
                    mainWindowViewModel.PaintLinesCommand.Execute("");
                }
            }
        }

        private StackPanel _waLotMacro;
        public StackPanel WayLotMacro
        {
            get { return _waLotMacro; }
            set { _waLotMacro = value; }
        }

        public MacroUCViewModel(MainWindowViewModel mainWindowViewModel)
        {
            WayLotMacro = new StackPanel();
            MacroHeigth = 150;
            MacroWidth = 300;
            OkBoxValue = "0";
            KoBoxValue = "0";
            CanvasLeft =0;
            CanvasTop = 0;
            Index = (mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].macroUCViewModels.Count).ToString();
            accionForms = new ObservableCollection<AccionesUCViewModel>();
            this.mainWindowViewModel = mainWindowViewModel;
            Borde = Brushes.Black;
            SelectedMacroCommand = new SelectedMacroCommand(this);  
        }
    }
}
