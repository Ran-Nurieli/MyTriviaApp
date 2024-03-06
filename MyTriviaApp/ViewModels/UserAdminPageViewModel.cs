
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


        private List<Player> fullList;
        private Player selectedPlayer;
        private Rank selectedRank;
        public Player SelectedPlayer { get => selectedPlayer; set { selectedPlayer = value;OnPropertyChanged(); } }
        public ICommand ClearPlayersCommand { get; private set; }
        public ICommand LoadPlayersCommand { get; private set; }
        public ICommand AddPlayerCommand { get; private set; }
        public ICommand RemovePlayerCommand { get; private set; }
        public ICommand ResetPointsCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }
        public Rank SelectedRank { get => selectedRank; set { selectedRank = value; OnPropertyChanged(); } }

        public ObservableCollection<Player> Players { get; set; }
       

        private bool isRefreshing;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }

        public UserAdminPageViewModel(TriviaService triviaService)
        {
            this.triviaService = triviaService;
            Players = new ObservableCollection<Player>();//רשימה ריקה
            fullList = new List<Player>();

            RemovePlayerCommand = new Command(async (object obj) => { Player p = (Player)obj; Players.Remove(p); fullList.Remove(p); await triviaService.RemovePlayer(p); });//מחיקת התלמיד מהרשימה
            LoadPlayersCommand = new Command(async () => await LoadPlayers());
            FilterCommand = new Command(() =>
            {
                try
                {
                    var FilterByRanks = fullList.Where(x => x.Rank == selectedRank).ToList();

                    Players.Clear();

                    foreach (var student in FilterByRanks)
                        Players.Add(student);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            }, () => fullList != null && fullList.Count > 0);
            ClearFilterCommand = new Command(async () => { await LoadPlayers(); }, () => fullList != null && fullList.Count > 0);
        }

        private async Task LoadPlayers()
        {
            IsRefreshing = true;

            fullList = await triviaService.GetPlayers(); 
            Players.Clear();
            foreach (var player in fullList)
                Players.Add(player);
            
            ((Command)ClearPlayersCommand).ChangeCanExecute();
            IsRefreshing = false;
        }

        //ריקון רשימת התלמידים המוצגת במסך
        private void ClearPlayers()
        {
            Players.Clear();
            ((Command)ClearPlayersCommand).ChangeCanExecute();

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

        private void Delete()
        {
            if(SelectedPlayer != null)
            {
                Players.Remove(SelectedPlayer);
                SelectedPlayer = null;
            }
        }
    }
}
