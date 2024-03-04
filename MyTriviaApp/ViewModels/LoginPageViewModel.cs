using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyTriviaApp.Services;

namespace MyTriviaApp.ViewModels
{
    internal class LoginPageViewModel:ViewModelBase
    {
        
        private string username;
        private string password;
        public string UserName { get{ return username; } set { username = value; OnPropertyChanged(); ((Command)LoginCommand).ChangeCanExecute(); } }
        public string Password { get { return password; } set { password = value;OnPropertyChanged();((Command)LoginCommand).ChangeCanExecute(); } }
        public ICommand LoginCommand {  get; set; }
        public ICommand CancelCommand {  get; set; }
        private Color color;

        public LoginPageViewModel() 
        {
            LoginCommand = new Command(Login, () => { return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password); });
        }

        private void Login()
        {
           TriviaService x=new TriviaService();
            bool result=x.Login(UserName, Password);
          
        }
    }
}
