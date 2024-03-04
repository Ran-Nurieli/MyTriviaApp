using MyTriviaApp.ViewModels;
using MyTriviaApp.Views;

namespace MyTriviaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

       


            MainPage = new UserAdminPage();
        }
    }
}