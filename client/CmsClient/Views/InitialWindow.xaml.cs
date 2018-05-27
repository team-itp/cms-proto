using CmsClient.ViewModels;
using System.Windows;

namespace CmsClient.Views
{
    /// <summary>
    /// InitialWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class InitialWindow : Window
    {
        public InitialWindow()
        {
            InitializeComponent();
            this.DataContextChanged += InitialWindow_DataContextChanged;
        }

        private void InitialWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var vm = DataContext as InitialSettingViewModel;
            if (vm != null)
            {
                loginView.DataContext = vm.CurrentView;
            }
        }
    }
}
