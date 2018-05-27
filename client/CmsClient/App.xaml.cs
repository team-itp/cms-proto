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
            MainWindow = new InitialWindow();
            MainWindow.DataContext = new InitialSettingViewModel(() => LaunchMain(), () => this.Shutdown());
            MainWindow.Show();
        }

        private void LaunchMain()
        {
            if (MainWindow != null)
            {
                MainWindow.Close();
            }

            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
