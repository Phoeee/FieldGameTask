using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FieldGameTask
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        double step = 0;

        public GameWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public GameWindow(double size) : this()
        {
            step = (canvasField.Width - 1) / size;
            DrawField(step);
            rectangleFigure.Width = step;
            rectangleFigure.Height = step;
        }

        private void DrawField(double step)
        {
            for (double i = 0; i < canvasField.Width; i += step)
            {
                DrawLine(canvasField, 0, i, canvasField.Height, i);
                DrawLine(canvasField, i, 0, i, canvasField.Width);
            }

        }

        private void DrawLine(Canvas canvas, double x1, double y1, double x2, double y2)
        {
            Line line = new Line
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = x1,
                X2 = x2,
                Y1 = y1,
                Y2 = y2
            };
            canvas.Children.Add(line);
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            //Move Down
            if (e.Key == Key.S || e.Key == Key.Down && Canvas.GetTop(rectangleFigure) + rectangleFigure.Height < canvasField.Height - 1.1)
            {
                Canvas.SetTop(rectangleFigure, Canvas.GetTop(rectangleFigure) + step);
            }
            //Move Up
            else if (e.Key == Key.W || e.Key == Key.Up && Canvas.GetTop(rectangleFigure) > 0)
            {
                Canvas.SetTop(rectangleFigure, Canvas.GetTop(rectangleFigure) - step);
            }
            //Move Left
            else if (e.Key == Key.A || e.Key == Key.Left && Canvas.GetLeft(rectangleFigure) > 0)
            {
                Canvas.SetLeft(rectangleFigure, Canvas.GetLeft(rectangleFigure) - step);

            }
            //Move Right
            else if (e.Key == Key.D && Canvas.GetLeft(rectangleFigure) + rectangleFigure.Width < canvasField.Width - 1.1)
            {
                Canvas.SetLeft(rectangleFigure, Canvas.GetLeft(rectangleFigure) + step);
            }
        }
    }
}