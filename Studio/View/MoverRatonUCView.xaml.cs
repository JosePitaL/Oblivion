using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;


using System.Windows.Input;


namespace Studio.View
{
    /// <summary>
    /// Lógica de interacción para MoverRatonUCView.xaml
    /// </summary>
    public partial class MoverRatonUCView : UserControl
    {

        public MainWindow mainwindow { get; set; }
        

        public MoverRatonUCView()
        {
            InitializeComponent();
           
        }


        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

     }
 }

