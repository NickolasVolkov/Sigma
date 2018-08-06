using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Sigma
{
    /// <summary>
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
        public DetailPage(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            Focusable = true;
            Loaded += (s, e) => Keyboard.Focus(this);
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                NavigationService.GoBack();
            }
        }
    }
}
