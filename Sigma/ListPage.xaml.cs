using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Sigma
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Images_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var viewModel = DataContext as ViewModel;
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    viewModel.AddImage(file);
                }
            }
        }

        private void Images_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Images.SelectedItem is ImageModel image)
            {
                var viewModel = DataContext as ViewModel;
                viewModel.SetSelectedImage(image);
                NavigationService.Navigate(new DetailPage(viewModel));
            }
        }
    }
}
