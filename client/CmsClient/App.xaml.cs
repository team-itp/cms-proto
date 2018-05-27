using CmsClient.Properties;
using CmsClient.Services;
using CmsClient.ViewModels;
using CmsClient.Views;
using System.Windows;

namespace CmsClient
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public InitialSettingWindow InitialWindow { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (string.IsNullOrEmpty(Settings.Default.UserId))
            {
                LaunchInitialWizard();
                return;
            }

            try
            {
                var loginService = new LoginService();
                var credential = loginService.ValidateLogin(Settings.Default.UserId, Settings.Default.PasswordHash);
            }
            catch (LoginFailedException)
            {
                LaunchInitialWizard();
                return;
            }

            LaunchMain();
        }

        private void LaunchInitialWizard()
        {
            InitialWindow = new InitialSettingWindow();
            InitialWindow.DataContext = new InitialSettingViewModel(LaunchMain, Shutdown);
            InitialWindow.Show();
        }

        private void LaunchMain()
        {
            MainWindow = new MainWindow();
            MainWindow.Show();

            if (InitialWindow != null)
            {
                InitialWindow.Close();
                InitialWindow = null;
            }
        }
    }
}
