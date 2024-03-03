namespace MyTriviaApp.Views;
using MyTriviaApp.ViewModels;
using static System.Net.Mime.MediaTypeNames;

public partial class UserAdminPage : ContentPage
{
	public UserAdminPage()
	{
		InitializeComponent();
        //Invoke ViewModel Function GetAllUsers

        //Create With For loop all the SwipeViews
        for(int i = 0;i < 7; i++)
        {
            UsersStackLayout.Children.Add(CreateSwipeView("Username"));
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