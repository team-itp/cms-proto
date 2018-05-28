using CmsClient.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CmsClient.Views
{
    /// <summary>
    /// SelectWatchDirectoryView.xaml の相互作用ロジック
    /// </summary>
    public partial class SelectWatchDirectoryView : UserControl
    {
        public static readonly RoutedCommand DoneCommand = new RoutedCommand("Done", typeof(SelectWatchDirectoryView));
        public static readonly RoutedCommand BackCommand = new RoutedCommand("Back", typeof(SelectWatchDirectoryView));

        public SelectWatchDirectoryView()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(DoneCommand, Done, CanDone));
            CommandBindings.Add(new CommandBinding(BackCommand, Back));
        }

        private void CanDone(object sender, CanExecuteRoutedEventArgs e)
        {
            var vm = DataContext as SelectWatchDirectoryViewModel;
            if (vm != null)
            {
                e.CanExecute = vm.CanDone();
            }
        }

        private void Done(object sender, ExecutedRoutedEventArgs e)
        {
            var vm = DataContext as SelectWatchDirectoryViewModel;
            if (vm != null)
            {
                vm.Done();
            }
        }

        private void Back(object sender, ExecutedRoutedEventArgs e)
        {
            var vm = DataContext as SelectWatchDirectoryViewModel;
            if (vm != null)
            {
                vm.Cancel();
            }
        }

        private void folder_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as SelectWatchDirectoryViewModel;
            if (vm == null)
            {
                return;
            }

            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(vm.PathToWatch))
            {
                folderBrowserDialog.SelectedPath = vm.PathToWatch;
            }
            var ret = folderBrowserDialog.ShowDialog();
            if (ret == System.Windows.Forms.DialogResult.OK)
            {
                vm.PathToWatch = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
