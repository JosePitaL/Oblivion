using Studio.ViewModel;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;


namespace Studio.View
{
    /// <summary>
    /// Lógica de interacción para ImagenPantalla.xaml
    /// </summary>
    public partial class ImagenPantalla : Window
    {
        MainWindowViewModel mainWindowViewModel { get; set; }
        



        public ImagenPantalla(MainWindowViewModel mainWindowViewModel)
        {
            
            InitializeComponent();
            Opacity = 0.3;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.mainWindowViewModel = mainWindowViewModel;
            WindowState = WindowState.Maximized;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {


                var id = Guid.NewGuid();
           
                Bitmap Captura = new Bitmap((int)this.ActualWidth, (int)this.ActualHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                System.Drawing.Rectangle Rectangulo = Screen.AllScreens[0].Bounds;
                Graphics grafico = Graphics.FromImage(Captura);
                grafico.CopyFromScreen((int)this.Left, (int)this.Top, 0, 0, Rectangulo.Size);
                Captura.Save(@"C:\proba\" + id.ToString("N") + "-(" + this.Left + "," + this.Top + ").jpg");
                System.Windows.Forms.Clipboard.SetImage(Captura);
                

                Close();
                mainWindowViewModel.maximarVentanaMain();
            }
        }
      
    }
}
