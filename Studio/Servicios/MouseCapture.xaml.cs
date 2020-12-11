using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Studio.Servicios
{
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }
    /// <summary>
    /// Lógica de interacción para MouseCapture.xaml
    /// </summary>
    public partial class MouseCapture : Window
    {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT Point);
        public MoverRatonUCViewModel moverRaton { get; set; }

        public MouseCapture(MoverRatonUCViewModel moverRaton)
        {
            InitializeComponent();
            this.moverRaton = moverRaton;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                POINT point;
                GetCursorPos(out point);
                moverRaton.X = point.X.ToString();
                moverRaton.Y = point.Y.ToString();
                this.Close();
                moverRaton.main.MainWindowState = WindowState.Maximized;
            }
        }
    }
}
