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



        public AccionesUCViewModel(ContentControl AccionLabel, string AccionTextBox)
        {
            ActionSeleted = Brushes.Transparent;
            this.AccionButton = AccionLabel;
            this.AccionTextBox = AccionTextBox;
            SelectedActionCommand = new SelectedActionCommand(this);
        }

    }
}
