namespace MyTriviaApp.Views;

using MyTriviaApp.Services;
using MyTriviaApp.ViewModels;
using static System.Net.Mime.MediaTypeNames;

public partial class UserAdminPage : ContentPage
{
	public UserAdminPage()
	{
		InitializeComponent();
        TriviaService service = new TriviaService();
        UserAdminPageViewModel vm = new UserAdminPageViewModel(service);
        this.BindingContext = vm;

        List<string> players = vm.GetAllPlayers();
        foreach(string player in players)
        {
            UsersStackLayout.Children.Add(CreateSwipeView(player));
        }

        



    }
    public SwipeView CreateSwipeView(string text)
    {
        SwipeView swipeView = new SwipeView();
        swipeView.LeftItems.Add(new SwipeItem { Text = "Delete", BackgroundColor = Colors.Red });
        swipeView.LeftItems.Add(new SwipeItem { Text = "Reset Points", BackgroundColor = Colors.Green });
        Grid grid = new Grid { BackgroundColor = Colors.LightGrey, HeightRequest = 60, WidthRequest = 300 };
        grid.Children.Add(new Label { Text = text, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center });
        swipeView.Content = grid;
        return swipeView;      
    }

}