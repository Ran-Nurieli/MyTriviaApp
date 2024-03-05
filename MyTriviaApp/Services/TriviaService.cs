
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTriviaApp.Models;


namespace MyTriviaApp.Services
{
    public class TriviaService
    {
       private List<Player> players { get; set; }
       
       private List<Question> questions { get; set; }
       private List<Rank> ranks { get; set; }
       private List<Status> statuses { get; set; }
       private List<Subject> subjects { get; set; }

        public TriviaService()
        {
            this.players=new List<Player>();
            this.questions = new List<Question>();
            this.ranks = new List<Rank>();
            this.statuses = new List<Status>();
            this.subjects = new List<Subject>();
            FillRank();
            FillSubject();
            FillStatus();
            FillPlayers();
            
            

        }
        public List<Player>GetPlayers()
        {
            return players;
        }
        public List<Rank> GetRanks()
        {
            return ranks;
        }
        private void FillRank()
        {
            ranks.Add(new Rank() {RankId=0,RankName="Admin"});
            ranks.Add(new Rank() { RankId = 1, RankName = "Master" });
            ranks.Add(new Rank() { RankId = 2, RankName = "Rookie" });
        }
        private void FillSubject()
        {
            subjects.Add(new Subject() { SubjectId = 0, SubjectName = "Sport" });
            subjects.Add(new Subject() { SubjectId = 1, SubjectName = "History" });
            subjects.Add(new Subject() { SubjectId = 2, SubjectName = "Politics" });
        }
        private void FillStatus()
        {
            statuses.Add(new Status() { StatusId = 0, Status1 = "Approved" });
            statuses.Add(new Status() { StatusId = 1, Status1 = "Waiting" });
            statuses.Add(new Status() { StatusId = 2, Status1 = "Rejected" });
        }
        private void FillPlayers()
        {
            players.Add(new Player { Mail="Ben.Sha@gmail.com", Name = "Ben", RankId = ranks[0].GetRankId(0), Points = 0, Password = "123", Rank = ranks[0] });
            players.Add(new Player { Mail="ran@gmail.com", Name = "Ran", RankId = ranks[0].GetRankId(0), Points = 0, Password = "12345", Rank = ranks[0] });
            players.Add(new Player { Mail="ran@gmail.com", Name = "Ran", RankId = ranks[0].GetRankId(0), Points = 0, Password = "12345", Rank = ranks[0] });
            players.Add(new Player { Mail="ran@gmail.com", Name = "Ran", RankId = ranks[0].GetRankId(0), Points = 0, Password = "12345", Rank = ranks[0] });
            players.Add(new Player { Mail="ran@gmail.com", Name = "Ran", RankId = ranks[0].GetRankId(0), Points = 0, Password = "12345", Rank = ranks[0] });
            players.Add(new Player { Mail="ran@gmail.com", Name = "Ran", RankId = ranks[0].GetRankId(0), Points = 0, Password = "12345", Rank = ranks[0] });
            players.Add(new Player { Mail="ran@gmail.com", Name = "Ran", RankId = ranks[0].GetRankId(0), Points = 0, Password = "12345", Rank = ranks[0] });
            
            //להוסיף עוד שחקן
        }

       //להוסיף fill questions
       //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
        public bool Login(string user, string pass)
        {

          return  players.Any((x) => x.Name == user && x.Password == pass);
            //for(int i=0;i<user.Count();i++)
            //{
            //    User x= players[i];
            //    if (x.UserName == user && x.Password==pass)
            //        return true;
            //}
            //return false;
        }

        

    }
}
