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
        public ICommand DeleteMacroCommand { get; set; }
        public ICommand LostFocusCaminoCommand { get; set; }
        public ICommand EditNameMacroCommand { get; set; }
        public ICommand LostFocusNameMacroCommand { get; set; }

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
                if (_mainWindowViewModel != null)
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
            set 
            {
                _waLotMacro = value;
                OnPropertyChanged(nameof(WayLotMacro));
            }
        }

        private Macro _macro;
        public Macro Macro
        {
            get { return _macro; }
            set
            {
                _macro = value;
                OnPropertyChanged(nameof(Macro));
                if (_mainWindowViewModel != null)
                {
                    try
                    {
                        mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].CleanLines();
                        mainWindowViewModel.PaintLinesCommand.Execute("");
                    }
                    catch (Exception)
                    {


                    }

                }
            }
        }

        private bool _focusableNameMacro;
        public bool FocusableNameMacro
        {
            get { return _focusableNameMacro; }
            set
            {
                _focusableNameMacro = value;
                OnPropertyChanged(nameof(FocusableNameMacro));
            }
        }


        public MacroUCViewModel(MainWindowViewModel mainWindowViewModel)
        {
            FocusableNameMacro = false;
            WayLotMacro = new StackPanel();
            MacroHeigth = 150;
            MacroWidth = 300;
            Macro = new Macro()
            {
                camino = new Camino()
                {
                    Ok = "0",
                    Ko = "0"
                }
            };
            CanvasLeft =0;
            CanvasTop = 150;
            Index = (mainWindowViewModel.NewTabItem[mainWindowViewModel.SelectedItem].macroUCViewModels.Count).ToString();
            accionForms = new ObservableCollection<AccionesUCViewModel>();
            this.mainWindowViewModel = mainWindowViewModel;
            Borde = Brushes.Black;
            SelectedMacroCommand = new SelectedMacroCommand(this);
            DeleteMacroCommand = new DeleteMacroCommand(this);
            EditNameMacroCommand = new EditNameMacroCommand(this);
            LostFocusCaminoCommand = new LostFocusCaminoCommand(this);
            LostFocusNameMacroCommand = new LostFocusNameMacroCommand(this);
        }
    }
}
