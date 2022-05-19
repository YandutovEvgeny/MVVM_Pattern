using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace TikTakToe
{
    class AboutViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _aboutText;
        BitmapSource _bitmapImageSource;
        public AboutViewModel()
        {
            _aboutText = "Эта программа создавалась\nс целью изучить MVVM на WPF";
            _bitmapImageSource = new BitmapImage(new Uri("C:\\Users\\Admin\\Figures\\bird.png"));
            Notify("AboutText");
            Notify("BitmapImageSource");
        }

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string AboutText
        {
            get { return _aboutText; }
        }

        public BitmapSource BitmapImageSource
        {
            get { return _bitmapImageSource; }
        }
    }
}
