using CmsClient.ViewModels;
using System.Linq;
using System.Windows.Controls;

namespace CmsClient.Views
{
    /// <summary>
    /// MediaFileListView.xaml の相互作用ロジック
    /// </summary>
    public partial class MediaFileListView : UserControl
    {
        public MediaFileListView()
        {
            InitializeComponent();
        }

        private void flow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = DataContext as MediaFileListViewModel;
            if (vm != null)
            {
                e.RemovedItems
                    .Cast<MediaFileViewModel>()
                    .ToList()
                    .ForEach(item => vm.SelectedFiles.Remove(item));
                e.AddedItems
                    .Cast<MediaFileViewModel>()
                    .ToList()
                    .ForEach(item => vm.SelectedFiles.Add(item));
            }
        }
    }
}
