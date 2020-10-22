using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Studio.View
{
    /// <summary>
    /// Lógica de interacción para MacroUCView.xaml
    /// </summary>
    public partial class MacroUCView : UserControl
    {
        public MacroUCView()
        {
            InitializeComponent();
        }

        

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var thumb = sender as Thumb;
            var root = VisualTreeHelper.GetParent(thumb) as FrameworkElement;
            var left = Canvas.GetLeft(root);
            var top = Canvas.GetTop(root);
            left += e.HorizontalChange;
            top += e.VerticalChange;
            Canvas.SetLeft(root, left);
            Canvas.SetTop(root, top);
        }

        private void borde_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var bo = sender as Border;
            //var ca = VisualTreeHelper.GetParent(bo) as Grid;
            //var can = ca.Parent as Grid;
            //var l = can.Parent as Canvas;
            //var uc = l.Parent as UserControl;
            bo.Width = bo.ActualWidth;
            bo.Height = bo.ActualHeight;
        }
    }
}
