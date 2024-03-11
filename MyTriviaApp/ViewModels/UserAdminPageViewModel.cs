
using MyTriviaApp.Models;
using MyTriviaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
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
        private string playerName;
        private string playerPassword;
        private string playerMail;
        private bool isRefreshing;
        public ObservableCollection<Player> Players { get; set; }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public Rank SelectedRank { get => selectedRank; set { selectedRank = value; OnPropertyChanged(); } }
        public Player SelectedPlayer { get => selectedPlayer; set { selectedPlayer = value;OnPropertyChanged(); } }
        public List<Rank> Ranks { get; private set; }
        public string PlayerName { get => playerName ;set { playerName = value; OnPropertyChanged(); } }
        public string PlayerPassword { get => playerPassword ;set { playerPassword = value; OnPropertyChanged(); } }
        public string PlayerMail { get => playerMail ;set { playerMail = value; OnPropertyChanged(); } }

        public ICommand ClearPlayersCommand { get; private set; }
        public ICommand LoadPlayersCommand { get; private set; }
        public ICommand AddPlayerCommand { get; private set; }
        public ICommand RemovePlayerCommand { get; private set; }
        public ICommand ResetPointsCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }


        public UserAdminPageViewModel(TriviaService service)
        {
            this.service = service;
            fullList = new List<Player>();
            IsRefreshing = false;
            SelectedRank = null;
            SelectedPlayer = null;
            PlayerName = "";
            PlayerMail = "";
            PlayerPassword = "";
            Ranks = service.GetRanks();
            Players = new ObservableCollection<Player>();

            ClearPlayersCommand = new Command(ClearPlayers);


            RemovePlayerCommand = new Command(async (object obj) => await RemovePlayer((Player)obj));//מחיקת התלמיד מהרשימה

            ResetPointsCommand = new Command(async (object obj) => await ResetPlayerPoints((Player)obj));

            LoadPlayersCommand = new Command(async () => await LoadPlayers());
            AddPlayerCommand = new Command(() => AddPlayer());


            FilterCommand = new Command(() => {
                if (fullList != null && fullList.Count > 0)
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
            });

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
            service.UpdatePlayer(p);
            int pos = Players.IndexOf(p);
            Players.RemoveAt(pos);
            Players.Insert(pos, p);
        }

        private async Task LoadPlayers()
        {
            //IsRefreshing = true;

            //fullList = await service.GetPlayers();
            //Players.Clear();
            //foreach (var player in fullList)
            //    Players.Add(player);

            //((Command)ClearPlayersCommand).ChangeCanExecute();
            //IsRefreshing = false;
            IsRefreshing = true;
            fullList = service.GetPlayers1();
            Players = new ObservableCollection<Player>(fullList);
            OnPropertyChanged(nameof(Players));
            IsRefreshing = false;


        }
        private async Task Refresh()
        {
            IsRefreshing = true;
            await LoadPlayers();
            IsRefreshing = false;
        }
        private void AddPlayer()
        {
            if(!Players.Any(x=>x.Mail == playerMail))
            {
                Rank rookieRank = service.GetRanks()[2];
                Player newPlayer = new Player() { Mail = playerMail, Password = playerPassword, Points = 0, RankId = rookieRank.GetRankId(2), Rank = rookieRank, Name = playerName };
                Players.Add(newPlayer);
                service.AddPlayer(newPlayer);
            }
            else
            {
                AppShell.Current.DisplayAlert(",", "error", "player already exists");
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
    }
}
