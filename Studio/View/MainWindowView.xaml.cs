
using Studio.Commands;
using Studio.ViewModel;

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Studio.View
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            DataContext = new MainWindowViewModel();
            

        }
    }
}
