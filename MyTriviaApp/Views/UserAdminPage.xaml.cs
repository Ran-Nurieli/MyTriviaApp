namespace MyTriviaApp.Views;

using MyTriviaApp.Services;
using MyTriviaApp.ViewModels;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

public partial class UserAdminPage : ContentPage
{
	public UserAdminPage()
	{
		InitializeComponent();
        TriviaService service = new TriviaService();
        UserAdminPageViewModel vm = new UserAdminPageViewModel(service);
        this.BindingContext = vm;

        
    }

}