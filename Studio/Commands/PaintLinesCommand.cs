using Studio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Studio.Commands
{
    public class PaintLinesCommand : ICommand
    {
        public PaintLinesCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public MainWindowViewModel mainWindowViewModel { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int IndexMainVM = 0;
            foreach (var item in mainWindowViewModel.NewTabItem)
            {

                for (int i = 0; i < item.macroUCViewModels.Count; i++)
                {
                    string ok = item.macroUCViewModels[i].OkBoxValue;
                    string ko = item.macroUCViewModels[i].KoBoxValue;
                    if (ok.Equals("0") || ko.Equals("0") || ko is null || ok is null) return;
                    if (ok.Equals(ko))
                    {
                        if(IndexMainVM == int.Parse(ok.Split("-")[0]))
                        {
                            item.macroUCViewModels[i].WayLotMacro.Children.Clear();
                            var p1 = new Point(item.macroUCViewModels[i].CanvasLeft + item.macroUCViewModels[i].MacroWidth / 2, item.macroUCViewModels[i].CanvasTop + item.macroUCViewModels[i].MacroHeigth);
                            var p2 = new Point(p1.X, (p1.Y + item.macroUCViewModels[int.Parse(ok.Split("-")[1])].CanvasTop) / 2);
                            var p3 = new Point((item.macroUCViewModels[int.Parse(ok.Split("-")[1])].CanvasLeft + item.macroUCViewModels[int.Parse(ok.Split("-")[1])].MacroWidth / 2), p2.Y);
                            var p4 = new Point(p3.X, (p3.Y - p1.Y) + p3.Y);

                            item.canvas.Children.Add(new Polyline()
                            {
                                Points = new PointCollection()
                            {
                                p1,
                                p2,
                                p3,
                                p4,
                            },
                                Stroke = Brushes.Black,
                                Visibility = Visibility.Visible
                            }
                         );
                        }
                        else
                        {
                            Grid g = new Grid();
                            g.Children.Add(new Ellipse()
                            {
                                Stroke = Brushes.Green,
                                StrokeThickness = 3,
                                Width = 50,
                                Height = 50,
                                Visibility = Visibility.Visible
                            });
                           g.Children.Add(new TextBlock()
                            {
                                Text = "L " + ok.Split("-")[0] + "\n" + "M " + ok.Split("-")[1],
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center
                            });
                            item.macroUCViewModels[i].WayLotMacro.Children.Add(g);


                        }
                    }
                    else
                    {
                        item.macroUCViewModels[i].WayLotMacro.Children.Clear();
                        if (IndexMainVM == int.Parse(ok.Split("-")[0]))
                        {
                            var p1 = new Point(item.macroUCViewModels[i].CanvasLeft + item.macroUCViewModels[i].MacroWidth / 2, item.macroUCViewModels[i].CanvasTop + item.macroUCViewModels[i].MacroHeigth);
                            var p2 = new Point(p1.X, (p1.Y + item.macroUCViewModels[int.Parse(ok.Split("-")[1])].CanvasTop) / 2);
                            var p3 = new Point((item.macroUCViewModels[int.Parse(ok.Split("-")[1])].CanvasLeft + item.macroUCViewModels[int.Parse(ok.Split("-")[1])].MacroWidth / 2), p2.Y);
                            var p4 = new Point(p3.X, (p3.Y - p1.Y) + p3.Y);

                            item.canvas.Children.Add(new Polyline()
                            {
                                Points = new PointCollection()
                            {
                                p1,
                                p2,
                                p3,
                                p4
                            },
                                Stroke = Brushes.Black,
                                Visibility = Visibility.Visible
                            }
                         );
                        }
                        else
                        {
                            Grid g = new Grid();
                            g.Children.Add(new Ellipse()
                            {
                                Stroke = Brushes.Green,
                                StrokeThickness = 3,
                                Width = 50,
                                Height = 50,
                                Visibility = Visibility.Visible
                            });
                            g.Children.Add(new TextBlock()
                            {
                                Text = "L " + ok.Split("-")[0] + "\n" + "M " + ok.Split("-")[1],
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center
                            });
                            item.macroUCViewModels[i].WayLotMacro.Children.Add(g);
                        }
                        if (IndexMainVM == int.Parse(ko.Split("-")[0]))
                        {
                            var p5 = new Point(item.macroUCViewModels[i].CanvasLeft + item.macroUCViewModels[i].MacroWidth / 2, item.macroUCViewModels[i].CanvasTop + item.macroUCViewModels[i].MacroHeigth);
                            var p6 = new Point(p5.X, (p5.Y + item.macroUCViewModels[int.Parse(ko.Split("-")[1])].CanvasTop) / 2);
                            var p7 = new Point((item.macroUCViewModels[int.Parse(ko.Split("-")[1])].CanvasLeft + item.macroUCViewModels[int.Parse(ko.Split("-")[1])].MacroWidth / 2), p6.Y);
                            var p8 = new Point(p7.X, (p7.Y - p5.Y) + p7.Y);

                            item.canvas.Children.Add(new Polyline()
                            {
                                Points = new PointCollection()
                            {
                                p5,
                                p6,
                                p7,
                                p8
                            },
                                Stroke = Brushes.Red,
                                Visibility = Visibility.Visible
                            });
                        }
                        else
                        {
                            Grid g = new Grid();
                            g.Children.Add(new Ellipse()
                            {
                                Stroke = Brushes.Red,
                                StrokeThickness = 3,
                                Width = 50,
                                Height = 50,
                                Visibility = Visibility.Visible
                            });
                            g.Children.Add(new TextBlock()
                            {
                                Text = "L " + ko.Split("-")[0] + "\n" + "M " + ko.Split("-")[1],
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center
                            });
                            item.macroUCViewModels[i].WayLotMacro.Children.Add(g);
                        } 
                    }
                }
                IndexMainVM++;
            }
        }
    }
}
