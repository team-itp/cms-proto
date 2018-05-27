using CmsClient.ViewModels;
using System.Windows;

namespace CmsClient.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var filesListVM = new MediaFileListViewModel("C:\\Temp\\Images");
            filesListVM.Startwatch();
            fileList.DataContext = filesListVM;
        }
    }
}
