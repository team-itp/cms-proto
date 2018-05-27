using CmsClient.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CmsClient.Views
{
    /// <summary>
    /// LoginView.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginView : UserControl
    {
        public readonly static RoutedCommand LoginCommand = new RoutedCommand("Login", typeof(LoginView));
        public readonly static RoutedCommand BackCommand = new RoutedCommand("Back", typeof(LoginView));

        public LoginView()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(LoginCommand, Login, CanLogin));
            CommandBindings.Add(new CommandBinding(BackCommand, Back));
        }

        private void CanLogin(object sender, CanExecuteRoutedEventArgs e)
        {
            var vm = DataContext as LoginViewModel;
            if (vm != null)
            {
                vm.Password = passwordBox.Password;
                e.CanExecute = vm.CanLogin();
            }
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as LoginViewModel;
            if (vm != null)
            {
                vm.Password = passwordBox.Password;
                await vm.Login();
            }
        }

        private void Back(object sender, ExecutedRoutedEventArgs e)
        {
            var vm = DataContext as LoginViewModel;
            if (vm != null)
            {
                vm.Back();
            }
        }
    }
}
