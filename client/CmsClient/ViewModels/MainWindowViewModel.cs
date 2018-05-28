using CmsClient.Properties;

namespace CmsClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UploaderViewModel _uploader;
        private MediaFileListViewModel _mediaFileList;

        public UploaderViewModel Uploader
        {
            get => _uploader;
            set
            {
                _uploader = value;
                OnPropertyChanged(nameof(Uploader));
            }
        }

        public MediaFileListViewModel MediaFileList
        {
            get => _mediaFileList;
            set
            {
                _mediaFileList = value;
                OnPropertyChanged(nameof(MediaFileList));
            }
        }

        public MainWindowViewModel()
        {
            var pathToWatch = Settings.Default.DirectoryToWatch;
            MediaFileList = new MediaFileListViewModel(pathToWatch);
            Uploader = new UploaderViewModel();

            MediaFileList.Startwatch();
        }
    }
}
