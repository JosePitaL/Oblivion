using Studio.Commands;
using System.Windows.Input;

namespace Studio.ViewModel
{
    public class MoverRatonUCViewModel : BaseViewModel
    {
        public MainWindowViewModel main { get; set; }
        public ICommand MouseCaptureCommand { get; set; }

        private string _x;

        public string X
        {
            get { return _x; }
            set 
            { 
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        private string _y;

        public string Y
        {
            get { return _y; }
            set 
            { 
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }



        public MoverRatonUCViewModel(MainWindowViewModel main)
        {
            this.main = main;
            MouseCaptureCommand = new MouseCaptureCommand(this);
        }
    }
}
