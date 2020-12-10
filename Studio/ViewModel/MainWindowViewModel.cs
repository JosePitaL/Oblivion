using Studio.Commands;
using Studio.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;


namespace Studio.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand UpdateViewModelCommand { get; set; }
        public ICommand AddTabItemCommand { get; set; }
        public ICommand AddMacroCommand { get; set; }
        public ICommand PaintLinesCommand { get; set; }

       
        
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


        private WindowState _mainWindowStateChange;

        public WindowState MainWindowStateChange
        {
            get { return _mainWindowStateChange; }

            set
            {
                _mainWindowStateChange = value;
                OnPropertyChanged(nameof(MainWindowStateChange));
            }
        }

        public MainWindowViewModel()
        {

            maximarVentanaMain();
            UpdateViewModelCommand = new UpdateViewModelCommand(this);
            AddTabItemCommand = new AddTabItemCommand(this);
            AddMacroCommand = new AddMacroCommand(this);
            PaintLinesCommand = new PaintLinesCommand(this);
        }

        public void maximarVentanaMain()
        {
            MainWindowStateChange = WindowState.Maximized;
        }

        public void minimizarVentanaMain()
        {
            MainWindowStateChange = WindowState.Minimized;
        }
    }
}
