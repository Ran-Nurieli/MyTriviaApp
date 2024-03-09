

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

        private TriviaService service;
        private List<Player> fullList;
        private Player selectedPlayer;
        private Rank selectedRank;
        public List<Rank> Ranks;
        private bool isRefreshing;
        public ObservableCollection<Player> Players { get; set; }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public Rank SelectedRank { get => selectedRank; set { selectedRank = value; OnPropertyChanged(); } }
        public Player SelectedPlayer { get => selectedPlayer; set { selectedPlayer = value;OnPropertyChanged(); } }

        public ICommand ClearPlayersCommand { get; private set; }
        public ICommand LoadPlayersCommand { get; private set; }
      //  public ICommand AddPlayerCommand { get; private set; }
        public ICommand RemovePlayerCommand { get; private set; }
        public ICommand ResetPointsCommand { get; private set; }
        //public ICommand RefreshCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }


        public UserAdminPageViewModel(TriviaService service)
        {
            this.service = service;
            fullList = new List<Player>();
            IsRefreshing = false;
            SelectedRank = null;
            SelectedPlayer = null;
            Players = new ObservableCollection<Player>();

            ClearPlayersCommand = new Command(ClearPlayers);


            RemovePlayerCommand = new Command(async (object obj) => await RemovePlayer((Player)obj));//מחיקת התלמיד מהרשימה

            ResetPointsCommand = new Command(async (object obj) => await ResetPlayerPoints((Player)obj));

            LoadPlayersCommand = new Command(async () => await LoadPlayers());


            FilterCommand = new Command(FilterPlayers);

            ClearFilterCommand = new Command(async () => { await LoadPlayers(); }, () => fullList != null && fullList.Count > 0);

            this.LoadPlayersCommand.Execute(null);














        }
        private async Task RemovePlayer(Player p)
        {
            Players.Remove(p); fullList.Remove(p);
            await service.RemovePlayer(p);
        }

        private async Task ResetPlayerPoints(Player p)
        {
            p.Points = 0;
        }

        private async Task LoadPlayers()
        {
            IsRefreshing = true;

            fullList = await service.GetPlayers();
            Players.Clear();
            foreach (var player in fullList)
                Players.Add(player);

            ((Command)ClearPlayersCommand).ChangeCanExecute();
            IsRefreshing = false;
        }

        
        private void FilterPlayers()
        {
            if(fullList != null && fullList.Count > 0)
            {
                try
                {
                    var FilterByRanks = fullList.Where(x => x.Rank == selectedRank).ToList();

                    Players.Clear();

                    foreach (var player in FilterByRanks)
                        Players.Add(player);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            
        }

        private void ClearPlayers()
        {
            Players.Clear();
            ((Command)ClearPlayersCommand).ChangeCanExecute();

        }
        public List<string> GetAllPlayers()
        {
            List<Player> players = service.GetPlayers1();
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
