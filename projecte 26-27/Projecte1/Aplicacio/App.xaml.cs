using System.Configuration;
using System.Data;
using System.Windows;

namespace Aplicacio
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string url = Settings.Default.url;
            string user = Settings.Default.user;
            string pwd = Settings.Default.pwd;

            DAO.MyDBContext.ConnectionString = $"User Id={user};Password={pwd};Data Source={url};";
        }
    }

}
