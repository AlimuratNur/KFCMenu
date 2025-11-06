using KFCMenu.Stores;
using KFCMenu.View.Windows;
using KFCMenu.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;


namespace KFCMenu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        { 
            base.OnStartup(e);
            var navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new MenuPageViewModel(navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
    }

}
