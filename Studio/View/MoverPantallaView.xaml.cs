using Studio.Servicios;
using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Simulador.Conf.Estructura;

namespace Studio.View
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class MoverPantalla : Window
    {
 
        MainWindowViewModel mainWindowView { get; set; }

        POINT point;

        public static bool proba = true;

        MoverRatonUCViewModel moverUCVRaton;

        public MoverPantalla(MainWindowViewModel mainWindowViewModel,MoverRatonUCViewModel moverRatonucViewModel)
        {
            
             InitializeComponent();
             Opacity = 0.3;
             WindowStyle = WindowStyle.None;
             AllowsTransparency = true;
             this.WindowStartupLocation = WindowStartupLocation.CenterScreen;         
             mainWindowView = mainWindowViewModel;
             moverUCVRaton = moverRatonucViewModel;
             this.WindowState = WindowState.Maximized;

          
        }

         private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        { 

              Close();
              point = CapturarPosicion.GetRatonPosicion();
              moverUCVRaton.AccionTextBoxX = point.X.ToString();
              moverUCVRaton.AccionTextBoxY = point.Y.ToString();
              mainWindowView.maximarVentanaMain();

        }

        
    }
}
