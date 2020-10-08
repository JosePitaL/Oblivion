using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Studio.ViewModel
{
    public class AccionesUCViewModel : BaseViewModel
    {
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

        public AccionesUCViewModel(ContentControl AccionLabel, string AccionTextBox)
        {
            this.AccionButton = AccionLabel;
            this.AccionTextBox = AccionTextBox;
        }

    }
}
