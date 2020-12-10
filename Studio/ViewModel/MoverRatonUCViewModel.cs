
using Studio.Commands;
using System.Windows.Input;

namespace Studio.ViewModel
{
    public class MoverRatonUCViewModel : BaseViewModel
    {
        public ICommand CapturePositionCommand { get; set; }
        public MainWindowViewModel mainWindowViewModel { get; set; }

        public MoverRatonUCViewModel(MainWindowViewModel mainWindowViewModel)
        {
           
            this.mainWindowViewModel = mainWindowViewModel;
            CapturePositionCommand = new CapturePositionCommand(this, mainWindowViewModel);
            
        }
      

        private string _accionTextBoxX;
        public string AccionTextBoxX
        {
            get { return _accionTextBoxX; }
            set
            {
                _accionTextBoxX = value;
                OnPropertyChanged(nameof(AccionTextBoxX));
            }
        }
       
        private string _accionTextBoxY;
        public string AccionTextBoxY
        {
            get { return _accionTextBoxY; }
            set
            {
                _accionTextBoxY = value;
                OnPropertyChanged(nameof(AccionTextBoxY));
            }
        }
      

    }
}
