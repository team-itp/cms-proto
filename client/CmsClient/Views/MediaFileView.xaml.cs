using CmsClient.Utils;
using CmsClient.ViewModels;
using PdfiumViewer;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CmsClient.Views
{
    /// <summary>
    /// MediaFileView.xaml の相互作用ロジック
    /// </summary>
    public partial class MediaFileView : UserControl
    {
        public MediaFileView()
        {
            InitializeComponent();
            this.DataContextChanged += MediaFileView_DataContextChanged;
        }

        private void MediaFileView_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            RefleshMedia();
        }

        public void RefleshMedia()
        {
            var mediaFileVM = DataContext as MediaFileViewModel;
            if (mediaFileVM == null)
            {
                return;
            }

            var path = mediaFileVM.MediaFile.FullPath;
            if (path.ToUpper().EndsWith(".PDF"))
            {
                var document = PdfDocument.Load(path);
                var bitmap = document.Render(1, 96, 96, false);
                image.Source = BitmapHelper.ToBitmapSource(bitmap);
                image.Stretch = Stretch.UniformToFill;
            }
            else
            {
                image.Source = new BitmapImage(new Uri(path));
                image.Stretch = Stretch.UniformToFill;
            }
        }
    }
}
