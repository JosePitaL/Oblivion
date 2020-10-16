using Studio.Commands;
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

        private ContentControl _accionButton;
        public ContentControl AccionButton
        {
            get { return _accionButton; }
            set 
            { 
                _accionButton = value;
                OnPropertyChanged(nameof(AccionButton));
            }
        }

        private string _accionTextBox;
        public string AccionTextBox
        {
            get { return _accionTextBox; }
            set
            {
                _accionTextBox = value;
                OnPropertyChanged(nameof(AccionTextBox));
            }
        }

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

        public MainWindowViewModel main { get; set; }




        public AccionesUCViewModel(ContentControl AccionButton, string AccionTextBox, MainWindowViewModel main)
        {
            ActionSeleted = Brushes.Transparent;
            this.main = main;
            this.AccionButton = AccionButton;
            this.AccionTextBox = AccionTextBox;
            SelectedActionCommand = new SelectedActionCommand(this, main);
        }

    }
}
