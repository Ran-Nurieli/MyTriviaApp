
using MyTriviaApp.Models;
using MyTriviaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTriviaApp.ViewModels
{
    internal class UserAdminPageViewModel:ViewModelBase
    {
        TriviaService triviaService;
        public UserAdminPageViewModel(TriviaService triviaService)
        {
            this.triviaService = triviaService;
            Players = new ObservableCollection<Player>();//רשימה ריקה
            fullList = new List<Player>();

            DeleteCommand = new Command(async (object obj) => { Player p = (Player)obj; Players.Remove(p); fullList.Remove(p); await triviaService.RemovePlayer(p); });//מחיקת התלמיד מהרשימה
            LoadPlayersCommand = new Command(async () => await LoadPlayers());
            ClearPlayersCommand = new Command(ClearPlayers, () => Players.Count > 0);
        }


        public List<string> GetAllPlayers()
        {
            List<Player> players = triviaService.GetPlayers1();
            List<string> result = new List<string>();
            foreach (Player player in players)
            {
                result.Add(player.Name);
            }
            return result;

        }


        private List<Player> fullList;
        
        public ICommand ClearPlayersCommand { get; private set; }
        public ICommand LoadPlayersCommand { get; private set; }
        public ICommand AddPlayerCommand { get; private set; }
        public ICommand RemovePlayerCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; } 
        public ICommand ResetPointsCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ObservableCollection<Player> Players { get; set; }
       

        private bool isRefreshing;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }





        private async Task LoadPlayers()
        {
            IsRefreshing = true;//נפעיל את אייקון הרענון

            fullList = await triviaService.GetPlayers();//נביא את אוסף התלמידים
            //נעדכן את אוסף התלמידים המוצג במסך מהרשימה המלאה
            Players.Clear();
            foreach (var student in fullList)
                Players.Add(student);
            //נעדכן האם ניתן להפעיל את הפעולות
            ((Command)ClearPlayersCommand).ChangeCanExecute();
            IsRefreshing = false;//בסיום נבטל את אייקון הרענון
        }

        //ריקון רשימת התלמידים המוצגת במסך
        private void ClearPlayers()
        {
            Players.Clear();
            ((Command)ClearPlayersCommand).ChangeCanExecute();

        }


    }
}
