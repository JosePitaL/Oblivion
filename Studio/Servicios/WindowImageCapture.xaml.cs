using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Studio.Servicios
{
    
    public partial class WindowImageCapture : Window
    {
        public MainWindowViewModel main { get; set; }

        public WindowImageCapture(MainWindowViewModel main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
            else
            {
                CapturarPantalla();
                main.MainWindowState = WindowState.Maximized;
            }
        }

        public void CapturarPantalla()
        {
            try
            {
                var id = Guid.NewGuid();
                this.WindowState = WindowState.Minimized;
                Bitmap Captura = new Bitmap((int)this.ActualWidth, (int)this.ActualHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                System.Drawing.Rectangle Rectangulo = Screen.AllScreens[0].Bounds;
                Graphics grafico = Graphics.FromImage(Captura);
                grafico.CopyFromScreen((int)this.Left, (int)this.Top, 0, 0, Rectangulo.Size);
                Captura.Save(@"C:\Users\34645\Documents\ImagenesRepo\" + id.ToString("N") + "-(" + this.Left + "," + this.Top + ").jpg");
                System.Windows.Forms.Clipboard.SetImage(Captura);
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
