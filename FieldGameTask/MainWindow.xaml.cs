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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FieldGameTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private uint fieldSize = 1;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ButtonRun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fieldSize = uint.Parse(textboxSize.Text);
                GameWindow game = new GameWindow(fieldSize);
                game.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // check if not number => not accept
            if (!IsNumber(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool IsNumber(string inputText)
        {
            return int.TryParse(inputText, out var output);
        }
    }
}
