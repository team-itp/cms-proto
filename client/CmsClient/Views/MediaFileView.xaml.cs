using CmsClient.Utils;
using CmsClient.ViewModels;
using PdfiumViewer;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CmsClient.Views
{
    /// <summary>
    /// MediaFileView.xaml の相互作用ロジック
    /// </summary>
    public partial class MediaFileView : UserControl
    {
        private CancellationTokenSource _tokenSource;

        public MediaFileView()
        {
            InitializeComponent();
            this.DataContextChanged += MediaFileView_DataContextChanged;
            this.Unloaded += MediaFileView_Unloaded;
        }

        private void MediaFileView_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
            }

            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            var waitingTimeInMs = 1000;
            Task.Run(async () =>
            {
                await Task.Delay(100);
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            RefleshMedia();
                            _tokenSource = null;
                        });
                        return;
                    }
                    catch (Exception)
                    {
                        await Task.Delay(waitingTimeInMs *= 2);
                    }
                }
            });
        }

        private void MediaFileView_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _tokenSource?.Cancel();
        }

        public void RefleshMedia()
        {
            var mediaFileVM = DataContext as MediaFileViewModel;
            if (mediaFileVM == null)
            {
                return;
            }

            var path = mediaFileVM.MediaFile.FullPath;
            if (!File.Exists(path))
                return;

            if (path.ToUpper().EndsWith(".PDF"))
            {
                using (var document = PdfDocument.Load(path))
                {
                    var bitmap = document.Render(0, 96, 96, false);
                    image.Source = BitmapHelper.ToBitmapSource(bitmap);
                }
            }
            else
            {
                image.Source = new BitmapImage(new Uri(path));
            }
        }
    }
}
