using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Sigma
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int selectedIdx;
        private int blurRadius;
        private ICommand nextCommand;
        private ICommand prevCommand;
        private ICommand blurCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<ImageModel> Images { get; set; }
        public ImageModel SelectedImage => Images[selectedIdx];

        public ICommand NextCommand => nextCommand ?? (nextCommand = new RelayCommand(p => Next()));
        public ICommand PrevCommand => prevCommand ?? (prevCommand = new RelayCommand(p => Prev()));
        public ICommand BlurCommand => blurCommand ?? (blurCommand = new RelayCommand(p => ChangeBlur()));

        public int BlurRadius
        {
            get => blurRadius;
            set
            {
                if (blurRadius != value)
                {
                    blurRadius = value;
                    Notify(nameof(BlurRadius));
                }
            }
        }

        public ViewModel()
        {
            Images = new ObservableCollection<ImageModel>();
            selectedIdx = 0;
            BlurRadius = 0;
        }

        public void ChangeBlur()
        {
            if (BlurRadius == 0)
            {
                BlurRadius = 50;
            }
            else
            {
                BlurRadius = 0;
            }
        }

        public void AddImage(string file)
        {
            Images.Add(new ImageModel
            {
                FileName = file,
                ImageData = new BitmapImage(new Uri(file))
            });
        }

        public void SetSelectedImage(ImageModel image) => selectedIdx = Images.IndexOf(image);

        public void Next()
        {
            if (Images.Count != 0)
            {
                selectedIdx++;
                if (selectedIdx >= Images.Count)
                {
                    selectedIdx = 0;
                }
                Notify(nameof(SelectedImage));
            }
        }

        public void Prev()
        {
            if (Images.Count != 0)
            {
                selectedIdx--;
                if (selectedIdx < 0)
                {
                    selectedIdx = Images.Count - 1;
                }
                Notify(nameof(SelectedImage));
            }
        }
    }
}
