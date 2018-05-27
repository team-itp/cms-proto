using CmsClient.Models;

namespace CmsClient.ViewModels
{
    public class MediaFileViewModel : ViewModelBase
    {
        public MediaFile MediaFile { get; private set; }

        public MediaFileViewModel(MediaFile mediaFile)
        {
            MediaFile = mediaFile;
        }
    }
}