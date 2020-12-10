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
                

                Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                bmpScreenshot.Save("C:\\proba\\proba.png", ImageFormat.Png) ;
                   
                Close();
                mainWindowViewModel.maximarVentanaMain();
            }
        }
      
    }
}
