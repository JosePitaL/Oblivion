using Studio.Commands;
using Studio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Studio.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand UpdateViewModelCommand { get; set; }
        public ICommand AddTabItemCommand { get; set; }
        public ICommand AddMacroCommand { get; set; }
        public ICommand PaintLinesCommand { get; set; }
        public ICommand OpenFileCommand { get; set; }
        public ICommand AddLoteCommand { get; set; }

        private Automatismo _automatismo;
        public Automatismo Automatismo
        {
            get { return _automatismo; }
            set
            {
                _automatismo = value;
                OnPropertyChanged(nameof(Automatismo));
            }
        }

        private BaseViewModel _selectViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectViewModel; }
            set 
            { 
                _selectViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            } 
        }
        
        private ObservableCollection<MyTabItem> _newTabItem;
        public ObservableCollection<MyTabItem> NewTabItem
        {
            get { return _newTabItem; }
            set
            {
                _newTabItem = value;
                OnPropertyChanged(nameof(NewTabItem));
            }
        }

        private ObservableCollection<LoteViewModel> _itemLote;
        public ObservableCollection<LoteViewModel> ItemLote
        {
            get { return _itemLote; }
            set
            {
                _itemLote = value;
                OnPropertyChanged(nameof(ItemLote));
            }
        }

        private int _selectedItem;
        public int SelectedItem
        {
            get { return _selectedItem; }
            set 
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private WindowState _mainWindowState;
        public WindowState MainWindowState
        {
            get { return _mainWindowState; }
            set 
            { 
                _mainWindowState = value;
                OnPropertyChanged(nameof(MainWindowState));
            }
        }

        private string _runFile;

        public string RunFile
        {
            get { return _runFile; }
            set 
            {
                _runFile = value;
                OnPropertyChanged(nameof(RunFile));
            }
        }

        private ObservableCollection<MyTreeViewAutomatismo> _automata;
        public ObservableCollection<MyTreeViewAutomatismo> Automata
        {
            get { return _automata; }
            set
            {
                _automata = value;
                OnPropertyChanged(nameof(Automata));
            }
        }



        public MainWindowViewModel()
        {
            Automatismo = new Automatismo()
            {
                Lotes = new List<Lote>()
            };
            MainWindowState = WindowState.Maximized;
            Automata = new ObservableCollection<MyTreeViewAutomatismo>();
            ItemLote = new ObservableCollection<LoteViewModel>();
            UpdateViewModelCommand = new UpdateViewModelCommand(this);
            AddTabItemCommand = new AddTabItemCommand(this);
            AddMacroCommand = new AddMacroCommand(this);
            PaintLinesCommand = new PaintLinesCommand(this);
            OpenFileCommand = new OpenFileCommand(this);
            AddLoteCommand = new AddLoteCommand(this);
            
        }

        
    }
}
