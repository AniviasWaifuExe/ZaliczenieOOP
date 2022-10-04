using System.Windows;
using System.Windows.Controls;
using projectuwu.Views;

namespace projectuwu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Koncturktor widoku
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Frame() { Content = new Categories() };
        }
        private void Books_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Frame() { Content = new Books() };
        }
        private void Users_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Frame() { Content = new Users() };
        }
        private void Authors_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Frame() { Content = new Authors() };
        }
    }
}
