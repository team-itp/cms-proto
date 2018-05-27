using CmsClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
