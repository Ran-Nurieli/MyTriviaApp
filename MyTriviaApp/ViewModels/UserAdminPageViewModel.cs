
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

            
        }


        public List<string> GetAllPlayers()
        {
           List<Player> players = triviaService.GetPlayers();
            List<string> result = new List<string>();
            foreach (Player player in players)
            {
                result.Add(player.Name);
            }
            return result;

        }


        public ICommand LoadStudentsCommand { get; private set; }
        public ICommand AddStudentCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; } 
        public ICommand ResetPointsCommand { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }
        public ObservableCollection<Player> Players { get; set; }


        private bool isRefreshing;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }







    }
}
