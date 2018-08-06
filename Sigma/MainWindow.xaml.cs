using System.Windows;

namespace Sigma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var listPage = new ListPage(new ViewModel());
            MainFrame.Navigate(listPage);
        }
    }
}
