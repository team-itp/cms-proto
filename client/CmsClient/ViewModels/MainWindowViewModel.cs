using CmsClient.Properties;
using System.Collections.Specialized;
using System.Linq;

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
            MediaFileList.SelectedFiles.CollectionChanged += MediaFileListSelectedFiles_CollectionChanged;
        }

        private void MediaFileListSelectedFiles_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems == null)
            {
                e.NewItems
                    .Cast<MediaFileViewModel>()
                    .ToList()
                    .ForEach(vm => Uploader.SelectedMediaFiles.Add(vm.MediaFile));

            }
            else if (e.NewItems == null)
            {
                e.OldItems
                    .Cast<MediaFileViewModel>()
                    .ToList()
                    .ForEach(vm => Uploader.SelectedMediaFiles.Remove(vm.MediaFile));
            }
            else
            {
                e.OldItems.Cast<MediaFileViewModel>().Except(e.NewItems.Cast<MediaFileViewModel>())
                    .ToList()
                    .ForEach(vm => Uploader.SelectedMediaFiles.Remove(vm.MediaFile));
                e.NewItems.Cast<MediaFileViewModel>().Except(e.OldItems.Cast<MediaFileViewModel>())
                    .ToList()
                    .ForEach(vm => Uploader.SelectedMediaFiles.Add(vm.MediaFile));
            }
        }
    }
}
