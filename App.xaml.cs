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
            InitializeComponent();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
            
        }
    }

}
